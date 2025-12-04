// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Bmp.BmpDecoder
// Assembly: ImageTools.IO.Bmp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9CA5E000-9BA5-446B-BCEE-3A948EBA69F3
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Bmp.dll

using ImageTools.Helpers;
using System;
using System.Globalization;
using System.IO;

#nullable disable
namespace ImageTools.IO.Bmp
{
  public class BmpDecoder : IImageDecoder
  {
    private const int Rgb16RMask = 31744;
    private const int Rgb16GMask = 992;
    private const int Rgb16BMask = 31;
    private Stream _stream;
    private BmpFileHeader _fileHeader;
    private BmpInfoHeader _infoHeader;

    public int HeaderSize => 2;

    public bool IsSupportedFileExtension(string extension)
    {
      Guard.NotNullOrEmpty(extension, nameof (extension));
      string upper = extension.ToUpper();
      return upper == "BMP" || upper == "DIP";
    }

    public bool IsSupportedFileFormat(byte[] header)
    {
      Guard.NotNull((object) header, nameof (header));
      bool flag = false;
      if (header.Length >= 2)
        flag = header[0] == (byte) 66 && header[1] == (byte) 77;
      return flag;
    }

    public void Decode(ExtendedImage image, Stream stream)
    {
      this._stream = stream;
      try
      {
        this.ReadFileHeader();
        this.ReadInfoHeader();
        int count = -1;
        if (this._infoHeader.ClrUsed == 0)
        {
          if (this._infoHeader.BitsPerPixel == (short) 1 || this._infoHeader.BitsPerPixel == (short) 4 || this._infoHeader.BitsPerPixel == (short) 8)
            count = (int) Math.Pow(2.0, (double) this._infoHeader.BitsPerPixel) * 4;
        }
        else
          count = this._infoHeader.ClrUsed * 4;
        byte[] numArray1 = (byte[]) null;
        if (count > 0)
        {
          numArray1 = new byte[count];
          this._stream.Read(numArray1, 0, count);
        }
        byte[] numArray2 = new byte[this._infoHeader.Width * this._infoHeader.Height * 4];
        if (this._infoHeader.Compression != BmpCompression.RGB)
          throw new NotSupportedException("Does not support this kind of bitmap files.");
        if (this._infoHeader.HeaderSize != 40)
          throw new ImageFormatException(string.Format((IFormatProvider) CultureInfo.CurrentCulture, "Header Size value '{0}' is not valid.", new object[1]
          {
            (object) this._infoHeader.HeaderSize
          }));
        if (this._infoHeader.BitsPerPixel == (short) 32)
          this.ReadRgb32(numArray2, this._infoHeader.Width, this._infoHeader.Height);
        else if (this._infoHeader.BitsPerPixel == (short) 24)
          this.ReadRgb24(numArray2, this._infoHeader.Width, this._infoHeader.Height);
        else if (this._infoHeader.BitsPerPixel == (short) 16)
          this.ReadRgb16(numArray2, this._infoHeader.Width, this._infoHeader.Height);
        else if (this._infoHeader.BitsPerPixel <= (short) 8)
          this.ReadRgbPalette(numArray2, numArray1, this._infoHeader.ImageSize, this._infoHeader.Width, this._infoHeader.Height, (int) this._infoHeader.BitsPerPixel);
        image.SetPixels(this._infoHeader.Width, this._infoHeader.Height, numArray2);
      }
      catch (IndexOutOfRangeException ex)
      {
        throw new ImageFormatException("Bitmap does not have a valid format.", (Exception) ex);
      }
    }

    private void ReadRgbPalette(
      byte[] imageData,
      byte[] colors,
      int size,
      int width,
      int height,
      int bits)
    {
      int num1 = 8 / bits;
      int num2 = (width + num1 - 1) / num1;
      int num3 = (int) byte.MaxValue >> 8 - bits;
      byte[] buffer = new byte[size];
      this._stream.Read(buffer, 0, size);
      int num4 = num2 % 4;
      if (num4 != 0)
        num4 = 4 - num4;
      for (int y = 0; y < height; ++y)
      {
        int num5 = y * (num2 + num4);
        for (int index1 = 0; index1 < num2; ++index1)
        {
          int index2 = num5 + index1;
          int num6 = BmpDecoder.Invert(y, height);
          int num7 = index1 * num1;
          for (int index3 = 0; index3 < num1 && num7 + index3 < width; ++index3)
          {
            int num8 = (int) buffer[index2] >> 8 - bits - index3 * bits & num3;
            int index4 = (num6 * width + (num7 + index3)) * 4;
            imageData[index4] = colors[num8 * 4 + 2];
            imageData[index4 + 1] = colors[num8 * 4 + 1];
            imageData[index4 + 2] = colors[num8 * 4];
            imageData[index4 + 3] = byte.MaxValue;
          }
        }
      }
    }

