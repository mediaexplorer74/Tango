// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.RegisterPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;
using Windows.ApplicationModel.Resources;

#nullable disable
namespace WinPhoneTango
{
  public partial class RegisterPage : TangoEventPageBase
  {
    public static readonly string NAVIGATION_EDITMODE_PARAM = "isEditMode";
    private static readonly string KeyMobile = "RegMobile";
    private static readonly string KeyFirstName = "RegFirstName";
    private static readonly string KeyLastName = "RegLastName";
    private static readonly string KeyEmail = "RegEmail";
    private static readonly string KeySaveSwitch = "RegSaveSwitch";
    private static readonly string EmailValidationRegex = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
    private bool _isEditMode;
    private int _formattingRequestInAir;
    private string _formattedPhoneNumber;
    private string _currentCountryCode = string.Empty;
    private double _contentPanelHeight;
    private double _scrollerYOffset;
    private double _currentTextBoxY;
    private double _contentPanelTop;
    
    
    

    public RegisterPage()
    {
      this.IsGoBackable = true;
      this.InitializeComponent();
      this.UpdateCountryText(AppManager.Instance.DataManager.PhoneCountryId);
      // Initialize UI elements in XAML instead of code-behind
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      // Save form data to application state
      AppManager.Instance.DataManager.RegistrationFormData = new RegistrationData
      {
        Mobile = this.textBoxMobile.Text,
        FirstName = this.textBoxFirstName.Text,
        LastName = this.textBoxLastName.Text,
        Email = this.textBoxEmail.Text,
        SaveContact = this.switchSaveContact.IsOn
      };
      base.OnNavigatedFrom(e);
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      // Restore form data if available
      if (AppManager.Instance.DataManager.RegistrationFormData != null)
      {
        var data = AppManager.Instance.DataManager.RegistrationFormData;
        this.textBoxMobile.Text = data.Mobile ?? string.Empty;
        this.textBoxFirstName.Text = data.FirstName ?? string.Empty;
        this.textBoxLastName.Text = data.LastName ?? string.Empty;
        this.textBoxEmail.Text = data.Email ?? string.Empty;
        this.switchSaveContact.IsOn = data.SaveContact;
      }
      
      string countryCodeNumber = this.UpdateCountryText(AppManager.Instance.DataManager.SelectedCountryId);
      if (!string.IsNullOrEmpty(this.textBoxMobile.Text))
        this.SendRequestPhoneFormattingMessage(this.textBoxMobile.Text, countryCodeNumber);
    }

    public override void HandleTangoEvent(int messageId)
    {
      switch (messageId)
      {
        case 35051:
          this.ShowWaitingForResultUI(false);
          break;
        case 35087:
          --this._formattingRequestInAir;
          if (this._formattingRequestInAir > 0)
            break;
          this._formattingRequestInAir = 0;
          this._formattedPhoneNumber = AppManager.Instance.DataManager.LastFormattedNumber;
          this.textBoxMobile.Text = AppManager.Instance.DataManager.LastFormattedNumber;
          if (this.textBoxMobile.Text.Length <= 0)
            break;
          this.textBoxMobile.SelectionStart = this.textBoxMobile.Text.Length;
          break;
        case 35090:
          this.ShowWaitingForResultUI(false);
          break;
      }
    }

