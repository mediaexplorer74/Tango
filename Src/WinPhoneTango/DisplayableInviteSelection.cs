// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.DisplayableInviteSelection
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;

#nullable disable
namespace WinPhoneTango
{
  public class DisplayableInviteSelection
  {
    public DisplayableInviteSelection.InviteType Type { get; private set; }

    public string TypeText { get; private set; }

    public string ValueText { get; private set; }

    public object ContactData { get; private set; }

    public DisplayableInviteSelection(
      DisplayableInviteSelection.InviteType type,
      string value,
      object contact)
    {
      this.Set(type, value, contact);
    }

    public void Set(DisplayableInviteSelection.InviteType type, string value, object contact)
    {
      this.TypeText = type != DisplayableInviteSelection.InviteType.InviteBySms ? "Send Email to" : "Send SMS to";
      this.Type = type;
      this.ValueText = value;
      this.ContactData = contact;
    }

    public enum InviteType
    {
      InviteBySms,
      InviteByEmail,
    }
  }
}
