// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.FieldDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Collections;
using Google.ProtocolBuffers.DescriptorProtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class FieldDescriptor : 
    IndexedDescriptorBase<FieldDescriptorProto, FieldOptions>,
    IComparable<FieldDescriptor>,
    IFieldDescriptorLite,
    IComparable<IFieldDescriptorLite>
  {
    private readonly MessageDescriptor extensionScope;
    private EnumDescriptor enumType;
    private MessageDescriptor messageType;
    private MessageDescriptor containingType;
    private object defaultValue;
    private FieldType fieldType;
    private MappedType mappedType;
    private CSharpFieldOptions csharpFieldOptions;
    private readonly object optionsLock = new object();
    public static readonly IDictionary<FieldType, MappedType> FieldTypeToMappedTypeMap = FieldDescriptor.MapFieldTypes();

    internal FieldDescriptor(
      FieldDescriptorProto proto,
      FileDescriptor file,
      MessageDescriptor parent,
      int index,
      bool isExtension)
      : base(proto, file, DescriptorBase<FieldDescriptorProto, FieldOptions>.ComputeFullName(file, parent, proto.Name), index)
    {
      if (proto.HasType)
      {
        this.fieldType = FieldDescriptor.GetFieldTypeFromProtoType(proto.Type);
        this.mappedType = FieldDescriptor.FieldTypeToMappedTypeMap[this.fieldType];
      }
      if (this.FieldNumber <= 0)
        throw new DescriptorValidationException((IDescriptor) this, "Field numbers must be positive integers.");
      if (isExtension)
      {
        if (!proto.HasExtendee)
          throw new DescriptorValidationException((IDescriptor) this, "FieldDescriptorProto.Extendee not set for extension field.");
        this.containingType = (MessageDescriptor) null;
        this.extensionScope = parent == null ? (MessageDescriptor) null : parent;
      }
      else
      {
        if (proto.HasExtendee)
          throw new DescriptorValidationException((IDescriptor) this, "FieldDescriptorProto.Extendee set for non-extension field.");
        this.containingType = parent;
        this.extensionScope = (MessageDescriptor) null;
      }
      file.DescriptorPool.AddSymbol((IDescriptor) this);
    }

    private CSharpFieldOptions BuildOrFakeCSharpOptions()
    {
      if (this.File.Proto.Name == "google/protobuf/csharp_options.proto")
      {
        if (this.Name == "csharp_field_options")
          return new CSharpFieldOptions.Builder()
          {
            PropertyName = "CSharpFieldOptions"
          }.Build();
        if (this.Name == "csharp_file_options")
          return new CSharpFieldOptions.Builder()
          {
            PropertyName = "CSharpFileOptions"
          }.Build();
      }
      CSharpFieldOptions.Builder builder = CSharpFieldOptions.CreateBuilder();
      if (this.Proto.Options.HasExtension<CSharpFieldOptions>(Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.CSharpFieldOptions))
        builder.MergeFrom(this.Proto.Options.GetExtension<CSharpFieldOptions>(Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.CSharpFieldOptions));
      if (!builder.HasPropertyName)
      {
        string pascalCase = NameHelpers.UnderscoresToPascalCase(this.FieldType == FieldType.Group ? this.MessageType.Name : this.Name);
        if (pascalCase == this.ContainingType.Name)
          pascalCase += "_";
        builder.PropertyName = pascalCase;
      }
      return builder.Build();
    }

    private static FieldType GetFieldTypeFromProtoType(FieldDescriptorProto.Types.Type type)
    {
      switch (type)
      {
        case FieldDescriptorProto.Types.Type.TYPE_DOUBLE:
          return FieldType.Double;
        case FieldDescriptorProto.Types.Type.TYPE_FLOAT:
          return FieldType.Float;
        case FieldDescriptorProto.Types.Type.TYPE_INT64:
          return FieldType.Int64;
        case FieldDescriptorProto.Types.Type.TYPE_UINT64:
          return FieldType.UInt64;
        case FieldDescriptorProto.Types.Type.TYPE_INT32:
          return FieldType.Int32;
        case FieldDescriptorProto.Types.Type.TYPE_FIXED64:
          return FieldType.Fixed64;
        case FieldDescriptorProto.Types.Type.TYPE_FIXED32:
          return FieldType.Fixed32;
        case FieldDescriptorProto.Types.Type.TYPE_BOOL:
          return FieldType.Bool;
        case FieldDescriptorProto.Types.Type.TYPE_STRING:
          return FieldType.String;
        case FieldDescriptorProto.Types.Type.TYPE_GROUP:
          return FieldType.Group;
        case FieldDescriptorProto.Types.Type.TYPE_MESSAGE:
          return FieldType.Message;
        case FieldDescriptorProto.Types.Type.TYPE_BYTES:
          return FieldType.Bytes;
        case FieldDescriptorProto.Types.Type.TYPE_UINT32:
          return FieldType.UInt32;
        case FieldDescriptorProto.Types.Type.TYPE_ENUM:
          return FieldType.Enum;
        case FieldDescriptorProto.Types.Type.TYPE_SFIXED32:
          return FieldType.SFixed32;
        case FieldDescriptorProto.Types.Type.TYPE_SFIXED64:
          return FieldType.SFixed64;
        case FieldDescriptorProto.Types.Type.TYPE_SINT32:
          return FieldType.SInt32;
        case FieldDescriptorProto.Types.Type.TYPE_SINT64:
          return FieldType.SInt64;
        default:
          throw new ArgumentException("Invalid type specified");
      }
    }

    private static object GetDefaultValueForMappedType(MappedType type)
    {
      switch (type)
      {
        case MappedType.Int32:
          return (object) 0;
        case MappedType.Int64:
          return (object) 0L;
        case MappedType.UInt32:
          return (object) 0U;
        case MappedType.UInt64:
          return (object) 0UL;
        case MappedType.Single:
          return (object) 0.0f;
        case MappedType.Double:
          return (object) 0.0;
        case MappedType.Boolean:
          return (object) false;
        case MappedType.String:
          return (object) "";
        case MappedType.ByteString:
          return (object) ByteString.Empty;
        case MappedType.Message:
          return (object) null;
        case MappedType.Enum:
          return (object) null;
        default:
          throw new ArgumentException("Invalid type specified");
      }
    }

    public bool IsRequired => this.Proto.Label == FieldDescriptorProto.Types.Label.LABEL_REQUIRED;

    public bool IsOptional => this.Proto.Label == FieldDescriptorProto.Types.Label.LABEL_OPTIONAL;

    public bool IsRepeated => this.Proto.Label == FieldDescriptorProto.Types.Label.LABEL_REPEATED;

    public bool IsPacked => this.Proto.Options.Packed;

    public bool HasDefaultValue => this.Proto.HasDefaultValue;

    public object DefaultValue
    {
      get
      {
        if (this.MappedType == MappedType.Message)
          throw new InvalidOperationException("FieldDescriptor.DefaultValue called on an embedded message field.");
        return this.defaultValue;
      }
    }

    public bool IsExtension => this.Proto.HasExtendee;

    public MessageDescriptor ContainingType => this.containingType;

    public CSharpFieldOptions CSharpOptions
    {
      get
      {
        lock (this.optionsLock)
        {
          if (this.csharpFieldOptions == null)
            this.csharpFieldOptions = this.BuildOrFakeCSharpOptions();
        }
        return this.csharpFieldOptions;
      }
    }

    public MessageDescriptor ExtensionScope
    {
      get
      {
        if (!this.IsExtension)
          throw new InvalidOperationException("This field is not an extension.");
        return this.extensionScope;
      }
    }

    public MappedType MappedType => this.mappedType;

    public FieldType FieldType => this.fieldType;

    public bool IsCLSCompliant
    {
      get => this.mappedType != MappedType.UInt32 && this.mappedType != MappedType.UInt64;
    }

    public int FieldNumber => this.Proto.Number;

    public int CompareTo(FieldDescriptor other)
    {
      if (other.containingType != this.containingType)
        throw new ArgumentException("FieldDescriptors can only be compared to other FieldDescriptors for fields of the same message type.");
      return this.FieldNumber - other.FieldNumber;
    }

    public int CompareTo(IFieldDescriptorLite other) => this.FieldNumber - other.FieldNumber;

    IEnumLiteMap IFieldDescriptorLite.EnumType => (IEnumLiteMap) this.EnumType;

    bool IFieldDescriptorLite.MessageSetWireFormat
    {
      get => this.ContainingType.Options.MessageSetWireFormat;
    }

    public EnumDescriptor EnumType
    {
      get
      {
        if (this.MappedType != MappedType.Enum)
          throw new InvalidOperationException("EnumType is only valid for enum fields.");
        return this.enumType;
      }
    }

    public MessageDescriptor MessageType
    {
      get
      {
        if (this.MappedType != MappedType.Message)
          throw new InvalidOperationException("MessageType is only valid for enum fields.");
        return this.messageType;
      }
    }

    private static IDictionary<FieldType, MappedType> MapFieldTypes()
    {
      Dictionary<FieldType, MappedType> dictionary = new Dictionary<FieldType, MappedType>();
      foreach (FieldInfo field in typeof (FieldType).GetFields(BindingFlags.Static | BindingFlags.Public))
      {
        FieldType key = (FieldType) field.GetValue((object) null);
        FieldMappingAttribute customAttribute = (FieldMappingAttribute) field.GetCustomAttributes(typeof (FieldMappingAttribute), false).FirstOrDefault();
        dictionary[key] = customAttribute.MappedType;
      }
      return Dictionaries.AsReadOnly<FieldType, MappedType>((IDictionary<FieldType, MappedType>) dictionary);
    }

    internal void CrossLink()
    {
      if (this.Proto.HasExtendee)
      {
        IDescriptor descriptor = this.File.DescriptorPool.LookupSymbol(this.Proto.Extendee, (IDescriptor) this);
        this.containingType = descriptor is MessageDescriptor ? (MessageDescriptor) descriptor : throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.Extendee + "\" is not a message type.");
        if (!this.containingType.IsExtensionNumber(this.FieldNumber))
          throw new DescriptorValidationException((IDescriptor) this, "\"" + this.containingType.FullName + "\" does not declare " + (object) this.FieldNumber + " as an extension number.");
      }
      if (this.Proto.HasTypeName)
      {
        IDescriptor descriptor = this.File.DescriptorPool.LookupSymbol(this.Proto.TypeName, (IDescriptor) this);
        if (!this.Proto.HasType)
        {
          switch (descriptor)
          {
            case MessageDescriptor _:
              this.fieldType = FieldType.Message;
              this.mappedType = MappedType.Message;
              break;
            case EnumDescriptor _:
              this.fieldType = FieldType.Enum;
              this.mappedType = MappedType.Enum;
              break;
            default:
              throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.TypeName + "\" is not a type.");
          }
        }
        if (this.MappedType == MappedType.Message)
        {
          this.messageType = descriptor is MessageDescriptor ? (MessageDescriptor) descriptor : throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.TypeName + "\" is not a message type.");
          if (this.Proto.HasDefaultValue)
            throw new DescriptorValidationException((IDescriptor) this, "Messages can't have default values.");
        }
        else
        {
          if (this.MappedType != MappedType.Enum)
            throw new DescriptorValidationException((IDescriptor) this, "Field with primitive type has type_name.");
          this.enumType = descriptor is EnumDescriptor ? (EnumDescriptor) descriptor : throw new DescriptorValidationException((IDescriptor) this, "\"" + this.Proto.TypeName + "\" is not an enum type.");
        }
      }
      else if (this.MappedType == MappedType.Message || this.MappedType == MappedType.Enum)
        throw new DescriptorValidationException((IDescriptor) this, "Field with message or enum type missing type_name.");
      if (this.Proto.HasDefaultValue)
      {
        if (this.IsRepeated)
          throw new DescriptorValidationException((IDescriptor) this, "Repeated fields cannot have default values.");
        try
        {
          switch (this.FieldType)
          {
            case FieldType.Double:
              this.defaultValue = (object) TextFormat.ParseDouble(this.Proto.DefaultValue);
              break;
            case FieldType.Float:
              this.defaultValue = (object) TextFormat.ParseFloat(this.Proto.DefaultValue);
              break;
            case FieldType.Int64:
            case FieldType.SFixed64:
            case FieldType.SInt64:
              this.defaultValue = (object) TextFormat.ParseInt64(this.Proto.DefaultValue);
              break;
            case FieldType.UInt64:
            case FieldType.Fixed64:
              this.defaultValue = (object) TextFormat.ParseUInt64(this.Proto.DefaultValue);
              break;
            case FieldType.Int32:
            case FieldType.SFixed32:
            case FieldType.SInt32:
              this.defaultValue = (object) TextFormat.ParseInt32(this.Proto.DefaultValue);
              break;
            case FieldType.Fixed32:
            case FieldType.UInt32:
              this.defaultValue = (object) TextFormat.ParseUInt32(this.Proto.DefaultValue);
              break;
            case FieldType.Bool:
              if (this.Proto.DefaultValue == "true")
              {
                this.defaultValue = (object) true;
                break;
              }
              if (!(this.Proto.DefaultValue == "false"))
                throw new FormatException("Boolean values must be \"true\" or \"false\"");
              this.defaultValue = (object) false;
              break;
            case FieldType.String:
              this.defaultValue = (object) this.Proto.DefaultValue;
              break;
            case FieldType.Group:
            case FieldType.Message:
              throw new DescriptorValidationException((IDescriptor) this, "Message type had default value.");
            case FieldType.Bytes:
              try
              {
                this.defaultValue = (object) TextFormat.UnescapeBytes(this.Proto.DefaultValue);
                break;
              }
              catch (FormatException ex)
              {
                throw new DescriptorValidationException((IDescriptor) this, "Couldn't parse default value: " + ex.Message);
              }
            case FieldType.Enum:
              this.defaultValue = (object) this.enumType.FindValueByName(this.Proto.DefaultValue);
              if (this.defaultValue == null)
                throw new DescriptorValidationException((IDescriptor) this, "Unknown enum default value: \"" + this.Proto.DefaultValue + "\"");
              break;
          }
        }
        catch (FormatException ex)
        {
          throw new DescriptorValidationException((IDescriptor) this, "Could not parse default value: \"" + this.Proto.DefaultValue + "\"", (Exception) ex);
        }
      }
      else if (this.IsRepeated)
      {
        this.defaultValue = (object) Lists<object>.Empty;
      }
      else
      {
        switch (this.MappedType)
        {
          case MappedType.Message:
            this.defaultValue = (object) null;
            break;
          case MappedType.Enum:
            this.defaultValue = (object) this.enumType.Values[0];
            break;
          default:
            this.defaultValue = FieldDescriptor.GetDefaultValueForMappedType(this.MappedType);
            break;
        }
      }
      if (!this.IsExtension)
        this.File.DescriptorPool.AddFieldByNumber(this);
      if (this.containingType == null || !this.containingType.Options.MessageSetWireFormat)
        return;
      if (!this.IsExtension)
        throw new DescriptorValidationException((IDescriptor) this, "MessageSets cannot have fields, only extensions.");
      if (!this.IsOptional || this.FieldType != FieldType.Message)
        throw new DescriptorValidationException((IDescriptor) this, "Extensions of MessageSets must be optional messages.");
    }
  }
}
