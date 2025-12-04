// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.InviteContactPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Tango.Messages;

#nullable disable
namespace WinPhoneTango
{
  public partial class InviteContactPage : TangoEventPageBase
  {
    private bool _isWaitingForAppBack;
   

    public InviteContactPage()
    {
      this.InitializeComponent();
      this.LoadSelectionList();
    }

    public override void HandleTangoEvent(int messageId)
    {
      switch (messageId)
      {
        case 35057:
          if (this._isWaitingForAppBack)
          {
            this._isWaitingForAppBack = false;
            InviteSendPayload.Builder builder = InviteSendPayload.CreateBuilder();
            builder.SetSuccess(true);
            TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailSendMessage(TangoEventPageBase.GetNextSeqId(), builder));
            break;
          }
          this.Assert((object) AppManager.Instance.DataManager.EmailInfo);
          this._isWaitingForAppBack = true;
          InviteComposer.InviteByEmail(AppManager.Instance.DataManager.EmailInfo.InviteeList);
          break;
        case 35061:
          if (this._isWaitingForAppBack)
          {
            this._isWaitingForAppBack = false;
            InviteSendPayload.Builder builder = InviteSendPayload.CreateBuilder();
            builder.SetSuccess(true);
            TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSendMessage(TangoEventPageBase.GetNextSeqId(), builder));
            break;
          }
          this.Assert((object) AppManager.Instance.DataManager.SmsInfo);
          this._isWaitingForAppBack = true;
          InviteComposer.InviteBySms(AppManager.Instance.DataManager.SmsInfo.ContactList);
          break;
      }
    }

    private void LoadSelectionList()
    {
      List<DisplayableInviteSelection> displayableInviteSelectionList = new List<DisplayableInviteSelection>();
      if (AppManager.Instance.DataManager.InvitingContact == null)
        return;
      IList<Contact> contactsList = AppManager.Instance.DataManager.InvitingContact.ContactsList;
      for (int index = 0; index < contactsList.Count; ++index)
      {
        if (contactsList[index].PhoneNumber != null && contactsList[index].PhoneNumber.SubscriberNumber != null && contactsList[index].PhoneNumber.SubscriberNumber.Length > 0)
          displayableInviteSelectionList.Add(new DisplayableInviteSelection(DisplayableInviteSelection.InviteType.InviteBySms, contactsList[index].PhoneNumber.SubscriberNumber, contactsList[index]));
      }
      for (int index = 0; index < contactsList.Count; ++index)
      {
        if (contactsList[index].Email != null && contactsList[index].Email.Length > 0)
          displayableInviteSelectionList.Add(new DisplayableInviteSelection(DisplayableInviteSelection.InviteType.InviteByEmail, contactsList[index].Email, contactsList[index]));
      }
      ((ItemsControl) this.inviteListBox).ItemsSource = (IEnumerable) displayableInviteSelectionList;
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      e.Cancel = true;
      if (this.WaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
      TangoEventPageBase.SendMessage((ISendableMessage) new EndStateNoChangeMessage(TangoEventPageBase.GetNextSeqId(), OptionalPayload.CreateBuilder()));
    }

    private void inviteListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (((Selector) this.inviteListBox).SelectedIndex < 0)
        return;
      DisplayableInviteSelection selectedItem = ((Selector) this.inviteListBox).SelectedItem as DisplayableInviteSelection;
      if (selectedItem.Type == DisplayableInviteSelection.InviteType.InviteBySms)
      {
        InviteSMSSelectedPayload.Builder builder = InviteSMSSelectedPayload.CreateBuilder();
        builder.AddContact(selectedItem.ContactData);
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteSMSSelectedMessage(TangoEventPageBase.GetNextSeqId(), builder));
      }
      else
      {
        InviteContactsSelectedPayload.Builder builder1 = InviteContactsSelectedPayload.CreateBuilder();
        Invitee.Builder builder2 = Invitee.CreateBuilder();
        builder2.SetEmail(selectedItem.ContactData.Email);
        builder2.SetFirstname(selectedItem.ContactData.Firstname);
        builder2.SetLastname(selectedItem.ContactData.Lastname);
        builder2.SetPhonenumber(selectedItem.ContactData.PhoneNumber != null ? selectedItem.ContactData.PhoneNumber.SubscriberNumber : string.Empty);
        builder1.AddInvitee(builder2.Build());
        TangoEventPageBase.SendMessage((ISendableMessage) new InviteEmailComposerMessage(TangoEventPageBase.GetNextSeqId(), builder1));
      }
    }

    
  }
}
