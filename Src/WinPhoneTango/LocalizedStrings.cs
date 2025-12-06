// UWP-compatible LocalizedStrings class
using Windows.ApplicationModel.Resources;

#nullable disable
namespace WinPhoneTango
{
  public class LocalizedStrings
  {
    private static ResourceLoader _resourceLoader = ResourceLoader.GetForViewIndependentUse("LangResource");

    public ResourceLoader LocalizedResources => _resourceLoader;
  }
}
