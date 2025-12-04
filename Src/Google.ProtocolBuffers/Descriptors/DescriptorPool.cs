// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.Descriptors.DescriptorPool
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace Google.ProtocolBuffers.Descriptors
{
  internal sealed class DescriptorPool
  {
    private readonly IDictionary<string, IDescriptor> descriptorsByName = (IDictionary<string, IDescriptor>) new Dictionary<string, IDescriptor>();
    private readonly IDictionary<DescriptorPool.DescriptorIntPair, FieldDescriptor> fieldsByNumber = (IDictionary<DescriptorPool.DescriptorIntPair, FieldDescriptor>) new Dictionary<DescriptorPool.DescriptorIntPair, FieldDescriptor>();
    private readonly IDictionary<DescriptorPool.DescriptorIntPair, EnumValueDescriptor> enumValuesByNumber = (IDictionary<DescriptorPool.DescriptorIntPair, EnumValueDescriptor>) new Dictionary<DescriptorPool.DescriptorIntPair, EnumValueDescriptor>();
    private readonly DescriptorPool[] dependencies;
    private static readonly Regex ValidationRegex = new Regex("^[_A-Za-z][_A-Za-z0-9]*$", RegexOptions.None);

    internal DescriptorPool(FileDescriptor[] dependencyFiles)
    {
      this.dependencies = new DescriptorPool[dependencyFiles.Length];
      for (int index = 0; index < dependencyFiles.Length; ++index)
        this.dependencies[index] = dependencyFiles[index].DescriptorPool;
      foreach (FileDescriptor dependencyFile in dependencyFiles)
        this.AddPackage(dependencyFile.Package, dependencyFile);
    }

    internal T FindSymbol<T>(string fullName) where T : class, IDescriptor
    {
      IDescriptor descriptor;
      this.descriptorsByName.TryGetValue(fullName, out descriptor);
      if (descriptor is T symbol1)
        return symbol1;
      foreach (DescriptorPool dependency in this.dependencies)
      {
        dependency.descriptorsByName.TryGetValue(fullName, out descriptor);
        if (descriptor is T symbol2)
          return symbol2;
      }
      return default (T);
    }

    internal void AddPackage(string fullName, FileDescriptor file)
    {
      int length = fullName.LastIndexOf('.');
      string name;
      if (length != -1)
      {
        this.AddPackage(fullName.Substring(0, length), file);
        name = fullName.Substring(length + 1);
      }
      else
        name = fullName;
      IDescriptor descriptor;
      if (this.descriptorsByName.TryGetValue(fullName, out descriptor) && !(descriptor is PackageDescriptor))
        throw new DescriptorValidationException((IDescriptor) file, "\"" + name + "\" is already defined (as something other than a package) in file \"" + descriptor.File.Name + "\".");
      this.descriptorsByName[fullName] = (IDescriptor) new PackageDescriptor(name, fullName, file);
    }

    internal void AddSymbol(IDescriptor descriptor)
    {
      DescriptorPool.ValidateSymbolName(descriptor);
      string fullName = descriptor.FullName;
      IDescriptor descriptor1;
      if (this.descriptorsByName.TryGetValue(fullName, out descriptor1))
      {
        int length = fullName.LastIndexOf('.');
        string description;
        if (descriptor.File == descriptor1.File)
        {
          if (length == -1)
            description = "\"" + fullName + "\" is already defined.";
          else
            description = "\"" + fullName.Substring(length + 1) + "\" is already defined in \"" + fullName.Substring(0, length) + "\".";
        }
        else
          description = "\"" + fullName + "\" is already defined in file \"" + descriptor1.File.Name + "\".";
        throw new DescriptorValidationException(descriptor, description);
      }
      this.descriptorsByName[fullName] = descriptor;
    }

    private static void ValidateSymbolName(IDescriptor descriptor)
    {
      if (descriptor.Name == "")
        throw new DescriptorValidationException(descriptor, "Missing name.");
      if (!DescriptorPool.ValidationRegex.IsMatch(descriptor.Name))
        throw new DescriptorValidationException(descriptor, "\"" + descriptor.Name + "\" is not a valid identifier.");
    }

    internal FieldDescriptor FindFieldByNumber(MessageDescriptor messageDescriptor, int number)
    {
      FieldDescriptor fieldByNumber;
      this.fieldsByNumber.TryGetValue(new DescriptorPool.DescriptorIntPair((IDescriptor) messageDescriptor, number), out fieldByNumber);
      return fieldByNumber;
    }

    internal EnumValueDescriptor FindEnumValueByNumber(EnumDescriptor enumDescriptor, int number)
    {
      EnumValueDescriptor enumValueByNumber;
      this.enumValuesByNumber.TryGetValue(new DescriptorPool.DescriptorIntPair((IDescriptor) enumDescriptor, number), out enumValueByNumber);
      return enumValueByNumber;
    }

    internal void AddFieldByNumber(FieldDescriptor field)
    {
      DescriptorPool.DescriptorIntPair key = new DescriptorPool.DescriptorIntPair((IDescriptor) field.ContainingType, field.FieldNumber);
      FieldDescriptor fieldDescriptor;
      if (this.fieldsByNumber.TryGetValue(key, out fieldDescriptor))
        throw new DescriptorValidationException((IDescriptor) field, "Field number " + (object) field.FieldNumber + "has already been used in \"" + field.ContainingType.FullName + "\" by field \"" + fieldDescriptor.Name + "\".");
      this.fieldsByNumber[key] = field;
    }

    internal void AddEnumValueByNumber(EnumValueDescriptor enumValue)
    {
      DescriptorPool.DescriptorIntPair key = new DescriptorPool.DescriptorIntPair((IDescriptor) enumValue.EnumDescriptor, enumValue.Number);
      if (this.enumValuesByNumber.ContainsKey(key))
        return;
      this.enumValuesByNumber[key] = enumValue;
    }

    public IDescriptor LookupSymbol(string name, IDescriptor relativeTo)
    {
      IDescriptor symbol;
      if (name.StartsWith("."))
      {
        symbol = this.FindSymbol<IDescriptor>(name.Substring(1));
      }
      else
      {
        int length = name.IndexOf('.');
        string str = length == -1 ? name : name.Substring(0, length);
        StringBuilder stringBuilder = new StringBuilder(relativeTo.FullName);
        int num;
        while (true)
        {
          num = stringBuilder.ToString().LastIndexOf(".");
          if (num != -1)
          {
            stringBuilder.Length = num + 1;
            stringBuilder.Append(str);
            symbol = this.FindSymbol<IDescriptor>(stringBuilder.ToString());
            if (symbol == null)
              stringBuilder.Length = num;
            else
              goto label_6;
          }
          else
            break;
        }
        symbol = this.FindSymbol<IDescriptor>(name);
        goto label_9;
label_6:
        if (length != -1)
        {
          stringBuilder.Length = num + 1;
          stringBuilder.Append(name);
          symbol = this.FindSymbol<IDescriptor>(stringBuilder.ToString());
        }
      }
label_9:
      return symbol != null ? symbol : throw new DescriptorValidationException(relativeTo, "\"" + name + "\" is not defined.");
    }

    private struct DescriptorIntPair : IEquatable<DescriptorPool.DescriptorIntPair>
    {
      private readonly int number;
      private readonly IDescriptor descriptor;

      internal DescriptorIntPair(IDescriptor descriptor, int number)
      {
        this.number = number;
        this.descriptor = descriptor;
      }

      public bool Equals(DescriptorPool.DescriptorIntPair other)
      {
        return this.descriptor == other.descriptor && this.number == other.number;
      }

      public override bool Equals(object obj)
      {
        return obj is DescriptorPool.DescriptorIntPair other && this.Equals(other);
      }

      public override int GetHashCode()
      {
        return this.descriptor.GetHashCode() * (int) ushort.MaxValue + this.number;
      }
    }
  }
}
