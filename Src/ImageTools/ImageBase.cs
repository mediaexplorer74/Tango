// Decompiled with JetBrains decompiler
// Type: ImageTools.ImageBase
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using ImageTools.Helpers;
using System;
using System.Diagnostics.Contracts;
//using System.Windows.Media;
using Windows.UI;

#nullable disable
namespace ImageTools
{
  [ContractVerification(false)]
  public class ImageBase
  {
    public const int DefaultDelayTime = 10;
    private int _delayTime;
    private bool _isFilled;
    private byte[] _pixels;
    private int _pixelHeight;
    private int _pixelWidth;

    internal static void Transform(
      ImageBase source,
      ImageBase target,
      RotationType rotationType,
      FlippingType flippingType)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(target != null, "Target image cannot be null.");
      switch (rotationType)
      {
        case RotationType.None:
          byte[] pixels = source.Pixels;
          byte[] numArray = new byte[pixels.Length];
          Array.Copy((Array) pixels, (Array) numArray, pixels.Length);
          target.SetPixels(source.PixelWidth, source.PixelHeight, numArray);
          break;
        case RotationType.Rotate90:
          ImageBase.Rotate90(source, target);
          break;
        case RotationType.Rotate180:
          ImageBase.Rotate180(source, target);
          break;
        case RotationType.Rotate270:
          ImageBase.Rotate270(source, target);
          break;
        default:
          throw new InvalidOperationException();
      }
      switch (flippingType)
      {
        case FlippingType.FlipX:
          ImageBase.FlipX(target);
          break;
        case FlippingType.FlipY:
          ImageBase.FlipY(target);
          break;
      }
    }

    private static void Rotate270(ImageBase source, ImageBase target)
    {
      Contract.Requires(source != null);
      Contract.Requires(source.IsFilled);
      Contract.Requires(target != null);
      Contract.Ensures(target.IsFilled);
      byte[] pixels1 = source.Pixels;
      byte[] pixels2 = new byte[source.PixelWidth * source.PixelHeight * 4];
      for (int index1 = 0; index1 < source.PixelHeight; ++index1)
      {
        for (int index2 = 0; index2 < source.PixelWidth; ++index2)
        {
          int index3 = (index1 * source.PixelWidth + index2) * 4;
          int index4 = ((source.PixelWidth - index2 - 1) * source.PixelHeight + index1) * 4;
          pixels2[index4] = pixels1[index3];
          pixels2[index4 + 1] = pixels1[index3 + 1];
          pixels2[index4 + 2] = pixels1[index3 + 2];
          pixels2[index4 + 3] = pixels1[index3 + 3];
        }
      }
      target.SetPixels(source.PixelHeight, source.PixelWidth, pixels2);
    }

    private static void Rotate180(ImageBase source, ImageBase target)
    {
      Contract.Requires(source != null);
      Contract.Requires(source.IsFilled);
      Contract.Requires(target != null);
      Contract.Ensures(target.IsFilled);
      byte[] pixels1 = source.Pixels;
      byte[] pixels2 = new byte[source.PixelWidth * source.PixelHeight * 4];
      for (int index1 = 0; index1 < source.PixelHeight; ++index1)
      {
        for (int index2 = 0; index2 < source.PixelWidth; ++index2)
        {
          int index3 = (index1 * source.PixelHeight + index2) * 4;
          int index4 = ((source.PixelHeight - index1 - 1) * source.PixelWidth + source.PixelWidth - index2 - 1) * 4;
          pixels2[index4] = pixels1[index3];
          pixels2[index4 + 1] = pixels1[index3 + 1];
          pixels2[index4 + 2] = pixels1[index3 + 2];
          pixels2[index4 + 3] = pixels1[index3 + 3];
        }
      }
      target.SetPixels(source.PixelWidth, source.PixelHeight, pixels2);
    }

