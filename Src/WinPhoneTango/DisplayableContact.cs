// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.DisplayableContact
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using sgiggle.xmpp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Tango.Toolbox;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public class DisplayableContact : INotifyPropertyChanged, IComparable<DisplayableContact>
  {
    private static Random _rnd = new Random((int) DateTime.Now.TimeOfDay.TotalSeconds);
    private static readonly string INITIAL_NAME_NUMBERS_AND_SPECIAL = "#";
    private static readonly string INITIAL_NAME_GLOBAL = "\uD83C\uDF10";
    private static readonly string ISO_LANGUAGE_NAME_KOREAN = "ko";
    private static readonly string ISO_LANGUAGE_NAME_CHINESE = "zh";
    private static CultureInfo CULTURE = CultureInfo.CurrentCulture;
    public CallEntry BindedCallEntry;
    private static ulong BASE_TICKS = (ulong) new DateTime(1970, 1, 1).Ticks;
    private Visibility _visibility;
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _keyword = string.Empty;
    private ImageSource _photo;
    private bool _isSelected;

    public event PropertyChangedEventHandler PropertyChanged;

    public void PutName(string name)
    {
      this.Name = name;
      this.UpdateInitial();
    }

    private void PutNameOnly(string firstName, string lastName)
    {
      if (!string.IsNullOrEmpty(firstName))
      {
        this.Name = firstName;
        this.FirstName = firstName;
      }
      if (string.IsNullOrEmpty(lastName))
        return;
      DisplayableContact displayableContact = this;
      displayableContact.Name = displayableContact.Name + (firstName != null ? " " : "") + lastName;
      this.LastName = lastName;
    }

    public void PutNameEx(string firstName, string lastName, string mobile, string email)
    {
      this.Name = string.Empty;
      this.PutNameOnly(firstName, lastName);
      if (this.Name == string.Empty)
      {
        if (!string.IsNullOrEmpty(mobile))
          this.PutNameOnly(mobile, (string) null);
        else if (!string.IsNullOrEmpty(email))
          this.PutNameOnly(email, (string) null);
      }
      this.UpdateInitial();
    }

    private void UpdateInitial()
    {
      if (string.IsNullOrEmpty(this.Name))
      {
        this.InitialName = DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL;
      }
      else
      {
        char ch = this.Name[0];
        char grapheme;
        if (DisplayableContact.IsUsingChineseLanguage() && ChineseGraphemeMapper.Instance.GetFirstGraphemeOfCharacter(ch, out grapheme))
          this.InitialName = Convert.ToString(grapheme);
        else if (DisplayableContact.IsUsingKoreanLanguage() && KoreanGraphemeMapper.Instance.GetFirstGraphemeOfCharacter(ch, out grapheme))
          this.InitialName = Convert.ToString(grapheme);
        else if (char.IsLetter(ch) || ch > '\u0080')
          this.InitialName = char.ToLowerInvariant(ch).ToString();
        else
          this.InitialName = DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL;
      }
    }

    public void PutNameEx(string firstName, string lastName, object mobile, string email)
    {
      string subscriberNumber = mobile == null || mobile.SubscriberNumber == null || mobile.SubscriberNumber.Length <= 0 ? (string) null : mobile.SubscriberNumber;
      this.PutNameEx(firstName, lastName, subscriberNumber, email);
    }

    public void PutCall(object type, ulong startTime, uint duration)
    {
      this.IsLastCallMissed = type == CallEntry.Types.CallType.INBOUND_MISSED;
      this.LastCallColor = (Brush) new SolidColorBrush(this.IsLastCallMissed ? Colors.Red : Color.FromArgb(byte.MaxValue, (byte) 203, (byte) 203, (byte) 203));
      ulong startTicks = startTime * 10000000UL + DisplayableContact.BASE_TICKS;
      this.LastCallStartTime = startTicks;
      this.LastCallText = DisplayableContact.LastCallString(type, startTicks, duration);
    }

    public static string LastCallString(
      object type,
      ulong startTicks,
      uint duration)
    {
      DateTime dateTime = new DateTime((long) startTicks);
      dateTime = dateTime.ToLocalTime();
      string str1 = "";
      string str2;
      switch (type)
      {
        case CallEntry.Types.CallType.INBOUND_CONNECTED:
          str2 = str1 + LangResource.call_log_incoming;
          break;
        case CallEntry.Types.CallType.INBOUND_MISSED:
          str2 = str1 + LangResource.call_log_missed;
          break;
        default:
          str2 = str1 + LangResource.call_log_outgoing;
          break;
      }
      if (str2.Length > 0)
        str2 += ", ";
      DateTime now = DateTime.Now;
      string str3 = !(dateTime < now.AddHours(2.0)) || dateTime.Year != now.Year || dateTime.DayOfYear <= now.DayOfYear - 7 ? str2 + dateTime.ToString("M/d/yy") : str2 + dateTime.ToString("ddd h:mm tt");
      if (type != CallEntry.Types.CallType.INBOUND_MISSED)
      {
        string str4 = "";
        if (duration >= 3600U)
        {
          str4 = str4 + (object) (duration / 3600U) + LangResource.hour;
          duration %= 3600U;
        }
        if (duration >= 60U)
        {
          if (str4.Length > 0)
            str4 += " ";
          str4 = str4 + (object) (duration / 60U) + LangResource.minute;
          duration %= 60U;
        }
        if (str4.Length > 0)
          str4 += " ";
        string str5 = str4 + (object) duration + LangResource.second;
        str3 = str3 + ", (" + str5 + ")";
      }
      return str3;
    }

    public string Name { get; set; }

    public int DeviceContactId { get; set; }

    public Visibility Visibility
    {
      get => this._visibility;
      set
      {
        if (this._visibility == value)
          return;
        this._visibility = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Visibility)));
      }
    }

    public string FirstName
    {
      get => this._firstName;
      set
      {
        if (!(this._firstName != value))
          return;
        this._firstName = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (FirstName)));
      }
    }

    public string LastName
    {
      get => this._lastName;
      set
      {
        if (!(this._lastName != value))
          return;
        this._lastName = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (LastName)));
      }
    }

    public string Keyword
    {
      get => this._keyword;
      set
      {
        if (!(this._keyword != value))
          return;
        this._keyword = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Keyword)));
      }
    }

    public ImageSource Photo
    {
      get => this._photo;
      set
      {
        if (this._photo == value)
          return;
        this._photo = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (Photo)));
      }
    }

    public string InitialName { get; set; }

    public Visibility TangoIconVisible { get; set; }

    public string AccountId { get; set; }

    public object ContactData { get; set; }

    public string LastCallText { get; private set; }

    public Brush LastCallColor { get; private set; }

    public bool IsLastCallMissed { get; set; }

    public ulong LastCallStartTime { get; set; }

    public string InviteeInfo { get; set; }

    public bool IsSelected
    {
      get => this._isSelected;
      set
      {
        if (this._isSelected == value)
          return;
        this._isSelected = value;
        if (this.PropertyChanged == null)
          return;
        this.PropertyChanged((object) this, new PropertyChangedEventArgs(nameof (IsSelected)));
      }
    }

    public static DisplayableContact CreateRandomly()
    {
      DisplayableContact randomly = new DisplayableContact();
      int num1 = DisplayableContact._rnd.Next(10000);
      randomly.PutNameEx((string) null, (string) null, string.Concat((object) num1), (string) null);
      randomly.TangoIconVisible = DisplayableContact._rnd.Next(2) > 0 ? (Visibility) 0 : (Visibility) 1;
      CallEntry.Types.CallType type = (CallEntry.Types.CallType) DisplayableContact._rnd.Next(4);
      ulong startTime = ((ulong) DateTime.UtcNow.Ticks - DisplayableContact.BASE_TICKS) / 10000000UL - (ulong) DisplayableContact._rnd.Next(1209600);
      int num2 = DisplayableContact._rnd.Next(5);
      int duration = 0;
      switch (num2)
      {
        case 0:
          duration = 0;
          break;
        case 1:
          duration = DisplayableContact._rnd.Next(120);
          break;
        case 2:
          duration = DisplayableContact._rnd.Next(120, 600);
          break;
        case 3:
          duration = DisplayableContact._rnd.Next(600, 3600);
          break;
        case 4:
          duration = DisplayableContact._rnd.Next(3600, 7200);
          break;
      }
      randomly.PutCall(type, startTime, (uint) duration);
      return randomly;
    }

    public int CompareTo(DisplayableContact other)
    {
      if (!(this.InitialName != other.InitialName))
        return string.Compare(this.Name, other.Name, DisplayableContact.CULTURE, CompareOptions.IgnoreCase);
      if (this.InitialName == DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL)
        return 1;
      return other.InitialName == DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL ? -1 : string.Compare(this.InitialName, other.InitialName);
    }

    public static ObservableCollection<PublicGrouping<string, DisplayableContact>> SortByName(
      List<DisplayableContact> list)
    {
      if (list == null)
        return (ObservableCollection<PublicGrouping<string, DisplayableContact>>) null;
      Dictionary<string, PublicGrouping<string, DisplayableContact>> defaultGroups = DisplayableContact.GetDefaultGroups();
      ObservableCollection<PublicGrouping<string, DisplayableContact>> observableCollection = new ObservableCollection<PublicGrouping<string, DisplayableContact>>();
      if (list.Count > 0)
      {
        list.Sort();
        string key = (string) null;
        PublicGrouping<string, DisplayableContact> publicGrouping = (PublicGrouping<string, DisplayableContact>) null;
        foreach (DisplayableContact displayableContact in list)
        {
          if (displayableContact.InitialName != key)
          {
            key = displayableContact.InitialName;
            if (!defaultGroups.TryGetValue(key, out publicGrouping) && !defaultGroups.TryGetValue(DisplayableContact.INITIAL_NAME_GLOBAL, out publicGrouping))
            {
              Logger.Trace("[DisplayableContact::SortByName]Global group header not found in default group, skip");
              publicGrouping = (PublicGrouping<string, DisplayableContact>) null;
              key = (string) null;
              continue;
            }
          }
          publicGrouping.Add(displayableContact);
        }
      }
      return defaultGroups.Values.ToObservableCollection<PublicGrouping<string, DisplayableContact>>();
    }

    private static Dictionary<string, PublicGrouping<string, DisplayableContact>> GetDefaultGroups()
    {
      Dictionary<string, PublicGrouping<string, DisplayableContact>> groups = new Dictionary<string, PublicGrouping<string, DisplayableContact>>();
      DisplayableContact.AddLocalCharacterGroupHeaders(groups);
      groups.Add(DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL, new PublicGrouping<string, DisplayableContact>(DisplayableContact.INITIAL_NAME_NUMBERS_AND_SPECIAL));
      for (char ch = 'a'; ch <= 'z'; ++ch)
        groups.Add(ch.ToString(), new PublicGrouping<string, DisplayableContact>(ch.ToString()));
      groups.Add(DisplayableContact.INITIAL_NAME_GLOBAL, new PublicGrouping<string, DisplayableContact>(DisplayableContact.INITIAL_NAME_GLOBAL));
      return groups;
    }

    private static void AddLocalCharacterGroupHeaders(
      Dictionary<string, PublicGrouping<string, DisplayableContact>> groups)
    {
      if (groups == null || !DisplayableContact.IsUsingKoreanLanguage())
        return;
      for (int consonantIndex = 0; consonantIndex < KoreanLanguageHelper.KOREAN_HEADER_GRAPHEME_COUNT; ++consonantIndex)
      {
        if (!KoreanLanguageHelper.IsDuplicatedConsonants(consonantIndex))
        {
          string str = ((char) (consonantIndex + KoreanLanguageHelper.KOREAN_HEADER_GRAPHEME_START)).ToString();
          groups.Add(str, new PublicGrouping<string, DisplayableContact>(str));
        }
      }
    }

    private static bool IsUsingKoreanLanguage()
    {
      return DisplayableContact.CULTURE.TwoLetterISOLanguageName.Equals(DisplayableContact.ISO_LANGUAGE_NAME_KOREAN);
    }

    private static bool IsUsingChineseLanguage()
    {
      return DisplayableContact.CULTURE.TwoLetterISOLanguageName.Equals(DisplayableContact.ISO_LANGUAGE_NAME_CHINESE);
    }
  }
}
