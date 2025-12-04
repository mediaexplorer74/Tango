// Decompiled with JetBrains decompiler
// Type: ImageTools.Rectangle
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;

#nullable disable
namespace ImageTools
{
  public struct Rectangle(int x, int y, int width, int height) : IEquatable<Rectangle>
  {
    public static readonly Rectangle Zero = new Rectangle(0, 0, 0, 0);
    private int _height = height;
    private int _width = width;
    private int _x = x;
    private int _y = y;

    public int Bottom => this._y + this._height;

    public int Height
    {
      get => this._height;
      set => this._height = value;
    }

    public int Left => this._x;

    public int Right => this._x + this._width;

    public int Top => this._y;

    public int Width
    {
      get => this._width;
      set => this._width = value;
    }

    public int X
    {
      get => this._x;
      set => this._x = value;
    }

    public int Y
    {
      get => this._y;
      set => this._y = value;
    }

    public Rectangle(Rectangle other)
      : this(other.X, other.Y, other.Width, other.Height)
    {
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      bool flag = false;
      if (obj is Rectangle other)
        flag = this.Equals(other);
      return flag;
    }

    public bool Equals(Rectangle other)
    {
      return this._x == other._x && this._y == other._y && this._width == other._width && this._height == other._height;
    }

    public override int GetHashCode() => this.X ^ this.Y ^ this.Width ^ this.Height;

    public static bool operator ==(Rectangle left, Rectangle right) => left.Equals(right);

    public static bool operator !=(Rectangle left, Rectangle right) => !left.Equals(right);
  }
}
