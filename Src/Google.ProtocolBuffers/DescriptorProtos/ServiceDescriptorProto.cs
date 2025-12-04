// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.ServiceDescriptorProto
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
  public sealed class ServiceDescriptorProto : 
    GeneratedMessage<ServiceDescriptorProto, ServiceDescriptorProto.Builder>,
    IDescriptorProto<ServiceOptions>
  {
    public const int NameFieldNumber = 1;
    public const int MethodFieldNumber = 2;
    public const int OptionsFieldNumber = 3;
    private static readonly ServiceDescriptorProto defaultInstance = new ServiceDescriptorProto.Builder().BuildPartial();
    private bool hasName;
    private string name_ = "";
    private PopsicleList<MethodDescriptorProto> method_ = new PopsicleList<MethodDescriptorProto>();
    private bool hasOptions;
    private ServiceOptions options_ = ServiceOptions.DefaultInstance;
    private int memoizedSerializedSize = -1;

    public static ServiceDescriptorProto DefaultInstance => ServiceDescriptorProto.defaultInstance;

    public override ServiceDescriptorProto DefaultInstanceForType
    {
      get => ServiceDescriptorProto.defaultInstance;
    }

    protected override ServiceDescriptorProto ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_ServiceDescriptorProto__Descriptor;
      }
    }

    protected override FieldAccessorTable<ServiceDescriptorProto, ServiceDescriptorProto.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_ServiceDescriptorProto__FieldAccessorTable;
      }
    }

    public bool HasName => this.hasName;

    public string Name => this.name_;

    public IList<MethodDescriptorProto> MethodList => (IList<MethodDescriptorProto>) this.method_;

    public int MethodCount => this.method_.Count;

    public MethodDescriptorProto GetMethod(int index) => this.method_[index];

    public bool HasOptions => this.hasOptions;

    public ServiceOptions Options => this.options_;

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<MethodDescriptorProto, MethodDescriptorProto.Builder> method in (IEnumerable<MethodDescriptorProto>) this.MethodList)
        {
          if (!method.IsInitialized)
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
      foreach (MethodDescriptorProto method in (IEnumerable<MethodDescriptorProto>) this.MethodList)
        output.WriteMessage(2, (IMessageLite) method);
      if (this.HasOptions)
        output.WriteMessage(3, (IMessageLite) this.Options);
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
        if (this.HasName)
          num += CodedOutputStream.ComputeStringSize(1, this.Name);
        foreach (MethodDescriptorProto method in (IEnumerable<MethodDescriptorProto>) this.MethodList)
          num += CodedOutputStream.ComputeMessageSize(2, (IMessageLite) method);
        if (this.HasOptions)
          num += CodedOutputStream.ComputeMessageSize(3, (IMessageLite) this.Options);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static ServiceDescriptorProto ParseFrom(ByteString data)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(
      ByteString data,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(byte[] data)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(Stream input)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceDescriptorProto ParseDelimitedFrom(Stream input)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static ServiceDescriptorProto ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(CodedInputStream input)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static ServiceDescriptorProto ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return ServiceDescriptorProto.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static ServiceDescriptorProto.Builder CreateBuilder()
    {
      return new ServiceDescriptorProto.Builder();
    }

    public override ServiceDescriptorProto.Builder ToBuilder()
    {
      return ServiceDescriptorProto.CreateBuilder(this);
    }

    public override ServiceDescriptorProto.Builder CreateBuilderForType()
    {
      return new ServiceDescriptorProto.Builder();
    }

    public static ServiceDescriptorProto.Builder CreateBuilder(ServiceDescriptorProto prototype)
    {
      return new ServiceDescriptorProto.Builder().MergeFrom(prototype);
    }

    static ServiceDescriptorProto()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : 
      GeneratedBuilder<ServiceDescriptorProto, ServiceDescriptorProto.Builder>
    {
      private ServiceDescriptorProto result = new ServiceDescriptorProto();

      protected override ServiceDescriptorProto.Builder ThisBuilder => this;

      protected override ServiceDescriptorProto MessageBeingBuilt => this.result;

      public override ServiceDescriptorProto.Builder Clear()
      {
        this.result = new ServiceDescriptorProto();
        return this;
      }

      public override ServiceDescriptorProto.Builder Clone()
      {
        return new ServiceDescriptorProto.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => ServiceDescriptorProto.Descriptor;

      public override ServiceDescriptorProto DefaultInstanceForType
      {
        get => ServiceDescriptorProto.DefaultInstance;
      }

      public override ServiceDescriptorProto BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.method_.MakeReadOnly();
        ServiceDescriptorProto result = this.result;
        this.result = (ServiceDescriptorProto) null;
        return result;
      }

      public override ServiceDescriptorProto.Builder MergeFrom(IMessage other)
      {
        if (other is ServiceDescriptorProto)
          return this.MergeFrom((ServiceDescriptorProto) other);
        base.MergeFrom(other);
        return this;
      }

      public override ServiceDescriptorProto.Builder MergeFrom(ServiceDescriptorProto other)
      {
        if (other == ServiceDescriptorProto.DefaultInstance)
          return this;
        if (other.HasName)
          this.Name = other.Name;
        if (other.method_.Count != 0)
          this.AddRange<MethodDescriptorProto>((IEnumerable<MethodDescriptorProto>) other.method_, (IList<MethodDescriptorProto>) this.result.method_);
        if (other.HasOptions)
          this.MergeOptions(other.Options);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override ServiceDescriptorProto.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override ServiceDescriptorProto.Builder MergeFrom(
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
              MethodDescriptorProto.Builder builder1 = MethodDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder1, extensionRegistry);
              this.AddMethod(builder1.BuildPartial());
              continue;
            case 26:
              ServiceOptions.Builder builder2 = ServiceOptions.CreateBuilder();
              if (this.HasOptions)
                builder2.MergeFrom(this.Options);
              input.ReadMessage((IBuilderLite) builder2, extensionRegistry);
              this.Options = builder2.BuildPartial();
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

      public ServiceDescriptorProto.Builder SetName(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasName = true;
        this.result.name_ = value;
        return this;
      }

      public ServiceDescriptorProto.Builder ClearName()
      {
        this.result.hasName = false;
        this.result.name_ = "";
        return this;
      }

      public IPopsicleList<MethodDescriptorProto> MethodList
      {
        get => (IPopsicleList<MethodDescriptorProto>) this.result.method_;
      }

      public int MethodCount => this.result.MethodCount;

      public MethodDescriptorProto GetMethod(int index) => this.result.GetMethod(index);

      public ServiceDescriptorProto.Builder SetMethod(int index, MethodDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.method_[index] = value;
        return this;
      }

      public ServiceDescriptorProto.Builder SetMethod(
        int index,
        MethodDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.method_[index] = builderForValue.Build();
        return this;
      }

      public ServiceDescriptorProto.Builder AddMethod(MethodDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.method_.Add(value);
        return this;
      }

      public ServiceDescriptorProto.Builder AddMethod(MethodDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.method_.Add(builderForValue.Build());
        return this;
      }

      public ServiceDescriptorProto.Builder AddRangeMethod(IEnumerable<MethodDescriptorProto> values)
      {
        this.AddRange<MethodDescriptorProto>(values, (IList<MethodDescriptorProto>) this.result.method_);
        return this;
      }

      public ServiceDescriptorProto.Builder ClearMethod()
      {
        this.result.method_.Clear();
        return this;
      }

      public bool HasOptions => this.result.HasOptions;

      public ServiceOptions Options
      {
        get => this.result.Options;
        set => this.SetOptions(value);
      }

      public ServiceDescriptorProto.Builder SetOptions(ServiceOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOptions = true;
        this.result.options_ = value;
        return this;
      }

      public ServiceDescriptorProto.Builder SetOptions(ServiceOptions.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.hasOptions = true;
        this.result.options_ = builderForValue.Build();
        return this;
      }

      public ServiceDescriptorProto.Builder MergeOptions(ServiceOptions value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.options_ = !this.result.HasOptions || this.result.options_ == ServiceOptions.DefaultInstance ? value : ServiceOptions.CreateBuilder(this.result.options_).MergeFrom(value).BuildPartial();
        this.result.hasOptions = true;
        return this;
      }

      public ServiceDescriptorProto.Builder ClearOptions()
      {
        this.result.hasOptions = false;
        this.result.options_ = ServiceOptions.DefaultInstance;
        return this;
      }
    }
  }
}