    private void buttonSubmit_Click(object sender, RoutedEventArgs e)
    {
      if (this.WaitingForClickResult)
        return;
      if (this.textBoxEmail.Text.Length > 0 && !new Regex(RegisterPage.EmailValidationRegex).IsMatch(this.textBoxEmail.Text))
      {
        // Use UWP equivalent for MessageBox
        var dialog = new Windows.UI.Popups.MessageDialog(ResourceLoader.GetForCurrentView("LangResource").GetString("email_invalid_msg"));
        dialog.ShowAsync();
      }
      else
      {
        var builder1 = RegisterUserPayload.CreateBuilder();
        builder1.SetAccessAddressBook(true);
        builder1.SetStoreAddressBook(this.switchSaveContact.IsOn);
        string str = CultureInfo.CurrentCulture.Name.Replace('-', '_');
        builder1.SetLocale(str);
        var builder2 = Contact.CreateBuilder();
        builder2.SetLastname(this.textBoxLastName.Text);
        builder2.SetFirstname(this.textBoxFirstName.Text);
        builder2.SetEmail(this.textBoxEmail.Text);
        var builder3 = PhoneNumber.CreateBuilder();
        var builder4 = CountryCode.CreateBuilder();
        this.Assert((object) AppManager.Instance.DataManager.UserData);
        var countryCodeList = AppManager.Instance.DataManager.UserData.CountryCodeList;
        bool flag = false;
        for (int index = 0; index < countryCodeList.Count; ++index)
        {
          if (countryCodeList[index].Countryid.Equals(AppManager.Instance.DataManager.SelectedCountryId))
          {
            builder3.SetCountryCode(countryCodeList[index]);
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          builder4.SetCountryname("US");
          builder4.SetCountrycodenumber("1");
          builder4.SetCountryid("1");
          builder3.SetCountryCode(builder4.Build());
        }
        builder3.SetSubscriberNumber(this.textBoxMobile.Text);
        builder2.SetPhoneNumber(builder3.Build());
        builder1.SetContact(builder2.Build());
        if (this._isEditMode)
          TangoEventPageBase.SendMessage((ISendableMessage) new SavePersonalInfoMessage(TangoEventPageBase.GetNextSeqId(), builder1));
        else
          TangoEventPageBase.SendMessage((ISendableMessage) new RegisterMessage(TangoEventPageBase.GetNextSeqId(), builder1));
        this.ShowWaitingForResultUI(true);
      }
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      if (this._isEditMode)
      {
        if (!this.WaitingForClickResult)
        {
          this.WaitingForClickResult = true;
          TangoEventPageBase.SendMessage((ISendableMessage) new EndStateNoChangeMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
        }
        e.Cancel = true;
      }
      else
        base.OnBackKeyPress(e);
    }

    private void textBoxMobile_TextChanged(object sender, TextChangedEventArgs e)
    {
      this.CheckToEnableSubmitButton();
      string text = this.textBoxMobile.Text;
      if (text.Length <= 0 || text.Equals(this._formattedPhoneNumber))
        return;
      this.SendRequestPhoneFormattingMessage(text, this._currentCountryCode);
    }

    private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
      this.CheckToEnableSubmitButton();
    }

    private void CheckToEnableSubmitButton()
    {
      if (this.buttonSubmit.IsEnabled && this.textBoxMobile.Text.Length == 0)
      {
        this.buttonSubmit.IsEnabled = false;
      }
      else
      {
        if (this.buttonSubmit.IsEnabled || this.textBoxMobile.Text.Length <= 0)
          return;
        this.buttonSubmit.IsEnabled = true;
      }
    }

    private void SendRequestPhoneFormattingMessage(string toFormatNumber, string countryCodeNumber)
    {
      if (toFormatNumber.Length == 0)
        return;
      var builder = RequestPhoneFormattingPayload.CreateBuilder();
      builder.SetNumber(toFormatNumber);
      if (countryCodeNumber.Length > 0)
        builder.SetCountrycode(countryCodeNumber);
      ++this._formattingRequestInAir;
      TangoEventPageBase.SendMessage((ISendableMessage) new RequestPhoneFormattingMessage(TangoEventPageBase.GetNextSeqId(), builder));
    }

    private void ShowWaitingForResultUI(bool IsToShow)
    {
      if (IsToShow)
      {
        this.StartLoadingProgress(this.waitingBar);
      }
      else
      {
        this.StopLoadingProgress();
      }
    }

    // Removed InitializeComponent method to prevent conflicts with XAML-generated code
  }
  
  // Helper class to store registration form data
  public class RegistrationData
  {
    public string Mobile { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool SaveContact { get; set; }
  }
}
