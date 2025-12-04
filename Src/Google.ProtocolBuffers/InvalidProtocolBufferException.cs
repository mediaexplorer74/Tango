// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.InvalidProtocolBufferException
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System.IO;

#nullable disable
namespace Google.ProtocolBuffers
{
  public sealed class InvalidProtocolBufferException : IOException
  {
    internal InvalidProtocolBufferException(string message)
      : base(message)
    {
    }

    internal static InvalidProtocolBufferException TruncatedMessage()
    {
      return new InvalidProtocolBufferException("While parsing a protocol message, the input ended unexpectedly in the middle of a field.  This could mean either than the input has been truncated or that an embedded message misreported its own length.");
    }

    internal static InvalidProtocolBufferException NegativeSize()
    {
      return new InvalidProtocolBufferException("CodedInputStream encountered an embedded string or message which claimed to have negative size.");
    }

    public static InvalidProtocolBufferException MalformedVarint()
    {
      return new InvalidProtocolBufferException("CodedInputStream encountered a malformed varint.");
    }

    internal static InvalidProtocolBufferException InvalidTag()
    {
      return new InvalidProtocolBufferException("Protocol message contained an invalid tag (zero).");
    }

    internal static InvalidProtocolBufferException InvalidEndTag()
    {
      return new InvalidProtocolBufferException("Protocol message end-group tag did not match expected tag.");
    }

    internal static InvalidProtocolBufferException InvalidWireType()
    {
      return new InvalidProtocolBufferException("Protocol message tag had invalid wire type.");
    }

    internal static InvalidProtocolBufferException RecursionLimitExceeded()
    {
      return new InvalidProtocolBufferException("Protocol message had too many levels of nesting.  May be malicious.  Use CodedInputStream.SetRecursionLimit() to increase the depth limit.");
    }

    internal static InvalidProtocolBufferException SizeLimitExceeded()
    {
      return new InvalidProtocolBufferException("Protocol message was too large.  May be malicious.  Use CodedInputStream.SetSizeLimit() to increase the size limit.");
    }

    internal static InvalidProtocolBufferException InvalidMessageStreamTag()
    {
      return new InvalidProtocolBufferException("Stream of protocol messages had invalid tag. Expected tag is length-delimited field 1.");
    }
  }
}
