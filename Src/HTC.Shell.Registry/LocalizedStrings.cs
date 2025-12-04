// UWP compatible stub - no resource dependencies
using HTC.Shell.Registry.Lang.Generic;
using System.Globalization;

#nullable disable
namespace HTC.Shell.Registry
{
  public class LocalizedStrings
  {
    private static HTC_Shell_Registry localizedresources = new HTC_Shell_Registry();

    public HTC_Shell_Registry Localizedresources => LocalizedStrings.localizedresources;

    public static string GetResourceString(string key)
    {
      // UWP stub - return key as value
      return key ?? "";
    }
  }
}
