// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Gif.GifDecoder
// Assembly: ImageTools.IO.Gif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA7F4B99-2235-4710-895B-B5451D936C00
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Gif.dll

using ImageTools.Helpers;
using System;
using System.Globalization;
using System.IO;

#nullable disable
namespace ImageTools.IO.Gif
{
  public class GifDecoder : IImageDecoder
  {
    private const byte ExtensionIntroducer = 33;
    private const byte Terminator = 0;
    private const byte ImageLabel = 44;
    private const byte EndIntroducer = 59;
    private const byte ApplicationExtensionLabel = 255;
    private const byte CommentLabel = 254;
    private const byte ImageDescriptorLabel = 44;
    private const byte PlainTextLabel = 1;
    private const byte GraphicControlLabel = 249;
    private ExtendedImage _image;
    private Stream _stream;
    private GifLogicalScreenDescriptor _logicalScreenDescriptor;
    private byte[] _globalColorTable;
    private byte[] _lastFrame;
    private GifGraphicsControlExtension _graphicsControl;

    public int HeaderSize => 6;

    public bool IsSupportedFileExtension(string extension)
    {
      Guard.NotNullOrEmpty(extension, nameof (extension));
      return extension.ToUpper() == "GIF";
    }

    public bool IsSupportedFileFormat(byte[] header)
    {
      bool flag = false;
      if (header.Length >= 6)
        flag = header[0] == (byte) 71 && header[1] == (byte) 73 && header[2] == (byte) 70 && header[3] == (byte) 56 && (header[4] == (byte) 57 || header[4] == (byte) 55) && header[5] == (byte) 97;
      return flag;
    }

