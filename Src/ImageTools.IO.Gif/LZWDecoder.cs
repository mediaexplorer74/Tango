// Decompiled with JetBrains decompiler
// Type: ImageTools.IO.Gif.LZWDecoder
// Assembly: ImageTools.IO.Gif, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA7F4B99-2235-4710-895B-B5451D936C00
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.IO.Gif.dll

using ImageTools.Helpers;
using System;
using System.IO;

#nullable disable
namespace ImageTools.IO.Gif
{
  internal sealed class LZWDecoder
  {
    private const int StackSize = 4096;
    private const int NullCode = -1;
    private Stream _stream;

    public LZWDecoder(Stream stream)
    {
      Guard.NotNull((object) stream, nameof (stream));
      this._stream = stream;
    }

    public byte[] DecodePixels(int width, int height, int dataSize)
    {
      byte[] numArray1 = new byte[width * height];
      int num1 = 1 << dataSize;
      if (dataSize == int.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (dataSize), "Must be less than Int32.MaxValue");
      int num2 = dataSize + 1;
      int num3 = num1 + 1;
      int index1 = num1 + 2;
      int num4 = -1;
      int num5 = (1 << num2) - 1;
      int num6 = 0;
      int[] numArray2 = new int[4096];
      int[] numArray3 = new int[4096];
      int[] numArray4 = new int[4097];
      int index2 = 0;
      int num7 = 0;
      int index3 = 0;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      for (int index4 = 0; index4 < num1; ++index4)
      {
        numArray2[index4] = 0;
        numArray3[index4] = (int) (byte) index4;
      }
      byte[] numArray5 = (byte[]) null;
      while (num8 < numArray1.Length)
      {
        if (index2 == 0)
        {
          if (num6 < num2)
          {
            if (num7 == 0)
            {
              numArray5 = this.ReadBlock();
              num7 = numArray5.Length;
              if (num7 != 0)
                index3 = 0;
              else
                break;
            }
            num9 += (int) numArray5[index3] << num6;
            num6 += 8;
            ++index3;
            --num7;
            continue;
          }
          int index5 = num9 & num5;
          num9 >>= num2;
          num6 -= num2;
          if (index5 <= index1 && index5 != num3)
          {
            if (index5 == num1)
            {
              num2 = dataSize + 1;
              num5 = (1 << num2) - 1;
              index1 = num1 + 2;
              num4 = -1;
              continue;
            }
            if (num4 == -1)
            {
              numArray4[index2++] = numArray3[index5];
              num4 = index5;
              num10 = index5;
              continue;
            }
            int num11 = index5;
            if (index5 == index1)
            {
              numArray4[index2++] = (int) (byte) num10;
              index5 = num4;
            }
            for (; index5 > num1; index5 = numArray2[index5])
              numArray4[index2++] = numArray3[index5];
            num10 = numArray3[index5];
            if (index1 <= 4096)
            {
              numArray4[index2++] = numArray3[index5];
              numArray2[index1] = num4;
              numArray3[index1] = num10;
              ++index1;
              if (index1 == num5 + 1 && index1 < 4096)
              {
                ++num2;
                num5 = (1 << num2) - 1;
              }
              num4 = num11;
            }
            else
              break;
          }
          else
            break;
        }
        --index2;
        numArray1[num8++] = (byte) numArray4[index2];
      }
      return numArray1;
    }

    private byte[] ReadBlock() => this.ReadBytes(this._stream.ReadByte());

    private byte[] ReadBytes(int length)
    {
      byte[] buffer = new byte[length];
      this._stream.Read(buffer, 0, length);
      return buffer;
    }
  }
}
