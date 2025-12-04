// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.ImageButton
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
// using System.Windows.Resources;

#nullable disable
namespace Tango.Toolbox
{
  public partial class ImageButton : UserControl, IAppearanceChangeMonitable
  {
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty TextMarginProperty = DependencyProperty.Register(nameof (TextMargin), typeof (Thickness), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty TextHorizontalAlignmentProperty = DependencyProperty.Register(nameof (TextHorizontalAlignment), typeof (HorizontalAlignment), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(nameof (Padding), typeof (Thickness), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty BackGroundImageProperty = DependencyProperty.Register(nameof (BackGroundImage), typeof (ImageSource), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty BackGroundImageHitProperty = DependencyProperty.Register(nameof (BackGroundImageHit), typeof (ImageSource), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty BackGroundImageDisabledProperty = DependencyProperty.Register(nameof (BackGroundImageDisabled), typeof (ImageSource), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(nameof (Stretch), typeof (Stretch), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty IsPushButtonProperty = DependencyProperty.Register(nameof (IsPushButton), typeof (bool), typeof (ImageButton), (PropertyMetadata) null);
    public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register(nameof (IsChecked), typeof (bool), typeof (ImageButton), (PropertyMetadata) null);
    private bool _isAppearanceChanged;
    // internal Grid LayoutRoot;
    // internal Image innerImage;
    // internal TextBlock innerText;
    // private bool _contentLoaded;

    public event EventHandler<RoutedEventArgs> Click;

    public string Text
    {
      get => (string) ((DependencyObject) this).GetValue(ImageButton.TextProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.TextProperty, (object) value);
        this.innerText.Text = value;
        this._isAppearanceChanged = true;
      }
    }

    public Thickness TextMargin
    {
      get => (Thickness) ((DependencyObject) this).GetValue(ImageButton.TextMarginProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.TextMarginProperty, (object) value);
        ((FrameworkElement) this.innerText).Margin = value;
        this._isAppearanceChanged = true;
      }
    }

    public HorizontalAlignment TextHorizontalAlignment
    {
      get
      {
        return (HorizontalAlignment) ((DependencyObject) this).GetValue(ImageButton.TextHorizontalAlignmentProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.TextHorizontalAlignmentProperty, (object) value);
        ((FrameworkElement) this.innerText).HorizontalAlignment = value;
        this._isAppearanceChanged = true;
      }
    }

    public ImageSource BackGroundImage
    {
      get => (ImageSource) ((DependencyObject) this).GetValue(ImageButton.BackGroundImageProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.BackGroundImageProperty, (object) value);
        this.innerImage.Source = this.BackGroundImage;
        this._isAppearanceChanged = true;
      }
    }

    public ImageSource BackGroundImageHit
    {
      get
      {
        return (ImageSource) ((DependencyObject) this).GetValue(ImageButton.BackGroundImageHitProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.BackGroundImageHitProperty, (object) value);
      }
    }

    public ImageSource BackGroundImageDisabled
    {
      get
      {
        return (ImageSource) ((DependencyObject) this).GetValue(ImageButton.BackGroundImageDisabledProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.BackGroundImageDisabledProperty, (object) value);
      }
    }

    public Stretch Stretch
    {
      get => (Stretch) ((DependencyObject) this).GetValue(ImageButton.StretchProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.StretchProperty, (object) value);
        this.innerImage.Stretch = this.Stretch;
        this._isAppearanceChanged = true;
      }
    }

    public Thickness Padding
    {
      get => (Thickness) ((DependencyObject) this).GetValue(ImageButton.PaddingProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.PaddingProperty, (object) value);
        ((FrameworkElement) this.innerImage).Margin = value;
        this._isAppearanceChanged = true;
      }
    }

    public bool IsPushButton
    {
      get => (bool) ((DependencyObject) this).GetValue(ImageButton.IsPushButtonProperty);
      set => ((DependencyObject) this).SetValue(ImageButton.IsPushButtonProperty, (object) value);
    }

    public bool IsChecked
    {
      get => (bool) ((DependencyObject) this).GetValue(ImageButton.IsCheckedProperty);
      set
      {
        ((DependencyObject) this).SetValue(ImageButton.IsCheckedProperty, (object) value);
        if (!this.IsPushButton)
          return;
        this.innerImage.Source = value ? this.BackGroundImageHit : this.BackGroundImage;
        this._isAppearanceChanged = true;
      }
    }

    public bool IsStateLocked { get; set; }

    public ImageButton()
    {
      // this.InitializeComponent();
      ((Control) this).IsEnabledChanged += new DependencyPropertyChangedEventHandler(this.OnIsEnabledChanged);
      ((FrameworkElement) this).Loaded += new RoutedEventHandler(this.Init);
    }

    private void Init(object sender, RoutedEventArgs e)
    {
      ((UIElement) this.innerImage).ManipulationStarted += this.innerControl_ManipulationStarted;
      ((UIElement) this.innerImage).ManipulationCompleted += this.innerControl_ManipulationCompleted;
      ((UIElement) this.innerText).ManipulationStarted += this.innerControl_ManipulationStarted;
      ((UIElement) this.innerText).ManipulationCompleted += this.innerControl_ManipulationCompleted;
      BitmapImage backGroundImage = this.BackGroundImage as BitmapImage;
      if (double.IsNaN(((FrameworkElement) this).Height) && ((BitmapSource) backGroundImage).PixelHeight > 0)
      {
        double pixelHeight = (double) ((BitmapSource) backGroundImage).PixelHeight;
        Thickness padding = this.Padding;
        double num = this.Padding.Top + this.Padding.Bottom;
        ((FrameworkElement) this).Height = pixelHeight + num;
      }
      if (double.IsNaN(((FrameworkElement) this).Width) && ((BitmapSource) backGroundImage).PixelWidth > 0)
      {
        double pixelWidth = (double) ((BitmapSource) backGroundImage).PixelWidth;
        Thickness padding = this.Padding;
        double num = this.Padding.Left + this.Padding.Right;
        ((FrameworkElement) this).Width = pixelWidth + num;
      }
      if (this.BackGroundImageHit == null)
        this.BackGroundImageHit = this.BackGroundImage;
      if (this.BackGroundImageDisabled == null)
        this.BackGroundImageDisabled = this.BackGroundImage;
      if (((Control) this).IsEnabled)
        return;
      this.innerImage.Source = this.BackGroundImageDisabled;
    }

    bool IAppearanceChangeMonitable.GetAndResetIsChangedFlag()
    {
      bool appearanceChanged = this._isAppearanceChanged;
      this._isAppearanceChanged = false;
      return appearanceChanged;
    }

    private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      this.innerImage.Source = !((Control) this).IsEnabled ? this.BackGroundImageDisabled : (this.IsChecked ? this.BackGroundImageHit : this.BackGroundImage);
      this._isAppearanceChanged = true;
    }

    private void innerControl_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
      if (this.IsStateLocked)
        return;
      if (this.IsPushButton)
      {
        this.IsChecked = !this.IsChecked;
        this.innerImage.Source = this.IsChecked ? this.BackGroundImageHit : this.BackGroundImage;
      }
      else
        this.innerImage.Source = this.BackGroundImageHit;
      this._isAppearanceChanged = true;
      if (this.Click == null)
        return;
      this.Click((object) this, new RoutedEventArgs());
    }

