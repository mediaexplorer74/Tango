// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.GeneratedSingleExtension`1
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class GeneratedSingleExtension<TExtension> : GeneratedExtensionBase<TExtension>
  {
    internal GeneratedSingleExtension(FieldDescriptor descriptor)
      : base(descriptor, typeof (TExtension))
    {
    }

    public static GeneratedSingleExtension<TExtension> CreateInstance(FieldDescriptor descriptor)
    {
      return !descriptor.IsRepeated ? new GeneratedSingleExtension<TExtension>(descriptor) : throw new ArgumentException("Must call GeneratedRepeateExtension.CreateInstance() for repeated types.");
    }

    public override object FromReflectionType(object value)
    {
      return this.SingularFromReflectionType(value);
    }
  }
}
