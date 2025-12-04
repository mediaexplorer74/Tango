// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.Data.GroupForegroundBrushColorConverter
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango.Data
{
  public class GroupForegroundBrushColorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      PublicGrouping<string, DisplayableContact> publicGrouping = value as PublicGrouping<string, DisplayableContact>;
      object obj = (object) new SolidColorBrush(Colors.White);
      if (publicGrouping != null && publicGrouping.Count == 0)
        obj = (object) (SolidColorBrush) Application.Current.Resources[(object) "TangoDisabledBrush"];
      return obj;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      string language)
    {
      throw new NotImplementedException();
    }
  }
}
