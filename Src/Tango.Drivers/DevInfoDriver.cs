// UWP compatible stub - no Phone dependencies
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Tango.Drivers
{
  public class DevInfoDriver : IDevInfoDriver
  {
    public void device_id(byte[] buffer, int bufferSize, ref int actualSize)
    {
      string deviceId = "UWP-Device-Stub";
      byte[] deviceIdBytes = Encoding.UTF8.GetBytes(deviceId);
      actualSize = Math.Min(deviceIdBytes.Length, bufferSize);
      Array.Copy(deviceIdBytes, buffer, actualSize);
    }

    public void device_model(char[] buffer, int bufferSize, out int actualSize)
    {
      string deviceModel = "UWP-Model-Stub";
      char[] modelChars = deviceModel.ToCharArray();
      actualSize = Math.Min(modelChars.Length, bufferSize);
      Array.Copy(modelChars, buffer, actualSize);
    }

    public void subscriber_number(StringBuilder buffer, int bufferSize)
    {
      buffer.Append("UWP-Phone-Stub");
    }

    public void get_locale(char[] buffer, int bufferSize, out int actualSize)
    {
      string locale = "en-US";
      char[] localeChars = locale.ToCharArray();
      actualSize = Math.Min(localeChars.Length, bufferSize);
      Array.Copy(localeChars, buffer, actualSize);
    }

    public void Dispose()
    {
      // UWP stub - nothing to dispose
    }
  }
}
