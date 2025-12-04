// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.HintTextBox
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI; // For Colors
// using Windows.System; // For VirtualKey, commented out as numeric array is commented out

#nullable disable
namespace Tango.Toolbox
{
  public class HintTextBox : TextBox, IAppearanceChangeMonitable
  {
    public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register(nameof (HintText), typeof (string), typeof (HintTextBox), (PropertyMetadata) null);
    public static readonly DependencyProperty ActiveBackgroundProperty = DependencyProperty.Register(nameof (ActiveBackground), typeof (Brush), typeof (HintTextBox), (PropertyMetadata) null);
    public static Color DefaultForegroundColor = Tango.Toolbox.Color.LightGray;
    public static Color DefaultBackgroundColor = Tango.Toolbox.Color.FromArgb(255, 191, 191, 191);
    public static Color DefaultActiveBackgroundColor = Tango.Toolbox.Color.Blue;
    private bool _isLoaded;
    private bool _isHintShown;
    private string _previousText = string.Empty;
    private Brush _defaultForeground;
    private Brush _defaultBackground;
    private Brush _defaultActiveBackground;
    // private readonly Key[] numeric = new Key[13]
    // {
    //   (Key) 1,
    //   (Key) 68,
    //   (Key) 69,
    //   (Key) 70,
    //   (Key) 71,
    //   (Key) 72,
    //   (Key) 73,
    //   (Key) 74,
    //   (Key) 75,
    //   (Key) 76,
    //   (Key) 77,
    //   (Key) 79,
    //   (Key) 78
    // };
    private bool _isAppearanceChanged;

    public event EventHandler<Windows.UI.Xaml.RoutedEventArgs> EnterKeyPress;

    public event TextChangedEventHandler TextChangedEx;

    public bool HasFocus { get; private set; }

    public string HintText
    {
      get => (string) ((DependencyObject) this).GetValue(HintTextBox.HintTextProperty);
      set => ((DependencyObject) this).SetValue(HintTextBox.HintTextProperty, (object) value);
    }

    public Brush ActiveBackground
    {
      get => (Brush) ((DependencyObject) this).GetValue(HintTextBox.ActiveBackgroundProperty);
      set
      {
        ((DependencyObject) this).SetValue(HintTextBox.ActiveBackgroundProperty, (object) value);
      }
    }

    public string Text
    {
      get => this._isHintShown ? "" : base.Text;
      set
      {
        if (this.HasFocus || value.Length > 0)
        {
          if (this._isLoaded)
            this.HideHintText(true);
          this._isHintShown = false;
          base.Text = value;
        }
        else if (this._isLoaded)
          this.ShowHintText(true);
        this._isAppearanceChanged = true;
      }
    }

    public bool DisableFocus { get; set; }

    public bool IsNumericOnly { get; set; }

    public bool IsInitialUpperCase { get; set; }

    public bool IsEmailAddress { get; set; }

    public HintTextBox()
    {
      this.HintText = string.Empty;
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.OnInit);
    }

    bool IAppearanceChangeMonitable.GetAndResetIsChangedFlag()
    {
      bool appearanceChanged = this._isAppearanceChanged;
      this._isAppearanceChanged = false;
      return appearanceChanged;
    }

    private void OnInit(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      if (this._isLoaded)
        return;
      this.Loaded -= new RoutedEventHandler(this.OnInit);
      this._isLoaded = true;
      this._defaultForeground = ((Control) this).Foreground != null ? ((Control) this).Foreground : new SolidColorBrush(Windows.UI.Colors.LightGray);
      ((Control) this).Foreground = this._defaultForeground;
      this._defaultBackground = ((Control) this).Background != null ? ((Control) this).Background : new SolidColorBrush(Windows.UI.Color.FromArgb(255, 191, 191, 191));
      ((Control) this).Background = this._defaultBackground;
      this._defaultActiveBackground = this.ActiveBackground != null ? this.ActiveBackground : new SolidColorBrush(Windows.UI.Colors.Blue);
      this.ActiveBackground = this._defaultActiveBackground;
      if (this.IsNumericOnly)
      {
        this.InputScope = new InputScope();
        this.InputScope.Names.Add(new InputScopeName()
        {
          NameValue = (InputScopeNameValue) 32
        });
      }
      else if (this.IsInitialUpperCase)
      {
        this.InputScope = new InputScope();
        this.InputScope.Names.Add(new InputScopeName()
        {
          NameValue = (InputScopeNameValue) 7
        });
      }
      else if (this.IsEmailAddress)
      {
        this.InputScope = new InputScope();
        this.InputScope.Names.Add(new InputScopeName()
        {
          NameValue = (InputScopeNameValue) 53
        });
      }
      if (base.Text.Length == 0 && this.HintText.Length > 0)
        this.ShowHintText(true);
      this._previousText = this.Text;
      this.TextChanged += new TextChangedEventHandler(this.OnTextChanged);
      if (!string.IsNullOrEmpty(this._previousText))
        this.OnTextChanged((object) this, (TextChangedEventArgs) null);
      this._isAppearanceChanged = true;
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
      if (this._previousText.Equals(this.Text))
        return;
      this._previousText = this.Text;
      if (this.TextChangedEx != null)
        this.TextChangedEx(sender, e);
      this._isAppearanceChanged = true;
    }

    protected virtual void OnKeyDown(Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
    {
      base.OnKeyDown(e);
      if (this.EnterKeyPress != null && e.Key == Windows.System.VirtualKey.Number3) // Assuming Key 3 was intended for a numeric key
        this.EnterKeyPress((object) this, new Windows.UI.Xaml.RoutedEventArgs());
      this._isAppearanceChanged = true;
    }

    protected virtual void OnGotFocus(Windows.UI.Xaml.RoutedEventArgs e)
    {
      this.HasFocus = true;
      if (!this.DisableFocus)
        base.OnGotFocus(e);
      this.HideHintText();
      ((Control) this).Background = this._defaultActiveBackground;
      this._isAppearanceChanged = true;
    }

    protected virtual void OnLostFocus(Windows.UI.Xaml.RoutedEventArgs e)
    {
      this.HasFocus = false;
      this.ShowHintText();
      ((Control) this).Background = this._defaultBackground;
      base.OnLostFocus(e);
      this._isAppearanceChanged = true;
    }

    private void ShowHintText(bool isForce = false)
    {
      if (!isForce && (this._isHintShown || base.Text.Length > 0))
        return;
      this._isHintShown = true;
      base.Text = this.HintText;
      ((Control) this).Foreground = (Brush) new SolidColorBrush(Colors.Gray);
      this._isAppearanceChanged = true;
    }

    private void HideHintText(bool isForce = false)
    {
      if (!isForce && (!this._isHintShown || base.Text.Length <= 0))
        return;
      this._isHintShown = false;
      base.Text = "";
      ((Control) this).Foreground = this._defaultForeground;
      this._isAppearanceChanged = true;
    }
  }
}