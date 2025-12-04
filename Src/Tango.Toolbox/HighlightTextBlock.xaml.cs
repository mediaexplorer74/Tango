using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Tango.Toolbox
{
  public partial class HighlightTextBlock : UserControl
  {
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof (Text), typeof (string), typeof (HighlightTextBlock), new PropertyMetadata((object) string.Empty, new PropertyChangedCallback(HighlightTextBlock.OnTextPropertyChanged)));
    public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof (string), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register("LastName", typeof (string), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty TextMarginProperty = DependencyProperty.Register(nameof (TextMargin), typeof (Windows.UI.Xaml.Thickness), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty TextVerticalAlignmentProperty = DependencyProperty.Register(nameof (TextVerticalAlignment), typeof (Windows.UI.Xaml.VerticalAlignment), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(nameof (FontSize), typeof (double), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(nameof (Width), typeof (double), typeof (HighlightTextBlock), (PropertyMetadata) null);
    public static readonly DependencyProperty KeywordProperty = DependencyProperty.Register(nameof (Keyword), typeof (string), typeof (HighlightTextBlock), new PropertyMetadata((object) string.Empty, new PropertyChangedCallback(HighlightTextBlock.OnKeywordPropertyChanged)));
    public static readonly DependencyProperty HightlightBrushProperty = DependencyProperty.Register(nameof (HightlightBrush), typeof (Windows.UI.Xaml.Media.Brush), typeof (HighlightTextBlock), (PropertyMetadata) null);
    private string _originalText = string.Empty;
    // internal Grid LayoutRoot;
    // internal TextBlock innerText;
    // internal Run textBeforeMatched;
    // internal Run textMatched;
    // internal Run textAfterMatched;
    // private bool _contentLoaded;

    public bool IsWordPrefixMatchOnly { get; set; }

    private void ResetText()
    {
      this.textBeforeMatched.Text = this._originalText;
      this.textMatched.Text = string.Empty;
      this.textAfterMatched.Text = string.Empty;
    }

    public string Text
    {
      get => (string) ((DependencyObject) this).GetValue(HighlightTextBlock.TextProperty);
      set
      {
        this._originalText = value;
        ((DependencyObject) this).SetValue(HighlightTextBlock.TextProperty, (object) value);
        this.ResetText();
      }
    }

    public Windows.UI.Xaml.Thickness TextMargin
    {
      get => (Windows.UI.Xaml.Thickness) ((DependencyObject) this).GetValue(HighlightTextBlock.TextMarginProperty);
      set
      {
        ((DependencyObject) this).SetValue(HighlightTextBlock.TextMarginProperty, (object) value);
        ((FrameworkElement) this.innerText).Margin = value;
      }
    }

    public Windows.UI.Xaml.VerticalAlignment TextVerticalAlignment
    {
      get
      {
        return (Windows.UI.Xaml.VerticalAlignment) ((DependencyObject) this).GetValue(HighlightTextBlock.TextVerticalAlignmentProperty);
      }
      set
      {
        ((DependencyObject) this).SetValue(HighlightTextBlock.TextVerticalAlignmentProperty, (object) value);
        ((FrameworkElement) this.innerText).VerticalAlignment = value;
      }
    }

    public Windows.UI.Xaml.Media.FontFamily FontFamily
    {
      get => ((Control) this).FontFamily;
      set
      {
        ((Control) this).FontFamily = value;
        this.innerText.FontFamily = value;
      }
    }

    public double FontSize
    {
      get => (double) ((DependencyObject) this).GetValue(HighlightTextBlock.FontSizeProperty);
      set
      {
        ((DependencyObject) this).SetValue(HighlightTextBlock.FontSizeProperty, (object) value);
        this.innerText.FontSize = value;
      }
    }

    public double Width
    {
      get => (double) ((DependencyObject) this).GetValue(HighlightTextBlock.WidthProperty);
      set
      {
        ((DependencyObject) this).SetValue(HighlightTextBlock.WidthProperty, (object) value);
        ((FrameworkElement) this.innerText).Width = value;
      }
    }

    public string Keyword
    {
      get => (string) ((DependencyObject) this).GetValue(HighlightTextBlock.KeywordProperty);
      set => ((DependencyObject) this).SetValue(HighlightTextBlock.KeywordProperty, (object) value);
    }

    public Windows.UI.Xaml.Media.Brush HightlightBrush
    {
      get => (Windows.UI.Xaml.Media.Brush) ((DependencyObject) this).GetValue(HighlightTextBlock.HightlightBrushProperty);
      set
      {
        ((DependencyObject) this).SetValue(HighlightTextBlock.HightlightBrushProperty, (object) value);
        ((TextElement) this.textMatched).Foreground = value;
      }
    }

    private static void OnTextPropertyChanged(
      DependencyObject d,
      Windows.UI.Xaml.DependencyPropertyChangedEventArgs e)
    {
      if (!(d is HighlightTextBlock highlightTextBlock))
        return;
      highlightTextBlock._originalText = highlightTextBlock.Text;
      if (string.IsNullOrEmpty(highlightTextBlock.Keyword))
        highlightTextBlock.ResetText();
      else
        highlightTextBlock.HighlightKeyword();
    }

    private static void OnKeywordPropertyChanged(
      DependencyObject d,
      Windows.UI.Xaml.DependencyPropertyChangedEventArgs e)
    {
      if (!(d is HighlightTextBlock highlightTextBlock))
        return;
      highlightTextBlock.HighlightKeyword();
    }

    private static void OnHightlightBrushPropertyChanged(
      DependencyObject d,
      Windows.UI.Xaml.DependencyPropertyChangedEventArgs e)
    {
      if (!(d is HighlightTextBlock highlightTextBlock))
        return;
      ((TextElement) highlightTextBlock.textMatched).Foreground = highlightTextBlock.HightlightBrush;
    }

    public HighlightTextBlock() => this.InitializeComponent();

    public static bool CanHitKeyword(string keywordLower, string text, bool IsWordMode)
    {
      return HighlightTextBlock.CanHitKeywordImpl(keywordLower, text, IsWordMode) >= 0;
    }

    private static int CanHitKeywordImpl(string keywordLower, string text, bool IsWordMode)
    {
      if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(keywordLower))
        return -1;
      int length = keywordLower.Length;
      if (length > text.Length)
        return -1;
      string lowerInvariant = text.ToLowerInvariant();
      if (!IsWordMode)
        return lowerInvariant.IndexOf(keywordLower);
      if (lowerInvariant.Substring(0, length).Equals(keywordLower))
        return 0;
      int num = lowerInvariant.IndexOf(" " + keywordLower);
      return num < 0 ? num : num + 1;
    }

    private void HighlightKeyword()
    {
      if (string.IsNullOrEmpty(this.Keyword))
      {
        this.ResetText();
      }
      else
      {
        string lowerInvariant = this.Keyword.ToLowerInvariant();
        int num = HighlightTextBlock.CanHitKeywordImpl(lowerInvariant, this.Text, this.IsWordPrefixMatchOnly);
        if (num < 0)
          return;
        int length = lowerInvariant.Length;
        this.textBeforeMatched.Text = this.Text.Substring(0, num);
        this.textMatched.Text = this.Text.Substring(num, length);
        this.textAfterMatched.Text = this.Text.Substring(num + length);
      }
    }

    // [DebuggerNonUserCode]
    // public void InitializeComponent()
    // {
    //   if (this._contentLoaded)
    //     return;
    //   this._contentLoaded = true;
    //   Application.LoadComponent((object) this, new Uri("/Tango.Toolbox;component/HighlightTextBlock.xaml", UriKind.Relative));
    //   this.LayoutRoot = (Grid) ((FrameworkElement) this).FindName("LayoutRoot");
    //   this.innerText = (TextBlock) ((FrameworkElement) this).FindName("innerText");
    //   this.textBeforeMatched = (Run) ((FrameworkElement) this).FindName("textBeforeMatched");
    //   this.textMatched = (Run) ((FrameworkElement) this).FindName("textMatched");
    //   this.textAfterMatched = (Run) ((FrameworkElement) this).FindName("textAfterMatched");
    // }
  }
}