// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.FileDescriptor
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.DescriptorProtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  public sealed class FileDescriptor : IDescriptor<FileDescriptorProto>, IDescriptor
  {
    private FileDescriptorProto proto;
    private readonly IList<MessageDescriptor> messageTypes;
    private readonly IList<EnumDescriptor> enumTypes;
    private readonly IList<ServiceDescriptor> services;
    private readonly IList<FieldDescriptor> extensions;
    private readonly IList<FileDescriptor> dependencies;
    private readonly DescriptorPool pool;
    private CSharpFileOptions csharpFileOptions;
    private readonly object optionsLock = new object();

    private FileDescriptor(
      FileDescriptorProto proto,
      FileDescriptor[] dependencies,
      DescriptorPool pool)
    {
      this.pool = pool;
      this.proto = proto;
      this.dependencies = (IList<FileDescriptor>) new ReadOnlyCollection<FileDescriptor>((IList<FileDescriptor>) (FileDescriptor[]) dependencies.Clone());
      pool.AddPackage(this.Package, this);
      this.messageTypes = DescriptorUtil.ConvertAndMakeReadOnly<DescriptorProto, MessageDescriptor>(proto.MessageTypeList, (DescriptorUtil.IndexedConverter<DescriptorProto, MessageDescriptor>) ((message, index) => new MessageDescriptor(message, this, (MessageDescriptor) null, index)));
      this.enumTypes = DescriptorUtil.ConvertAndMakeReadOnly<EnumDescriptorProto, EnumDescriptor>(proto.EnumTypeList, (DescriptorUtil.IndexedConverter<EnumDescriptorProto, EnumDescriptor>) ((enumType, index) => new EnumDescriptor(enumType, this, (MessageDescriptor) null, index)));
      this.services = DescriptorUtil.ConvertAndMakeReadOnly<ServiceDescriptorProto, ServiceDescriptor>(proto.ServiceList, (DescriptorUtil.IndexedConverter<ServiceDescriptorProto, ServiceDescriptor>) ((service, index) => new ServiceDescriptor(service, this, index)));
      this.extensions = DescriptorUtil.ConvertAndMakeReadOnly<FieldDescriptorProto, FieldDescriptor>(proto.ExtensionList, (DescriptorUtil.IndexedConverter<FieldDescriptorProto, FieldDescriptor>) ((field, index) => new FieldDescriptor(field, this, (MessageDescriptor) null, index, true)));
    }

    internal void ConfigureWithDefaultOptions(CSharpFileOptions options)
    {
      this.csharpFileOptions = this.BuildOrFakeWithDefaultOptions(options);
    }

    private CSharpFileOptions BuildOrFakeWithDefaultOptions(CSharpFileOptions defaultOptions)
    {
      if (this.proto.Package == "google.protobuf")
      {
        switch (Path.GetFileName(this.proto.Name))
        {
          case "descriptor.proto":
            return new CSharpFileOptions.Builder()
            {
              Namespace = "Google.ProtocolBuffers.DescriptorProtos",
              UmbrellaClassname = "DescriptorProtoFile",
              NestClasses = false,
              MultipleFiles = false,
              PublicClasses = true,
              OutputDirectory = defaultOptions.OutputDirectory,
              IgnoreGoogleProtobuf = defaultOptions.IgnoreGoogleProtobuf
            }.Build();
          case "csharp_options.proto":
            return new CSharpFileOptions.Builder()
            {
              Namespace = "Google.ProtocolBuffers.DescriptorProtos",
              UmbrellaClassname = "CSharpOptions",
              NestClasses = false,
              MultipleFiles = false,
              PublicClasses = true,
              OutputDirectory = defaultOptions.OutputDirectory,
              IgnoreGoogleProtobuf = defaultOptions.IgnoreGoogleProtobuf
            }.Build();
        }
      }
      CSharpFileOptions.Builder builder = defaultOptions.ToBuilder();
      if (this.proto.Options.HasExtension<CSharpFileOptions>(Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.CSharpFileOptions))
        builder.MergeFrom(this.proto.Options.GetExtension<CSharpFileOptions>(Google.ProtocolBuffers.DescriptorProtos.CSharpOptions.CSharpFileOptions));
      if (!builder.HasNamespace)
        builder.Namespace = this.Package;
      if (!builder.HasUmbrellaClassname)
      {
        string text = this.Name.Substring(this.Name.LastIndexOf('/') + 1);
        builder.UmbrellaClassname = NameHelpers.UnderscoresToPascalCase(NameHelpers.StripProto(text));
      }
      if (!builder.NestClasses && !builder.HasUmbrellaNamespace)
      {
        bool flag = false;
        foreach (IDescriptor messageType in (IEnumerable<MessageDescriptor>) this.MessageTypes)
          flag |= messageType.Name == builder.UmbrellaClassname;
        foreach (IDescriptor service in (IEnumerable<ServiceDescriptor>) this.Services)
          flag |= service.Name == builder.UmbrellaClassname;
        foreach (IDescriptor enumType in (IEnumerable<EnumDescriptor>) this.EnumTypes)
          flag |= enumType.Name == builder.UmbrellaClassname;
        if (flag)
          builder.UmbrellaNamespace = "Proto";
      }
      return builder.Build();
    }

    public FileDescriptorProto Proto => this.proto;

    public Google.ProtocolBuffers.DescriptorProtos.FileOptions Options => this.proto.Options;

    public CSharpFileOptions CSharpOptions
    {
      get
      {
        lock (this.optionsLock)
        {
          if (this.csharpFileOptions == null)
            this.csharpFileOptions = this.BuildOrFakeWithDefaultOptions(CSharpFileOptions.DefaultInstance);
        }
        return this.csharpFileOptions;
      }
    }

    public string Name => this.proto.Name;

    public string Package => this.proto.Package;

    public IList<MessageDescriptor> MessageTypes => this.messageTypes;

    public IList<EnumDescriptor> EnumTypes => this.enumTypes;

    public IList<ServiceDescriptor> Services => this.services;

    public IList<FieldDescriptor> Extensions => this.extensions;

    public IList<FileDescriptor> Dependencies => this.dependencies;

    string IDescriptor.FullName => this.Name;

    FileDescriptor IDescriptor.File => this;

    IMessage IDescriptor.Proto => (IMessage) this.Proto;

    internal DescriptorPool DescriptorPool => this.pool;

    public T FindTypeByName<T>(string name) where T : class, IDescriptor
    {
      if (name.IndexOf('.') != -1)
        return default (T);
      if (this.Package.Length > 0)
        name = this.Package + "." + name;
      T symbol = this.pool.FindSymbol<T>(name);
      return (object) symbol != null && symbol.File == this ? symbol : default (T);
    }

    public static FileDescriptor BuildFrom(FileDescriptorProto proto, FileDescriptor[] dependencies)
    {
      if (dependencies == null)
        dependencies = new FileDescriptor[0];
      DescriptorPool pool = new DescriptorPool(dependencies);
      FileDescriptor problemDescriptor = new FileDescriptor(proto, dependencies, pool);
      if (dependencies.Length != proto.DependencyCount)
        throw new DescriptorValidationException((IDescriptor) problemDescriptor, "Dependencies passed to FileDescriptor.BuildFrom() don't match those listed in the FileDescriptorProto.");
      for (int index = 0; index < proto.DependencyCount; ++index)
      {
        if (dependencies[index].Name != proto.DependencyList[index])
          throw new DescriptorValidationException((IDescriptor) problemDescriptor, "Dependencies passed to FileDescriptor.BuildFrom() don't match those listed in the FileDescriptorProto.");
      }
      problemDescriptor.CrossLink();
      return problemDescriptor;
    }

    private void CrossLink()
    {
      foreach (MessageDescriptor messageType in (IEnumerable<MessageDescriptor>) this.messageTypes)
        messageType.CrossLink();
      foreach (ServiceDescriptor service in (IEnumerable<ServiceDescriptor>) this.services)
        service.CrossLink();
      foreach (FieldDescriptor extension in (IEnumerable<FieldDescriptor>) this.extensions)
        extension.CrossLink();
      foreach (MessageDescriptor messageType in (IEnumerable<MessageDescriptor>) this.messageTypes)
        messageType.CheckRequiredFields();
    }

    public static FileDescriptor InternalBuildGeneratedFileFrom(
      byte[] descriptorData,
      FileDescriptor[] dependencies)
    {
      return FileDescriptor.InternalBuildGeneratedFileFrom(descriptorData, dependencies, (FileDescriptor.InternalDescriptorAssigner) (x => (ExtensionRegistry) null));
    }

    public static FileDescriptor InternalBuildGeneratedFileFrom(
      byte[] descriptorData,
      FileDescriptor[] dependencies,
      FileDescriptor.InternalDescriptorAssigner descriptorAssigner)
    {
      FileDescriptorProto from1;
      try
      {
        from1 = FileDescriptorProto.ParseFrom(descriptorData);
      }
      catch (InvalidProtocolBufferException ex)
      {
        throw new ArgumentException("Failed to parse protocol buffer descriptor for generated code.", (Exception) ex);
      }
      FileDescriptor descriptor;
      try
      {
        descriptor = FileDescriptor.BuildFrom(from1, dependencies);
      }
      catch (DescriptorValidationException ex)
      {
        throw new ArgumentException("Invalid embedded descriptor for \"" + from1.Name + "\".", (Exception) ex);
      }
      ExtensionRegistry extensionRegistry = descriptorAssigner(descriptor);
      if (extensionRegistry != null)
      {
        FileDescriptorProto from2;
        try
        {
          from2 = FileDescriptorProto.ParseFrom(descriptorData, extensionRegistry);
        }
        catch (InvalidProtocolBufferException ex)
        {
          throw new ArgumentException("Failed to parse protocol buffer descriptor for generated code.", (Exception) ex);
        }
        descriptor.ReplaceProto(from2);
      }
      return descriptor;
    }

    private void ReplaceProto(FileDescriptorProto newProto)
    {
      this.proto = newProto;
      for (int index = 0; index < this.messageTypes.Count; ++index)
        this.messageTypes[index].ReplaceProto(this.proto.GetMessageType(index));
      for (int index = 0; index < this.enumTypes.Count; ++index)
        this.enumTypes[index].ReplaceProto(this.proto.GetEnumType(index));
      for (int index = 0; index < this.services.Count; ++index)
        this.services[index].ReplaceProto(this.proto.GetService(index));
      for (int index = 0; index < this.extensions.Count; ++index)
        this.extensions[index].ReplaceProto(this.proto.GetExtension(index));
    }

    public delegate ExtensionRegistry InternalDescriptorAssigner(FileDescriptor descriptor);
  }
}
