// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.FileDescriptorSet
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
  public sealed class FileDescriptorSet : 
    GeneratedMessage<FileDescriptorSet, FileDescriptorSet.Builder>
  {
    public const int FileFieldNumber = 1;
    private static readonly FileDescriptorSet defaultInstance = new FileDescriptorSet.Builder().BuildPartial();
    private PopsicleList<FileDescriptorProto> file_ = new PopsicleList<FileDescriptorProto>();
    private int memoizedSerializedSize = -1;

    public static FileDescriptorSet DefaultInstance => FileDescriptorSet.defaultInstance;

    public override FileDescriptorSet DefaultInstanceForType => FileDescriptorSet.defaultInstance;

    protected override FileDescriptorSet ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => DescriptorProtoFile.internal__static_google_protobuf_FileDescriptorSet__Descriptor;
    }

    protected override FieldAccessorTable<FileDescriptorSet, FileDescriptorSet.Builder> InternalFieldAccessors
    {
      get
      {
        return DescriptorProtoFile.internal__static_google_protobuf_FileDescriptorSet__FieldAccessorTable;
      }
    }

    public IList<FileDescriptorProto> FileList => (IList<FileDescriptorProto>) this.file_;

    public int FileCount => this.file_.Count;

    public FileDescriptorProto GetFile(int index) => this.file_[index];

    public override bool IsInitialized
    {
      get
      {
        foreach (AbstractMessageLite<FileDescriptorProto, FileDescriptorProto.Builder> file in (IEnumerable<FileDescriptorProto>) this.FileList)
        {
          if (!file.IsInitialized)
            return false;
        }
        return true;
      }
    }

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      foreach (FileDescriptorProto file in (IEnumerable<FileDescriptorProto>) this.FileList)
        output.WriteMessage(1, (IMessageLite) file);
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
        foreach (FileDescriptorProto file in (IEnumerable<FileDescriptorProto>) this.FileList)
          num += CodedOutputStream.ComputeMessageSize(1, (IMessageLite) file);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static FileDescriptorSet ParseFrom(ByteString data)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(byte[] data)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(Stream input)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorSet ParseDelimitedFrom(Stream input)
    {
      return FileDescriptorSet.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static FileDescriptorSet ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorSet.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(CodedInputStream input)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static FileDescriptorSet ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return FileDescriptorSet.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static FileDescriptorSet.Builder CreateBuilder() => new FileDescriptorSet.Builder();

    public override FileDescriptorSet.Builder ToBuilder() => FileDescriptorSet.CreateBuilder(this);

    public override FileDescriptorSet.Builder CreateBuilderForType()
    {
      return new FileDescriptorSet.Builder();
    }

    public static FileDescriptorSet.Builder CreateBuilder(FileDescriptorSet prototype)
    {
      return new FileDescriptorSet.Builder().MergeFrom(prototype);
    }

    static FileDescriptorSet()
    {
      object.ReferenceEquals((object) DescriptorProtoFile.Descriptor, (object) null);
    }

    public sealed class Builder : GeneratedBuilder<FileDescriptorSet, FileDescriptorSet.Builder>
    {
      private FileDescriptorSet result = new FileDescriptorSet();

      protected override FileDescriptorSet.Builder ThisBuilder => this;

      protected override FileDescriptorSet MessageBeingBuilt => this.result;

      public override FileDescriptorSet.Builder Clear()
      {
        this.result = new FileDescriptorSet();
        return this;
      }

      public override FileDescriptorSet.Builder Clone()
      {
        return new FileDescriptorSet.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => FileDescriptorSet.Descriptor;

      public override FileDescriptorSet DefaultInstanceForType => FileDescriptorSet.DefaultInstance;

      public override FileDescriptorSet BuildPartial()
      {
        if (this.result == null)
          throw new InvalidOperationException("build() has already been called on this Builder");
        this.result.file_.MakeReadOnly();
        FileDescriptorSet result = this.result;
        this.result = (FileDescriptorSet) null;
        return result;
      }

      public override FileDescriptorSet.Builder MergeFrom(IMessage other)
      {
        if (other is FileDescriptorSet)
          return this.MergeFrom((FileDescriptorSet) other);
        base.MergeFrom(other);
        return this;
      }

      public override FileDescriptorSet.Builder MergeFrom(FileDescriptorSet other)
      {
        if (other == FileDescriptorSet.DefaultInstance)
          return this;
        if (other.file_.Count != 0)
          this.AddRange<FileDescriptorProto>((IEnumerable<FileDescriptorProto>) other.file_, (IList<FileDescriptorProto>) this.result.file_);
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override FileDescriptorSet.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override FileDescriptorSet.Builder MergeFrom(
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
              FileDescriptorProto.Builder builder = FileDescriptorProto.CreateBuilder();
              input.ReadMessage((IBuilderLite) builder, extensionRegistry);
              this.AddFile(builder.BuildPartial());
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

      public IPopsicleList<FileDescriptorProto> FileList
      {
        get => (IPopsicleList<FileDescriptorProto>) this.result.file_;
      }

      public int FileCount => this.result.FileCount;

      public FileDescriptorProto GetFile(int index) => this.result.GetFile(index);

      public FileDescriptorSet.Builder SetFile(int index, FileDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.file_[index] = value;
        return this;
      }

      public FileDescriptorSet.Builder SetFile(
        int index,
        FileDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.file_[index] = builderForValue.Build();
        return this;
      }

      public FileDescriptorSet.Builder AddFile(FileDescriptorProto value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.file_.Add(value);
        return this;
      }

      public FileDescriptorSet.Builder AddFile(FileDescriptorProto.Builder builderForValue)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) builderForValue, nameof (builderForValue));
        this.result.file_.Add(builderForValue.Build());
        return this;
      }

      public FileDescriptorSet.Builder AddRangeFile(IEnumerable<FileDescriptorProto> values)
      {
        this.AddRange<FileDescriptorProto>(values, (IList<FileDescriptorProto>) this.result.file_);
        return this;
      }

      public FileDescriptorSet.Builder ClearFile()
      {
        this.result.file_.Clear();
        return this;
      }
    }
  }
}