    private void ReadRgb16(byte[] imageData, int width, int height)
    {
      int num1 = 8;
      int num2 = 4;
      int alignment = 0;
      byte[] imageArray = this.GetImageArray(width, height, 2, ref alignment);
      for (int y = 0; y < height; ++y)
      {
        int num3 = y * (width * 2 + alignment);
        int num4 = BmpDecoder.Invert(y, height);
        for (int index1 = 0; index1 < width; ++index1)
        {
          int startIndex = num3 + index1 * 2;
          short int16 = BitConverter.ToInt16(imageArray, startIndex);
          byte num5 = (byte) ((((int) int16 & 31744) >> 11) * num1);
          byte num6 = (byte) ((((int) int16 & 992) >> 5) * num2);
          byte num7 = (byte) (((int) int16 & 31) * num1);
          int index2 = (num4 * width + index1) * 4;
          imageData[index2] = num5;
          imageData[index2 + 1] = num6;
          imageData[index2 + 2] = num7;
          imageData[index2 + 3] = byte.MaxValue;
        }
      }
    }

    private void ReadRgb24(byte[] imageData, int width, int height)
    {
      int alignment = 0;
      byte[] imageArray = this.GetImageArray(width, height, 3, ref alignment);
      for (int y = 0; y < height; ++y)
      {
        int num1 = y * (width * 3 + alignment);
        int num2 = BmpDecoder.Invert(y, height);
        for (int index1 = 0; index1 < width; ++index1)
        {
          int index2 = num1 + index1 * 3;
          int index3 = (num2 * width + index1) * 4;
          imageData[index3] = imageArray[index2 + 2];
          imageData[index3 + 1] = imageArray[index2 + 1];
          imageData[index3 + 2] = imageArray[index2];
          imageData[index3 + 3] = byte.MaxValue;
        }
      }
    }

    private void ReadRgb32(byte[] imageData, int width, int height)
    {
      int alignment = 0;
      byte[] imageArray = this.GetImageArray(width, height, 4, ref alignment);
      for (int y = 0; y < height; ++y)
      {
        int num1 = y * (width * 4 + alignment);
        int num2 = BmpDecoder.Invert(y, height);
        for (int index1 = 0; index1 < width; ++index1)
        {
          int index2 = num1 + index1 * 4;
          int index3 = (num2 * width + index1) * 4;
          imageData[index3] = imageArray[index2];
          imageData[index3 + 1] = imageArray[index2 + 1];
          imageData[index3 + 2] = imageArray[index2 + 2];
          imageData[index3 + 3] = byte.MaxValue;
        }
      }
    }

    private static int Invert(int y, int height) => height <= 0 ? y : height - y - 1;

    private byte[] GetImageArray(int width, int height, int bytes, ref int alignment)
    {
      int num = width;
      alignment = width * bytes % 4;
      if (alignment != 0)
        alignment = 4 - alignment;
      int count = (num * bytes + alignment) * height;
      byte[] buffer = new byte[count];
      this._stream.Read(buffer, 0, count);
      return buffer;
    }

    private void ReadInfoHeader()
    {
      byte[] buffer = new byte[40];
      this._stream.Read(buffer, 0, 40);
      this._infoHeader = new BmpInfoHeader();
      this._infoHeader.HeaderSize = BitConverter.ToInt32(buffer, 0);
      this._infoHeader.Width = BitConverter.ToInt32(buffer, 4);
      this._infoHeader.Height = BitConverter.ToInt32(buffer, 8);
      this._infoHeader.Planes = BitConverter.ToInt16(buffer, 12);
      this._infoHeader.BitsPerPixel = BitConverter.ToInt16(buffer, 14);
      this._infoHeader.ImageSize = BitConverter.ToInt32(buffer, 20);
      this._infoHeader.XPelsPerMeter = BitConverter.ToInt32(buffer, 24);
      this._infoHeader.YPelsPerMeter = BitConverter.ToInt32(buffer, 28);
      this._infoHeader.ClrUsed = BitConverter.ToInt32(buffer, 32);
      this._infoHeader.ClrImportant = BitConverter.ToInt32(buffer, 36);
      this._infoHeader.Compression = (BmpCompression) BitConverter.ToInt32(buffer, 16);
    }

    private void ReadFileHeader()
    {
      byte[] buffer = new byte[14];
      this._stream.Read(buffer, 0, 14);
      this._fileHeader = new BmpFileHeader();
      this._fileHeader.Type = BitConverter.ToInt16(buffer, 0);
      this._fileHeader.FileSize = BitConverter.ToInt32(buffer, 2);
      this._fileHeader.Reserved = BitConverter.ToInt32(buffer, 6);
      this._fileHeader.Offset = BitConverter.ToInt32(buffer, 10);
    }
  }
}
