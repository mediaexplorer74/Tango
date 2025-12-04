// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.CustomThemeColorHelper
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Collections;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI;
using Windows.UI.Xaml.Media;

#nullable disable
namespace WinPhoneTango
{
  public static class CustomThemeColorHelper
  {
    private static Dictionary<object, Color> _themeColorDic = new Dictionary<object, Color>();
    private static Dictionary<object, SolidColorBrush> _themeBrushDic = new Dictionary<object, SolidColorBrush>();
    private static bool _loaded = false;

    private static void LoadCustomeThemeColor()
    {
      if (CustomThemeColorHelper._loaded)
        return;
      
      CustomThemeColorHelper._themeColorDic.Clear();
      CustomThemeColorHelper._themeBrushDic.Clear();
      
      // Add default colors and brushes directly instead of loading from external file
      CustomThemeColorHelper._themeColorDic.Add("TangoOrangeColor", Color.FromArgb(255, 255, 70, 30)); // #FFFF461E
      CustomThemeColorHelper._themeColorDic.Add("TangoForegroundColor", Colors.White);
      CustomThemeColorHelper._themeColorDic.Add("TangoBackgroundColor", Colors.Black);
      CustomThemeColorHelper._themeColorDic.Add("TangoChromeColor", Color.FromArgb(255, 31)); // #FF1F1F1F
      CustomThemeColorHelper._themeColorDic.Add("TangoDisabledColor", Color.FromArgb(102, 255, 255, 255)); // #66FFFFFF
      
      // Create corresponding brushes
      CustomThemeColorHelper._themeBrushDic.Add("TangoOrangeBrush", new SolidColorBrush(Color.FromArgb(255, 255, 70, 30)));
      CustomThemeColorHelper._themeBrushDic.Add("TangoForegroundBrush", new SolidColorBrush(Colors.White));
      CustomThemeColorHelper._themeBrushDic.Add("TangoBackgroundBrush", new SolidColorBrush(Colors.Black));
      CustomThemeColorHelper._themeBrushDic.Add("TangoChromeBrush", new SolidColorBrush(Color.FromArgb(255, 31)));
      CustomThemeColorHelper._themeBrushDic.Add("TangoDisabledBrush", new SolidColorBrush(Color.FromArgb(102, 255, 255, 255)));
      
      CustomThemeColorHelper._loaded = true;
    }

    public static void ApplyThemeColorToResource(ResourceDictionary resource)
    {
      if (!CustomThemeColorHelper._loaded)
        CustomThemeColorHelper.LoadCustomeThemeColor();
      if (resource == null)
        return;
      foreach (KeyValuePair<object, Color> keyValuePair in CustomThemeColorHelper._themeColorDic)
      {
        resource.Remove(keyValuePair.Key);
        resource.Add(keyValuePair.Key, (object) keyValuePair.Value);
      }
      foreach (KeyValuePair<object, SolidColorBrush> keyValuePair in CustomThemeColorHelper._themeBrushDic)
      {
        if (resource[keyValuePair.Key] is SolidColorBrush solidColorBrush)
          solidColorBrush.Color = keyValuePair.Value.Color;
      }
    }
  }
}