    private void innerControl_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
      if (this.IsStateLocked)
        return;
      if (!this.IsPushButton)
        this.innerImage.Source = this.BackGroundImage;
      this._isAppearanceChanged = true;
    }

    // private Size GetPngImageSize(Uri pngPath)
    // {
    //   Size empty = Size.Empty;
    //   StreamResourceInfo resourceStream = Application.GetResourceStream(pngPath);
    //   resourceStream.Stream.Position = 0L;
    //   byte[] buffer1 = new byte[16];
    //   byte[] buffer2 = new byte[8];
    //   resourceStream.Stream.Read(buffer2, 0, buffer2.Length);
    //   if (buffer2[0] == (byte) 137 && buffer2[1] == (byte) 80 && buffer2[2] == (byte) 78 && buffer2[3] == (byte) 71 && buffer2[4] == (byte) 13 && buffer2[5] == (byte) 10 && buffer2[6] == (byte) 26 && buffer2[7] == (byte) 10)
    //   {
    //     resourceStream.Stream.Read(buffer1, 0, buffer1.Length);
    //     Array.Reverse((Array) buffer1, 8, 4);
    //     Array.Reverse((Array) buffer1, 12, 4);
    //     empty.Width = (double) BitConverter.ToInt32(buffer1, 8);
    //     empty.Height = (double) BitConverter.ToInt32(buffer1, 12);
    //   }
    //   resourceStream.Stream.Close();
    //   return empty;
    // }

    // [DebuggerNonUserCode]
    // public void InitializeComponent()
    // {
    //   if (this._contentLoaded)
    //     return;
    //   this._contentLoaded = true;
    //   Application.LoadComponent((object) this, new Uri("/Tango.Toolbox;component/ImageButton.xaml", UriKind.Relative));
    //   this.LayoutRoot = (Grid) ((FrameworkElement) this).FindName("LayoutRoot");
    //   this.innerImage = (Image) ((FrameworkElement) this).FindName("innerImage");
    //   this.innerText = (TextBlock) ((FrameworkElement) this).FindName("innerText");
    // }
  }
}