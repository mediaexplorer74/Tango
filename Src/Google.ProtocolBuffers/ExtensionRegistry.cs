// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.ExtensionRegistry
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using System;
using System.Collections.Generic;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class ExtensionRegistry
  {
    private static readonly ExtensionRegistry empty = new ExtensionRegistry((IDictionary<string, ExtensionInfo>) new Dictionary<string, ExtensionInfo>(), (IDictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>) new Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>(), true);
    private readonly IDictionary<string, ExtensionInfo> extensionsByName;
    private readonly IDictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite> extensionsByNumber;
    private readonly bool readOnly;

    private ExtensionRegistry(
      IDictionary<string, ExtensionInfo> extensionsByName,
      IDictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite> extensionsByNumber,
      bool readOnly)
      : this(extensionsByNumber, readOnly)
    {
      this.extensionsByName = extensionsByName;
    }

    public static ExtensionRegistry CreateInstance()
    {
      return new ExtensionRegistry((IDictionary<string, ExtensionInfo>) new Dictionary<string, ExtensionInfo>(), (IDictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>) new Dictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite>(), false);
    }

    public ExtensionRegistry AsReadOnly()
    {
      return new ExtensionRegistry(this.extensionsByName, this.extensionsByNumber, true);
    }

    public ExtensionInfo this[string fullName]
    {
      get
      {
        ExtensionInfo extensionInfo;
        this.extensionsByName.TryGetValue(fullName, out extensionInfo);
        return extensionInfo;
      }
    }

    public ExtensionInfo this[MessageDescriptor containingType, int fieldNumber]
    {
      get
      {
        IGeneratedExtensionLite generatedExtensionLite;
        this.extensionsByNumber.TryGetValue(new ExtensionRegistry.ExtensionIntPair((object) containingType, fieldNumber), out generatedExtensionLite);
        return generatedExtensionLite as ExtensionInfo;
      }
    }

    public void Add<TExtension>(GeneratedExtensionBase<TExtension> extension)
    {
      if (extension.Descriptor.MappedType == MappedType.Message)
        this.Add(new ExtensionInfo(extension.Descriptor, extension.MessageDefaultInstance));
      else
        this.Add(new ExtensionInfo(extension.Descriptor, (IMessageLite) null));
    }

    public void Add(FieldDescriptor type)
    {
      if (type.MappedType == MappedType.Message)
        throw new ArgumentException("ExtensionRegistry.Add() must be provided a default instance when adding an embedded message extension.");
      this.Add(new ExtensionInfo(type, (IMessageLite) null));
    }

    public void Add(FieldDescriptor type, IMessage defaultInstance)
    {
      if (type.MappedType != MappedType.Message)
        throw new ArgumentException("ExtensionRegistry.Add() provided a default instance for a non-message extension.");
      this.Add(new ExtensionInfo(type, (IMessageLite) defaultInstance));
    }

    private void Add(ExtensionInfo extension)
    {
      if (this.readOnly)
        throw new InvalidOperationException("Cannot add entries to a read-only extension registry");
      if (!extension.Descriptor.IsExtension)
        throw new ArgumentException("ExtensionRegistry.add() was given a FieldDescriptor for a regular (non-extension) field.");
      this.extensionsByName[extension.Descriptor.FullName] = extension;
      this.extensionsByNumber[new ExtensionRegistry.ExtensionIntPair((object) extension.Descriptor.ContainingType, extension.Descriptor.FieldNumber)] = (IGeneratedExtensionLite) extension;
      FieldDescriptor descriptor = extension.Descriptor;
      if (!descriptor.ContainingType.Options.MessageSetWireFormat || descriptor.FieldType != FieldType.Message || !descriptor.IsOptional || descriptor.ExtensionScope != descriptor.MessageType)
        return;
      this.extensionsByName[descriptor.MessageType.FullName] = extension;
    }

    private ExtensionRegistry(
      IDictionary<ExtensionRegistry.ExtensionIntPair, IGeneratedExtensionLite> extensionsByNumber,
      bool readOnly)
    {
      this.extensionsByNumber = extensionsByNumber;
      this.readOnly = readOnly;
    }

    public static ExtensionRegistry Empty => ExtensionRegistry.empty;

    public IGeneratedExtensionLite this[IMessageLite containingType, int fieldNumber]
    {
      get
      {
        IGeneratedExtensionLite generatedExtensionLite;
        this.extensionsByNumber.TryGetValue(new ExtensionRegistry.ExtensionIntPair((object) containingType, fieldNumber), out generatedExtensionLite);
        return generatedExtensionLite;
      }
    }

    public void Add(IGeneratedExtensionLite extension)
    {
      if (this.readOnly)
        throw new InvalidOperationException("Cannot add entries to a read-only extension registry");
      this.extensionsByNumber.Add(new ExtensionRegistry.ExtensionIntPair(extension.ContainingType, extension.Number), extension);
    }

    private struct ExtensionIntPair : IEquatable<ExtensionRegistry.ExtensionIntPair>
    {
      private readonly object msgType;
      private readonly int number;

      internal ExtensionIntPair(object msgType, int number)
      {
        this.msgType = msgType;
        this.number = number;
      }

      public override int GetHashCode()
      {
        return this.msgType.GetHashCode() * (int) ushort.MaxValue + this.number;
      }

      public override bool Equals(object obj)
      {
        return obj is ExtensionRegistry.ExtensionIntPair other && this.Equals(other);
      }

      public bool Equals(ExtensionRegistry.ExtensionIntPair other)
      {
        return this.msgType.Equals(other.msgType) && this.number == other.number;
      }
    }
  }
}
