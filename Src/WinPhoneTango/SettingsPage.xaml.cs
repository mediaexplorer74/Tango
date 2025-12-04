// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.SettingsPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Navigation;
using Tango.Messages;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  public partial class SettingsPage : TangoEventPageBase
  {
   

    public SettingsPage()
    {
      this.IsGoBackable = true;
      this.InitializeComponent();
    }

    private void imageProfileEdit_Click(object sender, RoutedEventArgs e)
    {
      RegisterUserPayload.Builder builder = RegisterUserPayload.CreateBuilder();
      builder.SetAccessAddressBook(true);
      TangoEventPageBase.SendMessage((ISendableMessage) new DisplayPersonalInfoMessage(TangoEventPageBase.GetNextSeqId(), builder));
    }

    public override void HandleTangoEvent(int messageId)
    {
      if (messageId != 35038)
        return;
      this.UpdateAlerts();
    }

    private void UpdateAlerts()
    {
      if (AppManager.Instance.DataManager.AlertsList != null && AppManager.Instance.DataManager.AlertsList.Count > 0)
      {
        ((UIElement) this.panelAlerts).Visibility = Visibility.Visible;
        OperationalAlert alerts = AppManager.Instance.DataManager.AlertsList[0];
        this.alertTitleText.Text = alerts.Title;
        this.alertDescText.Text = alerts.Message;
      }
      else
        ((UIElement) this.panelAlerts).Visibility = Visibility.Collapsed;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      this.Assert((object) AppManager.Instance.DataManager.UserData);
      if (AppManager.Instance.DataManager.UserData != null && AppManager.Instance.DataManager.UserData.Contact != null)
      {
        Contact contact = AppManager.Instance.DataManager.UserData.Contact;
        this.nameText.Text = (contact.HasFirstname ? contact.Firstname : "") + " " + (contact.HasLastname ? contact.Lastname : "");
        this.phoneText.Text = !contact.HasPhoneNumber || !contact.PhoneNumber.HasSubscriberNumber ? "" : (contact.PhoneNumber.HasCountryCode ? "+" + contact.PhoneNumber.CountryCode.CountryCodeNumber : "") + contact.PhoneNumber.SubscriberNumber;
        this.emailText.Text = contact.HasEmail ? contact.Email : "";
        this.version.Text = AppManager.Instance.EngineCom.Version;
      }
      this.UpdateAlerts();
    }

    
  }
}
