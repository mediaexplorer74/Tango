// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.FileOptions
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public sealed class FileOptions : ExtendableMessage<FileOptions, FileOptions.Builder>
  {
    public const int JavaPackageFieldNumber = 1;
    public const int JavaOuterClassnameFieldNumber = 8;
    public const int JavaMultipleFilesFieldNumber = 10;
    public const int OptimizeForFieldNumber = 9;
    public const int CcGenericServicesFieldNumber = 16;
    public const int JavaGenericServicesFieldNumber = 17;
    public const int PyGenericServicesFieldNumber = 18;
    public const int UninterpretedOptionFieldNumber = 999;
    private static readonly FileOptions defaultInstance = new FileOptions.Builder().BuildPartial();
    private bool hasJavaPackage;
    private string javaPackage_ = "";
    private bool hasJavaOuterClassname;
    private string javaOuterClassname_ = "";
    private bool hasJavaMultipleFiles;
    private bool javaMultipleFiles_;
    private bool hasOptimizeFor;
    private FileOptions.Types.OptimizeMode optimizeFor_ = FileOptions.Types.OptimizeMode.SPEED;
    private bool hasCcGenericServices;
    private bool ccGenericServices_ = true;
    private bool hasJavaGenericServices;
    private bool javaGenericServices_ = true;
    private bool hasPyGenericServices;
    private bool pyGenericServices_ = true;
    private PopsicleList<UninterpretedOption> uninterpretedOption_ = new PopsicleList<UninterpretedOption>();
    private int memoizedSerializedSize = -1;

    public static FileOptions DefaultInstance => FileOptions.defaultInstance;

    public override FileOptions DefaultInstanceForType => FileOptions.defaultInstance;

    protected override FileOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FileOptions__Descriptor;
    }

    protected override FieldAccessorTable<FileOptions, FileOptions.Builder> InternalFieldAccessors
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FileOptions__FieldAccessorTable;
    }

    public bool HasJavaPackage => this.hasJavaPackage;

    public string JavaPackage => this.javaPackage_;

    public bool HasJavaOuterClassname => this.hasJavaOuterClassname;

    public string JavaOuterClassname => this.javaOuterClassname_;

    public bool HasJavaMultipleFiles => this.hasJavaMultipleFiles;

    public bool JavaMultipleFiles => this.javaMultipleFiles_;

    public bool HasOptimizeFor => this.hasOptimizeFor;

    public FileOptions.Types.OptimizeMode OptimizeFor => this.optimizeFor_;

    public bool HasCcGenericServices => this.hasCcGenericServices;

    public bool CcGenericServices => this.ccGenericServices_;

    public bool HasJavaGenericServices => this.hasJavaGenericServices;

    public bool JavaGenericServices => this.javaGenericServices_;

    public bool HasPyGenericServices => this.hasPyGenericServices;

    public bool PyGenericServices => this.pyGenericServices_;

    public IList<UninterpretedOption> UninterpretedOptionList
    {
      get => (IList<UninterpretedOption>) this.uninterpretedOption_;
    }

    public int UninterpretedOptionCount => this.uninterpretedOption_.Count;

    public UninterpretedOption GetUninterpretedOption(int index)
    {
      return this.uninterpretedOption_[index];
    }

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<UninterpretedOption, UninterpretedOption.Builder> uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
        {
          if (!uninterpretedOption.IsInitialized)
            return false;
        }
        return this.ExtensionsAreInitialized;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      ExtendableMessage<FileOptions, FileOptions.Builder>.ExtensionWriter extensionWriter = this.CreateExtensionWriter((ExtendableMessage<FileOptions, FileOptions.Builder>) this);
      if (this.HasJavaPackage)
        output.WriteString(1, this.JavaPackage);
      if (this.HasJavaOuterClassname)
        output.WriteString(8, this.JavaOuterClassname);
      if (this.HasOptimizeFor)
        output.WriteEnum(9, (int) this.OptimizeFor);
      if (this.HasJavaMultipleFiles)
        output.WriteBool(10, this.JavaMultipleFiles);
      if (this.HasCcGenericServices)
        output.WriteBool(16, this.CcGenericServices);
      if (this.HasJavaGenericServices)
        output.WriteBool(17, this.JavaGenericServices);
      if (this.HasPyGenericServices)
        output.WriteBool(18, this.PyGenericServices);
      foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
        output.WriteMessage(999, (IMessageLite) uninterpretedOption);
      extensionWriter.WriteUntil(536870912, output);
      this.UnknownFields.WriteTo(output);
    }

    public override int SerializedSize
    {
      get
      {
        int memoizedSerializedSize = this.memoizedSerializedSize;
        if (memoizedSerializedSize != -1)
          return memoizedSerializedSize;
        int num = 0;
        if (this.HasJavaPackage)
          num += CodedOutputStream.ComputeStringSize(1, this.JavaPackage);
        if (this.HasJavaOuterClassname)
          num += CodedOutputStream.ComputeStringSize(8, this.JavaOuterClassname);
        if (this.HasJavaMultipleFiles)
          num += CodedOutputStream.ComputeBoolSize(10, this.JavaMultipleFiles);
        if (this.HasOptimizeFor)
          num += CodedOutputStream.ComputeEnumSize(9, (int) this.OptimizeFor);
        if (this.HasCcGenericServices)
          num += CodedOutputStream.ComputeBoolSize(16, this.CcGenericServices);
        if (this.HasJavaGenericServices)
          num += CodedOutputStream.ComputeBoolSize(17, this.JavaGenericServices);
        if (this.HasPyGenericServices)
          num += CodedOutputStream.ComputeBoolSize(18, this.PyGenericServices);
        foreach (UninterpretedOption uninterpretedOption in (IEnumerable<UninterpretedOption>) this.UninterpretedOptionList)
          num += CodedOutputStream.ComputeMessageSize(999, (IMessageLite) uninterpretedOption);
        int serializedSize = num + this.ExtensionsSerializedSize + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static FileOptions ParseFrom(ByteString data)
    {
      return FileOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return FileOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileOptions ParseFrom(byte[] data)
    {
      return FileOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return FileOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileOptions ParseFrom(Stream input)
    {
      return FileOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FileOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileOptions ParseDelimitedFrom(Stream input)
    {
      return FileOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static FileOptions ParseDelimitedFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FileOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileOptions ParseFrom(CodedInputStream input)
    {
      return FileOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileOptions ParseFrom(CodedInputStream input, ExtensionRegistry extensionRegistry)
    {
      return FileOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileOptions.Builder CreateBuilder() => new FileOptions.Builder();

    public override FileOptions.Builder ToBuilder() => FileOptions.CreateBuilder(this);

    public override FileOptions.Builder CreateBuilderForType() => new FileOptions.Builder();

    public static FileOptions.Builder CreateBuilder(FileOptions prototype)
    {
      return new FileOptions.Builder().MergeFrom(prototype);
    }

    static FileOptions()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public static class Types
    {
      public enum OptimizeMode
      {
        SPEED = 1,
        CODE_SIZE = 2,
        LITE_RUNTIME = 3,
      }
    }

    public sealed class Builder : ExtendableBuilder<FileOptions, FileOptions.Builder>
    {
      private FileOptions result = new FileOptions();

      protected override FileOptions.Builder ThisBuilder => this;

      protected override FileOptions MessageBeingBuilt => this.result;

      public override FileOptions.Builder Clear()
      {
        this.result = new FileOptions();
        return this;
      }

      public override FileOptions.Builder Clone()
      {
        return new FileOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => FileOptions.Descriptor;

      public override FileOptions DefaultInstanceForType => FileOptions.DefaultInstance;

      public override FileOptions BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.uninterpretedOption_.MakeReadOnly();
        FileOptions result = this.result;
        this.result = (FileOptions) null;
        return result;
      }

      public override FileOptions.Builder MergeFrom(IMessage other)
      {
        if (other is FileOptions)
          return this.MergeFrom((FileOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override FileOptions.Builder MergeFrom(FileOptions other)
      {
        if (other == FileOptions.DefaultInstance)
          return this;
        if (other.HasJavaPackage)
          this.JavaPackage = other.JavaPackage;
        if (other.HasJavaOuterClassname)
          this.JavaOuterClassname = other.JavaOuterClassname;
        if (other.HasJavaMultipleFiles)
          this.JavaMultipleFiles = other.JavaMultipleFiles;
        if (other.HasOptimizeFor)
          this.OptimizeFor = other.OptimizeFor;
        if (other.HasCcGenericServices)
          this.CcGenericServices = other.CcGenericServices;
        if (other.HasJavaGenericServices)
          this.JavaGenericServices = other.JavaGenericServices;
        if (other.HasPyGenericServices)
          this.PyGenericServices = other.PyGenericServices;
        if (other.uninterpretedOption_.Count != 0)
          this.AddRange<UninterpretedOption>((IEnumerable<UninterpretedOption>) other.uninterpretedOption_, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        this.MergeExtensionFields((ExtendableMessage<FileOptions, FileOptions.Builder>) other);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override FileOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override FileOptions.Builder MergeFrom(
        CodedInputStream input,
        ExtensionRegistry extensionRegistry)
      {
        UnknownFieldSet.Builder unknownFields = (UnknownFieldSet.Builder) null;
        while (true)
        {
          uint tag = input.ReadTag();
          switch (tag)
          {
            case 0:
              goto label_2;
            case 10:
              this.JavaPackage = input.ReadString();
              continue;
            case 66:
              this.JavaOuterClassname = input.ReadString();
              continue;
            case 72:
              int num = input.ReadEnum();
              if (!Enum.IsDefined(typeof (FileOptions.Types.OptimizeMode), (object) num))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                unknownFields.MergeVarintField(9, (ulong) num);
                continue;
              }
              this.OptimizeFor = (FileOptions.Types.OptimizeMode) num;
              continue;
            case 80:
              this.JavaMultipleFiles = input.ReadBool();
              continue;
            case 128:
              this.CcGenericServices = input.ReadBool();
              continue;
            case 136:
              this.JavaGenericServices = input.ReadBool();
              continue;
            case 144:
              this.PyGenericServices = input.ReadBool();
              continue;
            case 7994:
              UninterpretedOption.Builder builder = UninterpretedOption.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder, extensionRegistry);
              this.AddUninterpretedOption(builder.BuildPartial());
              continue;
            default:
              if (!WireFormat.IsEndGroupTag(tag))
              {
                if (unknownFields == null)
                  unknownFields = UnknownFieldSet.CreateBuilder(this.UnknownFields);
                this.ParseUnknownField(input, unknownFields, extensionRegistry, tag);
                continue;
              }
              goto label_6;
          }
        }
label_2:
        if (unknownFields != null)
          this.UnknownFields = unknownFields.Build();
        return this;
label_6:
        if (unknownFields != null)
          this.UnknownFields = unknownFields.Build();
        return this;
      }

      public bool HasJavaPackage => this.result.HasJavaPackage;

      public string JavaPackage
      {
        get => this.result.JavaPackage;
        set => this.SetJavaPackage(value);
      }

      public FileOptions.Builder SetJavaPackage(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasJavaPackage = true;
        this.result.javaPackage_ = value;
        return this;
      }

      public FileOptions.Builder ClearJavaPackage()
      {
        this.result.hasJavaPackage = false;
        this.result.javaPackage_ = "";
        return this;
      }

      public bool HasJavaOuterClassname => this.result.HasJavaOuterClassname;

      public string JavaOuterClassname
      {
        get => this.result.JavaOuterClassname;
        set => this.SetJavaOuterClassname(value);
      }

      public FileOptions.Builder SetJavaOuterClassname(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasJavaOuterClassname = true;
        this.result.javaOuterClassname_ = value;
        return this;
      }

      public FileOptions.Builder ClearJavaOuterClassname()
      {
        this.result.hasJavaOuterClassname = false;
        this.result.javaOuterClassname_ = "";
        return this;
      }

      public bool HasJavaMultipleFiles => this.result.HasJavaMultipleFiles;

      public bool JavaMultipleFiles
      {
        get => this.result.JavaMultipleFiles;
        set => this.SetJavaMultipleFiles(value);
      }

      public FileOptions.Builder SetJavaMultipleFiles(bool value)
      {
        this.result.hasJavaMultipleFiles = true;
        this.result.javaMultipleFiles_ = value;
        return this;
      }

      public FileOptions.Builder ClearJavaMultipleFiles()
      {
        this.result.hasJavaMultipleFiles = false;
        this.result.javaMultipleFiles_ = false;
        return this;
      }

      public bool HasOptimizeFor => this.result.HasOptimizeFor;

      public FileOptions.Types.OptimizeMode OptimizeFor
      {
        get => this.result.OptimizeFor;
        set => this.SetOptimizeFor(value);
      }

      public FileOptions.Builder SetOptimizeFor(FileOptions.Types.OptimizeMode value)
      {
        this.result.hasOptimizeFor = true;
        this.result.optimizeFor_ = value;
        return this;
      }

      public FileOptions.Builder ClearOptimizeFor()
      {
        this.result.hasOptimizeFor = false;
        this.result.optimizeFor_ = FileOptions.Types.OptimizeMode.SPEED;
        return this;
      }

      public bool HasCcGenericServices => this.result.HasCcGenericServices;

      public bool CcGenericServices
      {
        get => this.result.CcGenericServices;
        set => this.SetCcGenericServices(value);
      }

      public FileOptions.Builder SetCcGenericServices(bool value)
      {
        this.result.hasCcGenericServices = true;
        this.result.ccGenericServices_ = value;
        return this;
      }

      public FileOptions.Builder ClearCcGenericServices()
      {
        this.result.hasCcGenericServices = false;
        this.result.ccGenericServices_ = true;
        return this;
      }

      public bool HasJavaGenericServices => this.result.HasJavaGenericServices;

      public bool JavaGenericServices
      {
        get => this.result.JavaGenericServices;
        set => this.SetJavaGenericServices(value);
      }

      public FileOptions.Builder SetJavaGenericServices(bool value)
      {
        this.result.hasJavaGenericServices = true;
        this.result.javaGenericServices_ = value;
        return this;
      }

      public FileOptions.Builder ClearJavaGenericServices()
      {
        this.result.hasJavaGenericServices = false;
        this.result.javaGenericServices_ = true;
        return this;
      }

      public bool HasPyGenericServices => this.result.HasPyGenericServices;

      public bool PyGenericServices
      {
        get => this.result.PyGenericServices;
        set => this.SetPyGenericServices(value);
      }

      public FileOptions.Builder SetPyGenericServices(bool value)
      {
        this.result.hasPyGenericServices = true;
        this.result.pyGenericServices_ = value;
        return this;
      }

      public FileOptions.Builder ClearPyGenericServices()
      {
        this.result.hasPyGenericServices = false;
        this.result.pyGenericServices_ = true;
        return this;
      }

      public IPopsicleList<UninterpretedOption> UninterpretedOptionList
      {
        get => (IPopsicleList<UninterpretedOption>) this.result.uninterpretedOption_;
      }

      public int UninterpretedOptionCount => this.result.UninterpretedOptionCount;

      public UninterpretedOption GetUninterpretedOption(int index)
      {
        return this.result.GetUninterpretedOption(index);
      }

      public FileOptions.Builder SetUninterpretedOption(int index, UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_[index] = value;
        return this;
      }

      public FileOptions.Builder SetUninterpretedOption(
        int index,
        UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_[index] = builderForValue.Build();
        return this;
      }

      public FileOptions.Builder AddUninterpretedOption(UninterpretedOption value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.uninterpretedOption_.Add(value);
        return this;
      }

      public FileOptions.Builder AddUninterpretedOption(UninterpretedOption.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.uninterpretedOption_.Add(builderForValue.Build());
        return this;
      }

      public FileOptions.Builder AddRangeUninterpretedOption(IEnumerable<UninterpretedOption> values)
      {
        this.AddRange<UninterpretedOption>(values, (IList<UninterpretedOption>) this.result.uninterpretedOption_);
        return this;
      }

      public FileOptions.Builder ClearUninterpretedOption()
      {
        this.result.uninterpretedOption_.Clear();
        return this;
      }
    }
  }
}