    private static void Rotate90(ImageBase source, ImageBase target)
    {
      Contract.Requires(source != null);
      Contract.Requires(source.IsFilled);
      Contract.Requires(target != null);
      Contract.Ensures(target.IsFilled);
      byte[] pixels1 = source.Pixels;
      byte[] pixels2 = new byte[source.PixelWidth * source.PixelHeight * 4];
      for (int index1 = 0; index1 < source.PixelHeight; ++index1)
      {
        for (int index2 = 0; index2 < source.PixelWidth; ++index2)
        {
          int index3 = (index1 * source.PixelWidth + index2) * 4;
          int index4 = ((index2 + 1) * source.PixelHeight - index1 - 1) * 4;
          pixels2[index4] = pixels1[index3];
          pixels2[index4 + 1] = pixels1[index3 + 1];
          pixels2[index4 + 2] = pixels1[index3 + 2];
          pixels2[index4 + 3] = pixels1[index3 + 3];
        }
      }
      target.SetPixels(source.PixelHeight, source.PixelWidth, pixels2);
    }

    private static void FlipX(ImageBase image)
    {
      Contract.Requires<ArgumentNullException>(image != null, "Image cannot be null.");
      Contract.Requires<ArgumentException>(image.IsFilled, "Other image has not been loaded.");
      byte[] pixels = image.Pixels;
      for (int index1 = 0; index1 < image.PixelHeight / 2; ++index1)
      {
        for (int index2 = 0; index2 < image.PixelWidth; ++index2)
        {
          int index3 = (index1 * image.PixelWidth + index2) * 4;
          byte num1 = pixels[index3];
          byte num2 = pixels[index3 + 1];
          byte num3 = pixels[index3 + 2];
          byte num4 = pixels[index3 + 3];
          int index4 = ((image.PixelHeight - index1 - 1) * image.PixelWidth + index2) * 4;
          pixels[index3] = pixels[index4];
          pixels[index3 + 1] = pixels[index4 + 1];
          pixels[index3 + 2] = pixels[index4 + 2];
          pixels[index3 + 3] = pixels[index4 + 3];
          pixels[index4] = num1;
          pixels[index4 + 1] = num2;
          pixels[index4 + 2] = num3;
          pixels[index4 + 3] = num4;
        }
      }
    }

    private static void FlipY(ImageBase image)
    {
      Contract.Requires<ArgumentNullException>(image != null, "Image cannot be null.");
      Contract.Requires<ArgumentException>(image.IsFilled, "Other image has not been loaded.");
      byte[] pixels = image.Pixels;
      for (int index1 = 0; index1 < image.PixelHeight; ++index1)
      {
        for (int index2 = 0; index2 < image.PixelWidth / 2; ++index2)
        {
          int index3 = (index1 * image.PixelWidth + index2) * 4;
          byte num1 = pixels[index3];
          byte num2 = pixels[index3 + 1];
          byte num3 = pixels[index3 + 2];
          byte num4 = pixels[index3 + 3];
          int index4 = (index1 * image.PixelWidth + image.PixelWidth - index2 - 1) * 4;
          pixels[index3] = pixels[index4];
          pixels[index3 + 1] = pixels[index4 + 1];
          pixels[index3 + 2] = pixels[index4 + 2];
          pixels[index3 + 3] = pixels[index4 + 3];
          pixels[index4] = num1;
          pixels[index4 + 1] = num2;
          pixels[index4 + 2] = num3;
          pixels[index4 + 3] = num4;
        }
      }
    }