    public void Decode(ExtendedImage image, Stream stream)
    {
      this._image = image;
      this._stream = stream;
      this._stream.Seek(6L, SeekOrigin.Current);
      this.ReadLogicalScreenDescriptor();
      if (this._logicalScreenDescriptor.GlobalColorTableFlag)
      {
        this._globalColorTable = new byte[this._logicalScreenDescriptor.GlobalColorTableSize * 3];
        stream.Read(this._globalColorTable, 0, this._globalColorTable.Length);
      }
      int num = stream.ReadByte();
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_10;
          case 33:
            switch (stream.ReadByte())
            {
              case 1:
                this.Skip(13);
                break;
              case 249:
                this.ReadGraphicalControlExtension();
                break;
              case 254:
                this.ReadComments();
                break;
              case (int) byte.MaxValue:
                this.Skip(12);
                break;
            }
            break;
          case 44:
            this.ReadFrame();
            break;
          case 59:
            goto label_9;
        }
        num = stream.ReadByte();
      }
label_9:
      return;
label_10:;
    }

    private void Skip(int length)
    {
      this._stream.Seek((long) length, SeekOrigin.Current);
      int offset;
      while ((offset = this._stream.ReadByte()) != 0)
        this._stream.Seek((long) offset, SeekOrigin.Current);
    }

    private void ReadGraphicalControlExtension()
    {
      byte[] buffer = new byte[2];
      this._stream.Seek(1L, SeekOrigin.Current);
      this._graphicsControl = new GifGraphicsControlExtension();
      this._graphicsControl.Packed = (byte) this._stream.ReadByte();
      this._graphicsControl.TransparencyFlag = ((int) this._graphicsControl.Packed & 1) == 1;
      this._graphicsControl.DisposalMethod = (DisposalMethod) (((int) this._graphicsControl.Packed & 28) >> 2);
      this._stream.Read(buffer, 0, buffer.Length);
      this._graphicsControl.DelayTime = (int) BitConverter.ToInt16(buffer, 0);
      this._graphicsControl.TransparencyIndex = this._stream.ReadByte();
      this._stream.Seek(1L, SeekOrigin.Current);
    }

    private void ReadComments()
    {
      int count;
      while ((count = this._stream.ReadByte()) != 0)
      {
        byte[] buffer = new byte[count];
        this._stream.Read(buffer, 0, count);
        this._image.Properties.Add(new ImageProperty("Comments", BitConverter.ToString(buffer)));
      }
    }

    private void ReadFrame()
    {
      GifImageDescriptor gifImageDescriptor = this.ReadImageDescriptor();
      byte[] numArray = this.ReadLocalColorTable(gifImageDescriptor);
      byte[] indices = this.ReadIndices(gifImageDescriptor);
      byte[] colorTable = numArray ?? this._globalColorTable;
      if (!gifImageDescriptor.InterlaceFlag)
        this.ReadColors(indices, colorTable, gifImageDescriptor);
      int offset = this._stream.ReadByte();
      if (offset <= 0)
        return;
      this._stream.Seek((long) offset, SeekOrigin.Current);
    }

    private byte[] ReadIndices(GifImageDescriptor imageDescriptor)
    {
      int dataSize = this._stream.ReadByte();
      return new LZWDecoder(this._stream).DecodePixels((int) imageDescriptor.Width, (int) imageDescriptor.Height, dataSize);
    }

    private byte[] ReadLocalColorTable(GifImageDescriptor imageDescriptor)
    {
      byte[] buffer = (byte[]) null;
      if (imageDescriptor.LocalColorTableFlag)
      {
        buffer = new byte[imageDescriptor.LocalColorTableSize * 3];
        this._stream.Read(buffer, 0, buffer.Length);
      }
      return buffer;
    }

    private void ReadColors(byte[] indices, byte[] colorTable, GifImageDescriptor descriptor)
    {
      int width = (int) this._logicalScreenDescriptor.Width;
      int height = (int) this._logicalScreenDescriptor.Height;
      byte[] numArray = new byte[width * height * 4];
      if (this._lastFrame == null)
        this._lastFrame = new byte[width * height * 4];
      int index1 = 0;
      for (int top = (int) descriptor.Top; top < (int) descriptor.Top + (int) descriptor.Height; ++top)
      {
        for (int left = (int) descriptor.Left; left < (int) descriptor.Left + (int) descriptor.Width; ++left)
        {
          int num = top * width + left;
          int index2 = (int) indices[index1];
          if (this._graphicsControl != null && this._graphicsControl.TransparencyFlag && this._graphicsControl.TransparencyIndex == index2)
          {
            if (this._graphicsControl.DisposalMethod == DisposalMethod.Unspecified)
            {
              this._lastFrame[num * 4] = colorTable[index2 * 3];
              this._lastFrame[num * 4 + 1] = colorTable[index2 * 3 + 1];
              this._lastFrame[num * 4 + 2] = colorTable[index2 * 3 + 2];
              this._lastFrame[num * 4 + 3] = (byte) 0;
            }
          }
          else
          {
            this._lastFrame[num * 4] = colorTable[index2 * 3];
            this._lastFrame[num * 4 + 1] = colorTable[index2 * 3 + 1];
            this._lastFrame[num * 4 + 2] = colorTable[index2 * 3 + 2];
            this._lastFrame[num * 4 + 3] = byte.MaxValue;
          }
          ++index1;
        }
      }
      Array.Copy((Array) this._lastFrame, (Array) numArray, numArray.Length);
      ImageBase imageBase;
      if (this._image.Pixels == null)
      {
        imageBase = (ImageBase) this._image;
        imageBase.SetPixels(width, height, numArray);
      }
      else
      {
        ImageFrame imageFrame = new ImageFrame();
        imageBase = (ImageBase) imageFrame;
        imageBase.SetPixels(width, height, numArray);
        this._image.Frames.Add(imageFrame);
      }
      if (this._graphicsControl == null)
        return;
      if (this._graphicsControl.DelayTime > 0)
        imageBase.DelayTime = this._graphicsControl.DelayTime;
      if (this._graphicsControl.DisposalMethod == DisposalMethod.RestoreToBackground)
      {
        int index3 = (int) this._logicalScreenDescriptor.Background * 3;
        for (int top = (int) descriptor.Top; top < (int) descriptor.Top + (int) descriptor.Height; ++top)
        {
          for (int left = (int) descriptor.Left; left < (int) descriptor.Left + (int) descriptor.Width; ++left)
          {
            int num = top * width + left;
            this._lastFrame[num * 4] = this._globalColorTable[index3];
            this._lastFrame[num * 4 + 1] = this._globalColorTable[index3 + 1];
            this._lastFrame[num * 4 + 2] = this._globalColorTable[index3 + 2];
            this._lastFrame[num * 4 + 3] = (byte) 0;
          }
        }
      }
    }

    private GifImageDescriptor ReadImageDescriptor()
    {
      byte[] buffer = new byte[9];
      this._stream.Read(buffer, 0, 9);
      GifImageDescriptor gifImageDescriptor = new GifImageDescriptor();
      gifImageDescriptor.Left = BitConverter.ToInt16(buffer, 0);
      gifImageDescriptor.Top = BitConverter.ToInt16(buffer, 2);
      gifImageDescriptor.Width = BitConverter.ToInt16(buffer, 4);
      gifImageDescriptor.Height = BitConverter.ToInt16(buffer, 6);
      gifImageDescriptor.Packed = buffer[8];
      byte packed = gifImageDescriptor.Packed;
      gifImageDescriptor.LocalColorTableFlag = ((int) packed & 128) >> 7 == 1;
      gifImageDescriptor.LocalColorTableSize = 2 << ((int) packed & 7);
      gifImageDescriptor.InterlaceFlag = ((int) packed & 64) >> 6 == 1;
      gifImageDescriptor.SortFlag = ((int) packed & 32) >> 5 == 1;
      return gifImageDescriptor;
    }

    private void ReadLogicalScreenDescriptor()
    {
      byte[] buffer = new byte[3];
      this._logicalScreenDescriptor = new GifLogicalScreenDescriptor();
      this._stream.Read(buffer, 0, 2);
      this._logicalScreenDescriptor.Width = BitConverter.ToInt16(buffer, 0);
      this._stream.Read(buffer, 0, 2);
      this._logicalScreenDescriptor.Height = BitConverter.ToInt16(buffer, 0);
      this._stream.Read(buffer, 0, 3);
      this._logicalScreenDescriptor.Packed = buffer[0];
      this._logicalScreenDescriptor.Background = buffer[1];
      this._logicalScreenDescriptor.AspectRatio = buffer[2];
      byte packed = this._logicalScreenDescriptor.Packed;
      this._logicalScreenDescriptor.GlobalColorTableFlag = ((int) packed & 128) >> 7 == 1;
      this._logicalScreenDescriptor.GlobalColorTableSize = 2 << ((int) packed & 7);
      this._logicalScreenDescriptor.SortFlag = ((int) packed & 16) >> 4 == 1;
      this._logicalScreenDescriptor.ColorResolution = (byte) (((int) packed & 96) >> 5);
    }
  }
}
