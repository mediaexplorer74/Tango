// UWP compatible stub - no Phone dependencies
using System;
using System.Text;

#nullable disable
namespace HTC.Shell.Registry
{
  public class HTCRegistry
  {
    public static bool SetValue(string key, string value)
    {
      throw new NotSupportedException("Registry access not available in UWP");
    }

    public static string GetValue(string key)
    {
      throw new NotSupportedException("Registry access not available in UWP");
    }
  }
}