    [ContractVerification(false)]
    internal static void Crop(ImageBase source, ImageBase target, Rectangle bounds)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(target != null, "Target image cannot be null.");
      Guard.GreaterThan<int>(bounds.Width, 0, nameof (bounds), "Width of the rectangle must be greater than zero.");
      Guard.GreaterThan<int>(bounds.Height, 0, nameof (bounds), "Height of the rectangle must be greater than zero.");
      if (bounds.Right > source.PixelWidth || bounds.Bottom > source.PixelHeight)
        throw new ArgumentException("Rectangle must be in the range of the image's dimension.", nameof (bounds));
      byte[] pixels = source.Pixels;
      byte[] numArray = new byte[bounds.Width * bounds.Height * 4];
      int top = bounds.Top;
      int num = 0;
      while (top < bounds.Bottom)
      {
        Array.Copy((Array) pixels, (top * source.PixelWidth + bounds.Left) * 4, (Array) numArray, num * bounds.Width * 4, bounds.Width * 4);
        ++top;
        ++num;
      }
      target.SetPixels(bounds.Width, bounds.Height, numArray);
    }

    [Pure]
    public int DelayTime
    {
      get
      {
        int delayTime = this._delayTime;
        if (delayTime <= 0)
          delayTime = 10;
        return delayTime;
      }
      set => this._delayTime = value;
    }

    [Pure]
    public bool IsFilled => this._isFilled;

    [Pure]
    public byte[] Pixels
    {
      get
      {
        Contract.Ensures(!this.IsFilled || Contract.Result<byte[]>() != null);
        return this._pixels;
      }
    }

    public int PixelHeight
    {
      get
      {
        Contract.Ensures(!this.IsFilled || Contract.Result<int>() > 0);
        return this._pixelHeight;
      }
    }

    public int PixelWidth
    {
      get
      {
        Contract.Ensures(!this.IsFilled || Contract.Result<int>() > 0);
        return this._pixelWidth;
      }
    }

    public double PixelRatio
    {
      get
      {
        Contract.Ensures(!this.IsFilled || Contract.Result<double>() > 0.0);
        return this.IsFilled ? (double) this.PixelWidth / (double) this.PixelHeight : 0.0;
      }
    }

    [Pure]
    public Color this[int x, int y]
    {
      get
      {
        Contract.Requires<InvalidOperationException>(this.IsFilled, "Image is not loaded.");
        Contract.Requires<ArgumentException>(x >= 0 && x < this.PixelWidth, "X must be in the range of the image.");
        Contract.Requires<ArgumentException>(y >= 0 && y < this.PixelHeight, "Y must be in the range of the image.");
        Contract.Ensures(this.IsFilled);
        int index = (y * this.PixelWidth + x) * 4;
        return Windows.UI.Color.FromArgb((byte) this._pixels[index + 3], (byte) this._pixels[index], (byte) this._pixels[index + 1], (byte) this._pixels[index + 2]);
      }
      set
      {
        Contract.Requires<InvalidOperationException>(this.IsFilled, "Image is not loaded.");
        Contract.Requires<ArgumentException>(x >= 0 && x < this.PixelWidth, "X must be in the range of the image.");
        Contract.Requires<ArgumentException>(y >= 0 && y < this.PixelHeight, "Y must be in the range of the image.");
        Contract.Ensures(this.IsFilled);
        int index = (y * this.PixelWidth + x) * 4;
        this._pixels[index] = value.R;
        this._pixels[index + 1] = value.G;
        this._pixels[index + 2] = value.B;
        this._pixels[index + 3] = value.A;
      }
    }

    [Pure]
    public Rectangle Bounds => new Rectangle(0, 0, this.PixelWidth, this.PixelHeight);

    public ImageBase(int width, int height)
    {
      Contract.Requires<ArgumentException>(width >= 0, "Width must be greater or equals than zero.");
      Contract.Requires<ArgumentException>(height >= 0, "Height must be greater or equals than zero.");
      Contract.Ensures(this.IsFilled);
      this._pixelWidth = width;
      this._pixelHeight = height;
      this._pixels = new byte[this.PixelWidth * this.PixelHeight * 4];
      this._isFilled = true;
    }

    public ImageBase(ImageBase other)
    {
      Contract.Requires<ArgumentNullException>(other != null, "Other image cannot be null.");
      Contract.Requires<ArgumentException>(other.IsFilled, "Other image has not been loaded.");
      Contract.Ensures(this.IsFilled);
      byte[] pixels = other.Pixels;
      this._pixelWidth = other.PixelWidth;
      this._pixelHeight = other.PixelHeight;
      this._pixels = new byte[pixels.Length];
      Array.Copy((Array) pixels, (Array) this._pixels, pixels.Length);
      this._isFilled = other.IsFilled;
    }

    public ImageBase()
    {
    }

    public void SetPixels(int width, int height, byte[] pixels)
    {
      Contract.Requires<ArgumentException>(width >= 0, "Width must be greater than zero.");
      Contract.Requires<ArgumentException>(height >= 0, "Height must be greater than zero.");
      Contract.Requires<ArgumentNullException>(pixels != null, "Pixels cannot be null.");
      Contract.Ensures(this.IsFilled);
      if (pixels.Length != width * height * 4)
        throw new ArgumentException("Pixel array must have the length of width * height * 4.", nameof (pixels));
      this._pixelWidth = width;
      this._pixelHeight = height;
      this._pixels = pixels;
      this._isFilled = true;
    }
  }
}
