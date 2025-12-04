// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.DescriptorProtos.CSharpOptions
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using System;

#nullable disable
namespace Google.ProtocolBuffers.DescriptorProtos
{
  public static class CSharpOptions
  {
    public const int CSharpFileOptionsFieldNumber = 1000;
    public const int CSharpFieldOptionsFieldNumber = 1000;
    public static GeneratedExtensionBase<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions> CSharpFileOptions;
    public static GeneratedExtensionBase<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions> CSharpFieldOptions;
    internal static MessageDescriptor internal__static_google_protobuf_CSharpFileOptions__Descriptor;
    internal static FieldAccessorTable<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions, Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions.Builder> internal__static_google_protobuf_CSharpFileOptions__FieldAccessorTable;
    internal static MessageDescriptor internal__static_google_protobuf_CSharpFieldOptions__Descriptor;
    internal static FieldAccessorTable<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions, Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions.Builder> internal__static_google_protobuf_CSharpFieldOptions__FieldAccessorTable;
    private static FileDescriptor descriptor;

    public static void RegisterAllExtensions(ExtensionRegistry registry)
    {
      registry.Add<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions>(CSharpOptions.CSharpFileOptions);
      registry.Add<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions>(CSharpOptions.CSharpFieldOptions);
    }

    public static FileDescriptor Descriptor => CSharpOptions.descriptor;

    static CSharpOptions()
    {
      FileDescriptor.InternalBuildGeneratedFileFrom(Convert.FromBase64String("CiRnb29nbGUvcHJvdG9idWYvY3NoYXJwX29wdGlvbnMucHJvdG8SD2dvb2dsZS5wcm90b2J1ZhogZ29vZ2xlL3Byb3RvYnVmL2Rlc2NyaXB0b3IucHJvdG8i6wIKEUNTaGFycEZpbGVPcHRpb25zEhEKCW5hbWVzcGFjZRgBIAEoCRIaChJ1bWJyZWxsYV9jbGFzc25hbWUYAiABKAkSHAoOcHVibGljX2NsYXNzZXMYAyABKAg6BHRydWUSFgoObXVsdGlwbGVfZmlsZXMYBCABKAgSFAoMbmVzdF9jbGFzc2VzGAUgASgIEhYKDmNvZGVfY29udHJhY3RzGAYgASgIEiQKHGV4cGFuZF9uYW1lc3BhY2VfZGlyZWN0b3JpZXMYByABKAgSHAoOY2xzX2NvbXBsaWFuY2UYCCABKAg6BHRydWUSHAoOZmlsZV9leHRlbnNpb24Y3QEgASgJOgMuY3MSGwoSdW1icmVsbGFfbmFtZXNwYWNlGN4BIAEoCRIcChBvdXRwdXRfZGlyZWN0b3J5GN8BIAEoCToBLhImChZpZ25vcmVfZ29vZ2xlX3Byb3RvYnVmGOABIAEoCDoFZmFsc2UiKwoSQ1NoYXJwRmllbGRPcHRpb25zEhUKDXByb3BlcnR5X25hbWUYASABKAk6XgoTY3NoYXJwX2ZpbGVfb3B0aW9ucxIcLmdvb2dsZS5wcm90b2J1Zi5GaWxlT3B0aW9ucxjoByABKAsyIi5nb29nbGUucHJvdG9idWYuQ1NoYXJwRmlsZU9wdGlvbnM6YQoUY3NoYXJwX2ZpZWxkX29wdGlvbnMSHS5nb29nbGUucHJvdG9idWYuRmllbGRPcHRpb25zGOgHIAEoCzIjLmdvb2dsZS5wcm90b2J1Zi5DU2hhcnBGaWVsZE9wdGlvbnM="), new FileDescriptor[1]
      {
        DescriptorProtoFile.Descriptor
      }, (FileDescriptor.InternalDescriptorAssigner) (root =>
      {
        CSharpOptions.descriptor = root;
        CSharpOptions.internal__static_google_protobuf_CSharpFileOptions__Descriptor = CSharpOptions.Descriptor.MessageTypes[0];
        CSharpOptions.internal__static_google_protobuf_CSharpFileOptions__FieldAccessorTable = new FieldAccessorTable<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions, Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions.Builder>(CSharpOptions.internal__static_google_protobuf_CSharpFileOptions__Descriptor, new string[12]
        {
          "Namespace",
          "UmbrellaClassname",
          "PublicClasses",
          "MultipleFiles",
          "NestClasses",
          "CodeContracts",
          "ExpandNamespaceDirectories",
          "ClsCompliance",
          "FileExtension",
          "UmbrellaNamespace",
          "OutputDirectory",
          "IgnoreGoogleProtobuf"
        });
        CSharpOptions.internal__static_google_protobuf_CSharpFieldOptions__Descriptor = CSharpOptions.Descriptor.MessageTypes[1];
        CSharpOptions.internal__static_google_protobuf_CSharpFieldOptions__FieldAccessorTable = new FieldAccessorTable<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions, Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions.Builder>(CSharpOptions.internal__static_google_protobuf_CSharpFieldOptions__Descriptor, new string[1]
        {
          "PropertyName"
        });
        CSharpOptions.CSharpFileOptions = (GeneratedExtensionBase<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions>) GeneratedSingleExtension<Google.ProtocolBuffers.DescriptorProtos.CSharpFileOptions>.CreateInstance(CSharpOptions.Descriptor.Extensions[0]);
        CSharpOptions.CSharpFieldOptions = (GeneratedExtensionBase<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions>) GeneratedSingleExtension<Google.ProtocolBuffers.DescriptorProtos.CSharpFieldOptions>.CreateInstance(CSharpOptions.Descriptor.Extensions[1]);
        return (ExtensionRegistry) null;
      }));
    }
  }
}
