// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.VideoMailPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

#nullable disable
namespace WinPhoneTango
{
  public partial class VideoMailPage : TangoEventPageBase
  {
    
    public VideoMailPage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
      this.LoadVideoMailList();
    }

    private void LoadVideoMailList()
    {
      List<DisplayableContact> source = new List<DisplayableContact>();
      for (int index = 0; index < 6; ++index)
        source.Add(DisplayableContact.CreateRandomly());
      this.listSelectorMail.ItemsSource = source.OrderByDescending(mail => mail.LastCallStartTime);
    }

    private void listSelectorMail_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (!(this.listSelectorMail.SelectedItem is DisplayableContact selectedItem))
        return;
      Frame.Navigate(typeof(VideoMailViewPage), "name=" + selectedItem.Name);
    }

  
  }
}
