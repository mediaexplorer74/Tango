// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.FileDescriptorProto
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
  public sealed class FileDescriptorProto : 
    GeneratedMessage<FileDescriptorProto, FileDescriptorProto.Builder>,
    IDescriptorProto<FileOptions>
  {
    public const int NameFieldNumber = 1;
    public const int PackageFieldNumber = 2;
    public const int DependencyFieldNumber = 3;
    public const int MessageTypeFieldNumber = 4;
    public const int EnumTypeFieldNumber = 5;
    public const int ServiceFieldNumber = 6;
    public const int ExtensionFieldNumber = 7;
    public const int OptionsFieldNumber = 8;
    private static readonly FileDescriptorProto defaultInstance = new FileDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private bool hasPackage;
    private string package_ = "";
    private PopsicleList<string> dependency_ = new PopsicleList<string>();
    private PopsicleList<DescriptorProto> messageType_ = new PopsicleList<DescriptorProto>();
    private PopsicleList<EnumDescriptorProto> enumType_ = new PopsicleList<EnumDescriptorProto>();
    private PopsicleList<ServiceDescriptorProto> service_ = new PopsicleList<ServiceDescriptorProto>();
    private PopsicleList<FieldDescriptorProto> extension_ = new PopsicleList<FieldDescriptorProto>();
    private bool hasOptions;
    private FileOptions options_ = FileOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static FileDescriptorProto DefaultInstance => FileDescriptorProto.defaultInstance;

    public override FileDescriptorProto DefaultInstanceForType
    {
      get => FileDescriptorProto.defaultInstance;
    }

    protected override FileDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FileDescriptorProto__Descriptor;
    }

    protected override FieldAccessorTable<FileDescriptorProto, FileDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_FileDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public bool HasPackage => this.hasPackage;

    public string Package => this.package_;

    public IList<string> DependencyList
    {
      get => Lists.AsReadOnly<string>((IList<string>) this.dependency_);
    }

    public int DependencyCount => this.dependency_.Count;

    public string GetDependency(int index) => this.dependency_[index];

    public IList<DescriptorProto> MessageTypeList => (IList<DescriptorProto>) this.messageType_;

    public int MessageTypeCount => this.messageType_.Count;

    public DescriptorProto GetMessageType(int index) => this.messageType_[index];

    public IList<EnumDescriptorProto> EnumTypeList => (IList<EnumDescriptorProto>) this.enumType_;

    public int EnumTypeCount => this.enumType_.Count;

    public EnumDescriptorProto GetEnumType(int index) => this.enumType_[index];

    public IList<ServiceDescriptorProto> ServiceList
    {
      get => (IList<ServiceDescriptorProto>) this.service_;
    }

    public int ServiceCount => this.service_.Count;

    public ServiceDescriptorProto GetService(int index) => this.service_[index];

    public IList<FieldDescriptorProto> ExtensionList
    {
      get => (IList<FieldDescriptorProto>) this.extension_;
    }

    public int ExtensionCount => this.extension_.Count;

    public FieldDescriptorProto GetExtension(int index) => this.extension_[index];

    public bool HasOptions => this.hasOptions;

    public FileOptions Options => this.options_;

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<DescriptorProto, DescriptorProto.Builder> messageType in (IEnumerable<DescriptorProto>) this.MessageTypeList)
        {
          if (!messageType.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<EnumDescriptorProto, EnumDescriptorProto.Builder> enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
        {
          if (!enumType.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<ServiceDescriptorProto, ServiceDescriptorProto.Builder> service in (IEnumerable<ServiceDescriptorProto>) this.ServiceList)
        {
          if (!service.IsInitialized)
            return false;
        }
        foreach (AbstractMessageLite<FieldDescriptorProto, FieldDescriptorProto.Builder> extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
        {
          if (!extension.IsInitialized)
            return false;
        }
        return !this.HasOptions || this.Options.IsInitialized;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasName)
        output.WriteString(1, this.Name);
      if (this.HasPackage)
        output.WriteString(2, this.Package);
      if (this.dependency_.Count > 0)
      {
        foreach (string str in this.dependency_)
          output.WriteString(3, str);
      }
      foreach (DescriptorProto messageType in (IEnumerable<DescriptorProto>) this.MessageTypeList)
        output.WriteMessage(4, (IMessageLite) messageType);
      foreach (EnumDescriptorProto enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
        output.WriteMessage(5, (IMessageLite) enumType);
      foreach (ServiceDescriptorProto service in (IEnumerable<ServiceDescriptorProto>) this.ServiceList)
        output.WriteMessage(6, (IMessageLite) service);
      foreach (FieldDescriptorProto extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
        output.WriteMessage(7, (IMessageLite) extension);
      if (this.HasOptions)
        output.WriteMessage(8, (IMessageLite) this.Options);
      this.UnknownFields.WriteTo(output);
    }

    public override int SerializedSize
    {
      get
      {
        int memoizedSerializedSize = this.memoizedSerializedSize;
        if (memoizedSerializedSize != -1)
          return memoizedSerializedSize;
        int num1 = 0;
        if (this.HasName)
          num1 += CodedOutputStream.ComputeStringSize(1, this.Name);
        if (this.HasPackage)
          num1 += CodedOutputStream.ComputeStringSize(2, this.Package);
        int num2 = 0;
        foreach (string dependency in (IEnumerable<string>) this.DependencyList)
          num2 += CodedOutputStream.ComputeStringSizeNoTag(dependency);
        int num3 = num1 + num2 + this.dependency_.Count;
        foreach (DescriptorProto messageType in (IEnumerable<DescriptorProto>) this.MessageTypeList)
          num3 += CodedOutputStream.ComputeMessageSize(4, (IMessageLite) messageType);
        foreach (EnumDescriptorProto enumType in (IEnumerable<EnumDescriptorProto>) this.EnumTypeList)
          num3 += CodedOutputStream.ComputeMessageSize(5, (IMessageLite) enumType);
        foreach (ServiceDescriptorProto service in (IEnumerable<ServiceDescriptorProto>) this.ServiceList)
          num3 += CodedOutputStream.ComputeMessageSize(6, (IMessageLite) service);
        foreach (FieldDescriptorProto extension in (IEnumerable<FieldDescriptorProto>) this.ExtensionList)
          num3 += CodedOutputStream.ComputeMessageSize(7, (IMessageLite) extension);
        if (this.HasOptions)
          num3 += CodedOutputStream.ComputeMessageSize(8, (IMessageLite) this.Options);
        int serializedSize = num3 + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static FileDescriptorProto ParseFrom(ByteString data)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(byte[] data)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(Stream input)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return FileDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static FileDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(CodedInputStream input)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorProto.Builder CreateBuilder() => new FileDescriptorProto.Builder();

    public override FileDescriptorProto.Builder ToBuilder()
    {
      return FileDescriptorProto.CreateBuilder(this);
    }

    public override FileDescriptorProto.Builder CreateBuilderForType()
    {
      return new FileDescriptorProto.Builder();
    }

    public static FileDescriptorProto.Builder CreateBuilder(FileDescriptorProto prototype)
    {
      return new FileDescriptorProto.Builder().MergeFrom(prototype);
    }

    static FileDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : GeneratedBuilder<FileDescriptorProto, FileDescriptorProto.Builder>
    {
      private FileDescriptorProto result = new FileDescriptorProto();

      protected override FileDescriptorProto.Builder ThisBuilder => this;

      protected override FileDescriptorProto MessageBeingBuilt => this.result;

      public override FileDescriptorProto.Builder Clear()
      {
        this.result = new FileDescriptorProto();
        return this;
      }

      public override FileDescriptorProto.Builder Clone()
      {
        return new FileDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => FileDescriptorProto.Descriptor;

      public override FileDescriptorProto DefaultInstanceForType
      {
        get => FileDescriptorProto.DefaultInstance;
      }

      public override FileDescriptorProto BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.dependency_.MakeReadOnly();
        this.result.messageType_.MakeReadOnly();
        this.result.enumType_.MakeReadOnly();
        this.result.service_.MakeReadOnly();
        this.result.extension_.MakeReadOnly();
        FileDescriptorProto result = this.result;
        this.result = (FileDescriptorProto) null;
        return result;
      }

      public override FileDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is FileDescriptorProto)
          return this.MergeFrom((FileDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override FileDescriptorProto.Builder MergeFrom(FileDescriptorProto other)
      {
        if (other == FileDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.HasPackage)
          this.Package = other.Package;
        if (other.dependency_.Count != 0)
          this.AddRange<string>((IEnumerable<string>) other.dependency_, (IList<string>) this.result.dependency_);
        if (other.messageType_.Count != 0)
          this.AddRange<DescriptorProto>((IEnumerable<DescriptorProto>) other.messageType_, (IList<DescriptorProto>) this.result.messageType_);
        if (other.enumType_.Count != 0)
          this.AddRange<EnumDescriptorProto>((IEnumerable<EnumDescriptorProto>) other.enumType_, (IList<EnumDescriptorProto>) this.result.enumType_);
        if (other.service_.Count != 0)
          this.AddRange<ServiceDescriptorProto>((IEnumerable<ServiceDescriptorProto>) other.service_, (IList<ServiceDescriptorProto>) this.result.service_);
        if (other.extension_.Count != 0)
          this.AddRange<FieldDescriptorProto>((IEnumerable<FieldDescriptorProto>) other.extension_, (IList<FieldDescriptorProto>) this.result.extension_);
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override FileDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override FileDescriptorProto.Builder MergeFrom(
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
              this.Name = input.ReadString();
              continue;
            case 18:
              this.Package = input.ReadString();
              continue;
            case 26:
              this.AddDependency(input.ReadString());
              continue;
            case 34:
              DescriptorProto.Builder builder1 = DescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder1, extensionRegistry);
              this.AddMessageType(builder1.BuildPartial());
              continue;
            case 42:
              EnumDescriptorProto.Builder builder2 = EnumDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder2, extensionRegistry);
              this.AddEnumType(builder2.BuildPartial());
              continue;
            case 50:
              ServiceDescriptorProto.Builder builder3 = ServiceDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder3, extensionRegistry);
              this.AddService(builder3.BuildPartial());
              continue;
            case 58:
              FieldDescriptorProto.Builder builder4 = FieldDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder4, extensionRegistry);
              this.AddExtension(builder4.BuildPartial());
              continue;
            case 66:
              FileOptions.Builder builder5 = FileOptions.CreateBuilder();
              if (this.HasOptions)
                builder5.MergeFrom(this.Options);
              input.ReadMessage((IBuilderLite) builder5, extensionRegistry);
              this.Options = builder5.BuildPartial();
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

      public bool HasName => this.result.HasName;

      public string Name
      {
        get => this.result.Name;
        set => this.SetName(value);
      }

      public FileDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public FileDescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public bool HasPackage => this.result.HasPackage;

      public string Package
      {
        get => this.result.Package;
        set => this.SetPackage(value);
      }

      public FileDescriptorProto.Builder SetPackage(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasPackage = true;
        this.result.package_ = value;
        return this;
      }

      public FileDescriptorProto.Builder ClearPackage()
      {
        this.result.hasPackage = false;
        this.result.package_ = "";
        return this;
      }

      public IPopsicleList<string> DependencyList
      {
        get => (IPopsicleList<string>) this.result.dependency_;
      }

      public int DependencyCount => this.result.DependencyCount;

      public string GetDependency(int index) => this.result.GetDependency(index);

      public FileDescriptorProto.Builder SetDependency(int index, string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.dependency_[index] = value;
        return this;
      }

      public FileDescriptorProto.Builder AddDependency(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.dependency_.Add(value);
        return this;
      }

      public FileDescriptorProto.Builder AddRangeDependency(IEnumerable<string> values)
      {
        this.AddRange<string>(values, (IList<string>) this.result.dependency_);
        return this;
      }

      public FileDescriptorProto.Builder ClearDependency()
      {
        this.result.dependency_.Clear();
        return this;
      }

      public IPopsicleList<DescriptorProto> MessageTypeList
      {
        get => (IPopsicleList<DescriptorProto>) this.result.messageType_;
      }

      public int MessageTypeCount => this.result.MessageTypeCount;

      public DescriptorProto GetMessageType(int index) => this.result.GetMessageType(index);

      public FileDescriptorProto.Builder SetMessageType(int index, DescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.messageType_[index] = value;
        return this;
      }

      public FileDescriptorProto.Builder SetMessageType(
        int index,
        DescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.messageType_[index] = builderForValue.Build();
        return this;
      }

      public FileDescriptorProto.Builder AddMessageType(DescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.messageType_.Add(value);
        return this;
      }

      public FileDescriptorProto.Builder AddMessageType(DescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.messageType_.Add(builderForValue.Build());
        return this;
      }

      public FileDescriptorProto.Builder AddRangeMessageType(IEnumerable<DescriptorProto> values)
      {
        this.AddRange<DescriptorProto>(values, (IList<DescriptorProto>) this.result.messageType_);
        return this;
      }

      public FileDescriptorProto.Builder ClearMessageType()
      {
        this.result.messageType_.Clear();
        return this;
      }

      public IPopsicleList<EnumDescriptorProto> EnumTypeList
      {
        get => (IPopsicleList<EnumDescriptorProto>) this.result.enumType_;
      }

      public int EnumTypeCount => this.result.EnumTypeCount;

      public EnumDescriptorProto GetEnumType(int index) => this.result.GetEnumType(index);

      public FileDescriptorProto.Builder SetEnumType(int index, EnumDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.enumType_[index] = value;
        return this;
      }

      public FileDescriptorProto.Builder SetEnumType(
        int index,
        EnumDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.enumType_[index] = builderForValue.Build();
        return this;
      }

      public FileDescriptorProto.Builder AddEnumType(EnumDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.enumType_.Add(value);
        return this;
      }

      public FileDescriptorProto.Builder AddEnumType(EnumDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.enumType_.Add(builderForValue.Build());
        return this;
      }

      public FileDescriptorProto.Builder AddRangeEnumType(IEnumerable<EnumDescriptorProto> values)
      {
        this.AddRange<EnumDescriptorProto>(values, (IList<EnumDescriptorProto>) this.result.enumType_);
        return this;
      }

      public FileDescriptorProto.Builder ClearEnumType()
      {
        this.result.enumType_.Clear();
        return this;
      }

      public IPopsicleList<ServiceDescriptorProto> ServiceList
      {
        get => (IPopsicleList<ServiceDescriptorProto>) this.result.service_;
      }

      public int ServiceCount => this.result.ServiceCount;

      public ServiceDescriptorProto GetService(int index) => this.result.GetService(index);

      public FileDescriptorProto.Builder SetService(int index, ServiceDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.service_[index] = value;
        return this;
      }

      public FileDescriptorProto.Builder SetService(
        int index,
        ServiceDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.service_[index] = builderForValue.Build();
        return this;
      }

      public FileDescriptorProto.Builder AddService(ServiceDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.service_.Add(value);
        return this;
      }

      public FileDescriptorProto.Builder AddService(ServiceDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.service_.Add(builderForValue.Build());
        return this;
      }

      public FileDescriptorProto.Builder AddRangeService(IEnumerable<ServiceDescriptorProto> values)
      {
        this.AddRange<ServiceDescriptorProto>(values, (IList<ServiceDescriptorProto>) this.result.service_);
        return this;
      }

      public FileDescriptorProto.Builder ClearService()
      {
        this.result.service_.Clear();
        return this;
      }

      public IPopsicleList<FieldDescriptorProto> ExtensionList
      {
        get => (IPopsicleList<FieldDescriptorProto>) this.result.extension_;
      }

      public int ExtensionCount => this.result.ExtensionCount;

      public FieldDescriptorProto GetExtension(int index) => this.result.GetExtension(index);

      public FileDescriptorProto.Builder SetExtension(int index, FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extension_[index] = value;
        return this;
      }

      public FileDescriptorProto.Builder SetExtension(
        int index,
        FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extension_[index] = builderForValue.Build();
        return this;
      }

      public FileDescriptorProto.Builder AddExtension(FieldDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.extension_.Add(value);
        return this;
      }

      public FileDescriptorProto.Builder AddExtension(FieldDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.extension_.Add(builderForValue.Build());
        return this;
      }

      public FileDescriptorProto.Builder AddRangeExtension(IEnumerable<FieldDescriptorProto> values)
      {
        this.AddRange<FieldDescriptorProto>(values, (IList<FieldDescriptorProto>) this.result.extension_);
        return this;
      }

      public FileDescriptorProto.Builder ClearExtension()
      {
        this.result.extension_.Clear();
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public FileOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public FileDescriptorProto.Builder SetOptions(FileOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public FileDescriptorProto.Builder SetOptions(FileOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public FileDescriptorProto.Builder MergeOptions(FileOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == FileOptions.DefaultInstance ? value : FileOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public FileDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = FileOptions.DefaultInstance;
        return this;
      }
    }
  }
}
