// Decompiled with JetBrains decompiler
// Type: ImageTools.ImageProperty
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using System;
using System.Diagnostics.Contracts;

#nullable disable
namespace ImageTools
{
  public sealed class ImageProperty : IEquatable<ImageProperty>
  {
    private string _name;

    public string Name
    {
      get
      {
        Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
        return this._name;
      }
    }

    public string Value { get; set; }

    public ImageProperty(string name, string value)
    {
      Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(name), "Name cannot be null or empty.");
      this._name = name;
      this.Value = value;
    }

    public override bool Equals(object obj) => obj != null && this.Equals(obj as ImageProperty);

    public bool Equals(ImageProperty other)
    {
      return other != null && object.Equals((object) this.Name, (object) other.Name) && object.Equals((object) this.Value, (object) other.Value);
    }

    public override int GetHashCode()
    {
      int hashCode = 1;
      if (this.Name != null)
        hashCode ^= this.Name.GetHashCode();
      if (this.Value != null)
        hashCode ^= this.Value.GetHashCode();
      return hashCode;
    }
  }
}
