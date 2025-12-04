// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public sealed class CSharpFileOptions : 
    GeneratedMessage<CSharpFileOptions, CSharpFileOptions.Builder>
  {
    public const int NamespaceFieldNumber = 1;
    public const int UmbrellaClassnameFieldNumber = 2;
    public const int PublicClassesFieldNumber = 3;
    public const int MultipleFilesFieldNumber = 4;
    public const int NestClassesFieldNumber = 5;
    public const int CodeContractsFieldNumber = 6;
    public const int ExpandNamespaceDirectoriesFieldNumber = 7;
    public const int ClsComplianceFieldNumber = 8;
    public const int FileExtensionFieldNumber = 221;
    public const int UmbrellaNamespaceFieldNumber = 222;
    public const int OutputDirectoryFieldNumber = 223;
    public const int IgnoreGoogleProtobufFieldNumber = 224;
    private static readonly CSharpFileOptions defaultInstance = new CSharpFileOptions.Builder().BuildPartial();
    private bool hasNamespace;
    private string namespace_ = "";
    private bool hasUmbrellaClassname;
    private string umbrellaClassname_ = "";
    private bool hasPublicClasses;
    private bool publicClasses_ = true;
    private bool hasMultipleFiles;
    private bool multipleFiles_;
    private bool hasNestClasses;
    private bool nestClasses_;
    private bool hasCodeContracts;
    private bool codeContracts_;
    private bool hasExpandNamespaceDirectories;
    private bool expandNamespaceDirectories_;
    private bool hasClsCompliance;
    private bool clsCompliance_ = true;
    private bool hasFileExtension;
    private string fileExtension_ = ".cs";
    private bool hasUmbrellaNamespace;
    private string umbrellaNamespace_ = "";
    private bool hasOutputDirectory;
    private string outputDirectory_ = ".";
    private bool hasIgnoreGoogleProtobuf;
    private bool ignoreGoogleProtobuf_;
    private int memoizedSerializedSize = -1;

    public static CSharpFileOptions DefaultInstance => CSharpFileOptions.defaultInstance;

    public override CSharpFileOptions DefaultInstanceForType => CSharpFileOptions.defaultInstance;

    protected override CSharpFileOptions ThisMessage => this;

    public static MessageDescriptor Descriptor
    {
      get => CSharpOptions.internal__static_google_protobuf_CSharpFileOptions__Descriptor;
    }

    protected override FieldAccessorTable<CSharpFileOptions, CSharpFileOptions.Builder> InternalFieldAccessors
    {
      get => CSharpOptions.internal__static_google_protobuf_CSharpFileOptions__FieldAccessorTable;
    }

    public bool HasNamespace => this.hasNamespace;

    public string Namespace => this.namespace_;

    public bool HasUmbrellaClassname => this.hasUmbrellaClassname;

    public string UmbrellaClassname => this.umbrellaClassname_;

    public bool HasPublicClasses => this.hasPublicClasses;

    public bool PublicClasses => this.publicClasses_;

    public bool HasMultipleFiles => this.hasMultipleFiles;

    public bool MultipleFiles => this.multipleFiles_;

    public bool HasNestClasses => this.hasNestClasses;

    public bool NestClasses => this.nestClasses_;

    public bool HasCodeContracts => this.hasCodeContracts;

    public bool CodeContracts => this.codeContracts_;

    public bool HasExpandNamespaceDirectories => this.hasExpandNamespaceDirectories;

    public bool ExpandNamespaceDirectories => this.expandNamespaceDirectories_;

    public bool HasClsCompliance => this.hasClsCompliance;

    public bool ClsCompliance => this.clsCompliance_;

    public bool HasFileExtension => this.hasFileExtension;

    public string FileExtension => this.fileExtension_;

    public bool HasUmbrellaNamespace => this.hasUmbrellaNamespace;

    public string UmbrellaNamespace => this.umbrellaNamespace_;

    public bool HasOutputDirectory => this.hasOutputDirectory;

    public string OutputDirectory => this.outputDirectory_;

    public bool HasIgnoreGoogleProtobuf => this.hasIgnoreGoogleProtobuf;

    public bool IgnoreGoogleProtobuf => this.ignoreGoogleProtobuf_;

    public override bool IsInitialized => true;

    public override void WriteTo(CodedOutputStream output)
    {
      int serializedSize = this.SerializedSize;
      if (this.HasNamespace)
        output.WriteString(1, this.Namespace);
      if (this.HasUmbrellaClassname)
        output.WriteString(2, this.UmbrellaClassname);
      if (this.HasPublicClasses)
        output.WriteBool(3, this.PublicClasses);
      if (this.HasMultipleFiles)
        output.WriteBool(4, this.MultipleFiles);
      if (this.HasNestClasses)
        output.WriteBool(5, this.NestClasses);
      if (this.HasCodeContracts)
        output.WriteBool(6, this.CodeContracts);
      if (this.HasExpandNamespaceDirectories)
        output.WriteBool(7, this.ExpandNamespaceDirectories);
      if (this.HasClsCompliance)
        output.WriteBool(8, this.ClsCompliance);
      if (this.HasFileExtension)
        output.WriteString(221, this.FileExtension);
      if (this.HasUmbrellaNamespace)
        output.WriteString(222, this.UmbrellaNamespace);
      if (this.HasOutputDirectory)
        output.WriteString(223, this.OutputDirectory);
      if (this.HasIgnoreGoogleProtobuf)
        output.WriteBool(224, this.IgnoreGoogleProtobuf);
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
        if (this.HasNamespace)
          num += CodedOutputStream.ComputeStringSize(1, this.Namespace);
        if (this.HasUmbrellaClassname)
          num += CodedOutputStream.ComputeStringSize(2, this.UmbrellaClassname);
        if (this.HasPublicClasses)
          num += CodedOutputStream.ComputeBoolSize(3, this.PublicClasses);
        if (this.HasMultipleFiles)
          num += CodedOutputStream.ComputeBoolSize(4, this.MultipleFiles);
        if (this.HasNestClasses)
          num += CodedOutputStream.ComputeBoolSize(5, this.NestClasses);
        if (this.HasCodeContracts)
          num += CodedOutputStream.ComputeBoolSize(6, this.CodeContracts);
        if (this.HasExpandNamespaceDirectories)
          num += CodedOutputStream.ComputeBoolSize(7, this.ExpandNamespaceDirectories);
        if (this.HasClsCompliance)
          num += CodedOutputStream.ComputeBoolSize(8, this.ClsCompliance);
        if (this.HasFileExtension)
          num += CodedOutputStream.ComputeStringSize(221, this.FileExtension);
        if (this.HasUmbrellaNamespace)
          num += CodedOutputStream.ComputeStringSize(222, this.UmbrellaNamespace);
        if (this.HasOutputDirectory)
          num += CodedOutputStream.ComputeStringSize(223, this.OutputDirectory);
        if (this.HasIgnoreGoogleProtobuf)
          num += CodedOutputStream.ComputeBoolSize(224, this.IgnoreGoogleProtobuf);
        int serializedSize = num + this.UnknownFields.SerializedSize;
        this.memoizedSerializedSize = serializedSize;
        return serializedSize;
      }
    }

    public static CSharpFileOptions ParseFrom(ByteString data)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(ByteString data, ExtensionRegistry extensionRegistry)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(byte[] data)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(data).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(byte[] data, ExtensionRegistry extensionRegistry)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(data, extensionRegistry).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(Stream input)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(Stream input, ExtensionRegistry extensionRegistry)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFileOptions ParseDelimitedFrom(Stream input)
    {
      return CSharpFileOptions.CreateBuilder().MergeDelimitedFrom(input).BuildParsed();
    }

    public static CSharpFileOptions ParseDelimitedFrom(
      Stream input,
      ExtensionRegistry extensionRegistry)
    {
      return CSharpFileOptions.CreateBuilder().MergeDelimitedFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(CodedInputStream input)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(input).BuildParsed();
    }

    public static CSharpFileOptions ParseFrom(
      CodedInputStream input,
      ExtensionRegistry extensionRegistry)
    {
      return CSharpFileOptions.CreateBuilder().MergeFrom(input, extensionRegistry).BuildParsed();
    }

    public static CSharpFileOptions.Builder CreateBuilder() => new CSharpFileOptions.Builder();

    public override CSharpFileOptions.Builder ToBuilder() => CSharpFileOptions.CreateBuilder(this);

    public override CSharpFileOptions.Builder CreateBuilderForType()
    {
      return new CSharpFileOptions.Builder();
    }

    public static CSharpFileOptions.Builder CreateBuilder(CSharpFileOptions prototype)
    {
      return new CSharpFileOptions.Builder().MergeFrom(prototype);
    }

    static CSharpFileOptions()
    {
      object.ReferenceEquals((object) CSharpOptions.Descriptor, (object) null);
    }

    public sealed class Builder : GeneratedBuilder<CSharpFileOptions, CSharpFileOptions.Builder>
    {
      private CSharpFileOptions result = new CSharpFileOptions();

      protected override CSharpFileOptions.Builder ThisBuilder => this;

      protected override CSharpFileOptions MessageBeingBuilt => this.result;

      public override CSharpFileOptions.Builder Clear()
      {
        this.result = new CSharpFileOptions();
        return this;
      }

      public override CSharpFileOptions.Builder Clone()
      {
        return new CSharpFileOptions.Builder().MergeFrom(this.result);
      }

      public override MessageDescriptor DescriptorForType => CSharpFileOptions.Descriptor;

      public override CSharpFileOptions DefaultInstanceForType => CSharpFileOptions.DefaultInstance;

      public override CSharpFileOptions BuildPartial()
      {
        CSharpFileOptions csharpFileOptions = this.result != null ? this.result : throw new InvalidOperationException("build() has already been called on this Builder");
        this.result = (CSharpFileOptions) null;
        return csharpFileOptions;
      }

      public override CSharpFileOptions.Builder MergeFrom(IMessage other)
      {
        if (other is CSharpFileOptions)
          return this.MergeFrom((CSharpFileOptions) other);
        base.MergeFrom(other);
        return this;
      }

      public override CSharpFileOptions.Builder MergeFrom(CSharpFileOptions other)
      {
        if (other == CSharpFileOptions.DefaultInstance)
          return this;
        if (other.HasNamespace)
          this.Namespace = other.Namespace;
        if (other.HasUmbrellaClassname)
          this.UmbrellaClassname = other.UmbrellaClassname;
        if (other.HasPublicClasses)
          this.PublicClasses = other.PublicClasses;
        if (other.HasMultipleFiles)
          this.MultipleFiles = other.MultipleFiles;
        if (other.HasNestClasses)
          this.NestClasses = other.NestClasses;
        if (other.HasCodeContracts)
          this.CodeContracts = other.CodeContracts;
        if (other.HasExpandNamespaceDirectories)
          this.ExpandNamespaceDirectories = other.ExpandNamespaceDirectories;
        if (other.HasClsCompliance)
          this.ClsCompliance = other.ClsCompliance;
        if (other.HasFileExtension)
          this.FileExtension = other.FileExtension;
        if (other.HasUmbrellaNamespace)
          this.UmbrellaNamespace = other.UmbrellaNamespace;
        if (other.HasOutputDirectory)
          this.OutputDirectory = other.OutputDirectory;
        if (other.HasIgnoreGoogleProtobuf)
          this.IgnoreGoogleProtobuf = other.IgnoreGoogleProtobuf;
        this.MergeUnknownFields(other.UnknownFields);
        return this;
      }

      public override CSharpFileOptions.Builder MergeFrom(CodedInputStream input)
      {
        return this.MergeFrom(input, ExtensionRegistry.Empty);
      }

      public override CSharpFileOptions.Builder MergeFrom(
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
              this.Namespace = input.ReadString();
              continue;
            case 18:
              this.UmbrellaClassname = input.ReadString();
              continue;
            case 24:
              this.PublicClasses = input.ReadBool();
              continue;
            case 32:
              this.MultipleFiles = input.ReadBool();
              continue;
            case 40:
              this.NestClasses = input.ReadBool();
              continue;
            case 48:
              this.CodeContracts = input.ReadBool();
              continue;
            case 56:
              this.ExpandNamespaceDirectories = input.ReadBool();
              continue;
            case 64:
              this.ClsCompliance = input.ReadBool();
              continue;
            case 1770:
              this.FileExtension = input.ReadString();
              continue;
            case 1778:
              this.UmbrellaNamespace = input.ReadString();
              continue;
            case 1786:
              this.OutputDirectory = input.ReadString();
              continue;
            case 1792:
              this.IgnoreGoogleProtobuf = input.ReadBool();
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

      public bool HasNamespace => this.result.HasNamespace;

      public string Namespace
      {
        get => this.result.Namespace;
        set => this.SetNamespace(value);
      }

      public CSharpFileOptions.Builder SetNamespace(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasNamespace = true;
        this.result.namespace_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearNamespace()
      {
        this.result.hasNamespace = false;
        this.result.namespace_ = "";
        return this;
      }

      public bool HasUmbrellaClassname => this.result.HasUmbrellaClassname;

      public string UmbrellaClassname
      {
        get => this.result.UmbrellaClassname;
        set => this.SetUmbrellaClassname(value);
      }

      public CSharpFileOptions.Builder SetUmbrellaClassname(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasUmbrellaClassname = true;
        this.result.umbrellaClassname_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearUmbrellaClassname()
      {
        this.result.hasUmbrellaClassname = false;
        this.result.umbrellaClassname_ = "";
        return this;
      }

      public bool HasPublicClasses => this.result.HasPublicClasses;

      public bool PublicClasses
      {
        get => this.result.PublicClasses;
        set => this.SetPublicClasses(value);
      }

      public CSharpFileOptions.Builder SetPublicClasses(bool value)
      {
        this.result.hasPublicClasses = true;
        this.result.publicClasses_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearPublicClasses()
      {
        this.result.hasPublicClasses = false;
        this.result.publicClasses_ = true;
        return this;
      }

      public bool HasMultipleFiles => this.result.HasMultipleFiles;

      public bool MultipleFiles
      {
        get => this.result.MultipleFiles;
        set => this.SetMultipleFiles(value);
      }

      public CSharpFileOptions.Builder SetMultipleFiles(bool value)
      {
        this.result.hasMultipleFiles = true;
        this.result.multipleFiles_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearMultipleFiles()
      {
        this.result.hasMultipleFiles = false;
        this.result.multipleFiles_ = false;
        return this;
      }

      public bool HasNestClasses => this.result.HasNestClasses;

      public bool NestClasses
      {
        get => this.result.NestClasses;
        set => this.SetNestClasses(value);
      }

      public CSharpFileOptions.Builder SetNestClasses(bool value)
      {
        this.result.hasNestClasses = true;
        this.result.nestClasses_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearNestClasses()
      {
        this.result.hasNestClasses = false;
        this.result.nestClasses_ = false;
        return this;
      }

      public bool HasCodeContracts => this.result.HasCodeContracts;

      public bool CodeContracts
      {
        get => this.result.CodeContracts;
        set => this.SetCodeContracts(value);
      }

      public CSharpFileOptions.Builder SetCodeContracts(bool value)
      {
        this.result.hasCodeContracts = true;
        this.result.codeContracts_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearCodeContracts()
      {
        this.result.hasCodeContracts = false;
        this.result.codeContracts_ = false;
        return this;
      }

      public bool HasExpandNamespaceDirectories => this.result.HasExpandNamespaceDirectories;

      public bool ExpandNamespaceDirectories
      {
        get => this.result.ExpandNamespaceDirectories;
        set => this.SetExpandNamespaceDirectories(value);
      }

      public CSharpFileOptions.Builder SetExpandNamespaceDirectories(bool value)
      {
        this.result.hasExpandNamespaceDirectories = true;
        this.result.expandNamespaceDirectories_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearExpandNamespaceDirectories()
      {
        this.result.hasExpandNamespaceDirectories = false;
        this.result.expandNamespaceDirectories_ = false;
        return this;
      }

      public bool HasClsCompliance => this.result.HasClsCompliance;

      public bool ClsCompliance
      {
        get => this.result.ClsCompliance;
        set => this.SetClsCompliance(value);
      }

      public CSharpFileOptions.Builder SetClsCompliance(bool value)
      {
        this.result.hasClsCompliance = true;
        this.result.clsCompliance_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearClsCompliance()
      {
        this.result.hasClsCompliance = false;
        this.result.clsCompliance_ = true;
        return this;
      }

      public bool HasFileExtension => this.result.HasFileExtension;

      public string FileExtension
      {
        get => this.result.FileExtension;
        set => this.SetFileExtension(value);
      }

      public CSharpFileOptions.Builder SetFileExtension(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasFileExtension = true;
        this.result.fileExtension_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearFileExtension()
      {
        this.result.hasFileExtension = false;
        this.result.fileExtension_ = ".cs";
        return this;
      }

      public bool HasUmbrellaNamespace => this.result.HasUmbrellaNamespace;

      public string UmbrellaNamespace
      {
        get => this.result.UmbrellaNamespace;
        set => this.SetUmbrellaNamespace(value);
      }

      public CSharpFileOptions.Builder SetUmbrellaNamespace(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasUmbrellaNamespace = true;
        this.result.umbrellaNamespace_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearUmbrellaNamespace()
      {
        this.result.hasUmbrellaNamespace = false;
        this.result.umbrellaNamespace_ = "";
        return this;
      }

      public bool HasOutputDirectory => this.result.HasOutputDirectory;

      public string OutputDirectory
      {
        get => this.result.OutputDirectory;
        set => this.SetOutputDirectory(value);
      }

      public CSharpFileOptions.Builder SetOutputDirectory(string value)
      {
        Google.ProtocolBuffers.ThrowHelper.ThrowIfNull((object) value, nameof (value));
        this.result.hasOutputDirectory = true;
        this.result.outputDirectory_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearOutputDirectory()
      {
        this.result.hasOutputDirectory = false;
        this.result.outputDirectory_ = ".";
        return this;
      }

      public bool HasIgnoreGoogleProtobuf => this.result.HasIgnoreGoogleProtobuf;

      public bool IgnoreGoogleProtobuf
      {
        get => this.result.IgnoreGoogleProtobuf;
        set => this.SetIgnoreGoogleProtobuf(value);
      }

      public CSharpFileOptions.Builder SetIgnoreGoogleProtobuf(bool value)
      {
        this.result.hasIgnoreGoogleProtobuf = true;
        this.result.ignoreGoogleProtobuf_ = value;
        return this;
      }

      public CSharpFileOptions.Builder ClearIgnoreGoogleProtobuf()
      {
        this.result.hasIgnoreGoogleProtobuf = false;
        this.result.ignoreGoogleProtobuf_ = false;
        return this;
      }
    }
  }
}
