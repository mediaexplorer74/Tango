// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.DrawableUIElement
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Tango.Toolbox
{
  // Minimal stubs to avoid XNA dependency in UWP build.
  public struct Vector2
  {
    public float X;
    public float Y;
    public static readonly Vector2 Zero = new Vector2();

    public Vector2(float x, float y)
    {
      X = x;
      Y = y;
    }
  }

  public struct Rectangle
  {
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public Rectangle(int x, int y, int width, int height)
    {
      X = x;
      Y = y;
      Width = width;
      Height = height;
    }
  }

  public struct Color
  {
    public static readonly Color White = new Color();
    public static readonly Color Black = new Color();
    public static readonly Color LightGray = new Color();
    public static readonly Color Blue = new Color();

    public static Color FromArgb(byte a, byte r, byte g, byte b) => new Color();
  }

  public enum SpriteEffects
  {
    None = 0
  }

  public class Texture2D
  {
  }

  public class SpriteBatch
  {
    public void Draw(Texture2D texture, Vector2 position, Color color) { }

    public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color,
      float rotation, Vector2 origin, SpriteEffects effects, float layerDepth) { }

    public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color) { }

    public void Begin() { }
    public void End() { }
  }

  public class UIElementRenderer
  {
    public UIElement Element { get; }
    public Texture2D Texture { get; private set; }

    public UIElementRenderer(UIElement element, int width, int height)
    {
      Element = element;
      Texture = new Texture2D();
    }

    public void Render() { }
  }

  public class SpriteFont
  {
  }

  public class DrawableUIElement
  {
    private UIElement _rootElement;
    private FrameworkElement _resizeableElement;
    private bool _isPositionInited;
    private Vector2 _position = Vector2.Zero;

    public bool IsVisible { get; set; }

    public SpriteBatch SpriteBatch { get; set; }

    private UIElementRenderer Renderer { get; set; }

    public Vector2 Position
    {
      get => this._position;
      set
      {
        this._position = value;
        this._isPositionInited = true;
      }
    }

    public DrawableUIElement() => this.IsVisible = true;

    public void BindUIElement(
      UIElement element,
      SpriteBatch spriteBatch,
      int textureWidth,
      int textureHeight)
    {
      this.SpriteBatch = spriteBatch;
      this._isPositionInited = false;
      this._position = Vector2.Zero;
      this.Renderer = new UIElementRenderer(element, textureWidth, textureHeight);
      if (element is FrameworkElement frameworkElement)
      {
        frameworkElement.Height = (double) textureHeight;
        frameworkElement.Width = (double) textureWidth;
      }
      this._rootElement = element;
      this.AppearanceMonitor = (List<IAppearanceChangeMonitable>) null;
    }

    public void BindUIElement(FrameworkElement element, SpriteBatch spriteBatch)
    {
      this.SpriteBatch = spriteBatch;
      this._isPositionInited = false;
      this._position = Vector2.Zero;
      this._resizeableElement = element;
      this._rootElement = (UIElement) element;
      this.AppearanceMonitor = (List<IAppearanceChangeMonitable>) null;
    }

    public void EnableRenderSkip(bool IsAutoDetect, bool IsEnable)
    {
      if (IsEnable)
      {
        this.AppearanceMonitor = new List<IAppearanceChangeMonitable>();
        if (!IsAutoDetect)
          return;
        this.FindAppearanceMonitors((DependencyObject) this._rootElement);
      }
      else
        this.AppearanceMonitor = (List<IAppearanceChangeMonitable>) null;
    }

    private int FindAppearanceMonitors(DependencyObject root)
    {
      if (root == null)
        return 0;
      int appearanceMonitors = 0;
      int childrenCount = VisualTreeHelper.GetChildrenCount(root);
      if (root is IAppearanceChangeMonitable appearanceChangeMonitable)
      {
        ++appearanceMonitors;
        this.AppearanceMonitor.Add(appearanceChangeMonitable);
      }
      for (int index = 0; index < childrenCount; ++index)
        appearanceMonitors += this.FindAppearanceMonitors(VisualTreeHelper.GetChild(root, index));
      return appearanceMonitors;
    }

    public List<IAppearanceChangeMonitable> AppearanceMonitor { get; private set; }

    public void DrawIfVisible()
    {
      if (!this.IsVisible || this.SpriteBatch == null)
        return;
      if (this.Renderer == null && this._resizeableElement != null)
      {
        double num1 = this._resizeableElement.Width;
        if (double.IsNaN(num1))
          num1 = this._resizeableElement.ActualWidth;
        double num2 = this._resizeableElement.Height;
        if (double.IsNaN(num2))
          num2 = this._resizeableElement.ActualHeight;
        if (!double.IsNaN(num1) && num1 > 0.0 && !double.IsNaN(num2) && num2 > 0.0)
          this.Renderer = new UIElementRenderer((UIElement) this._resizeableElement, (int) Math.Ceiling(num1), (int) Math.Ceiling(num2));
      }
      if (this.Renderer == null)
        return;
      if (!this._isPositionInited)
        this.Position = UIElementHelper.GetAbsoluteCoordinatesV2(this.Renderer.Element);
      if (this.Renderer.Texture == null || this.AppearanceMonitor == null)
      {
        this.Renderer.Render();
      }
      else
      {
        for (int index = 0; index < this.AppearanceMonitor.Count; ++index)
        {
          if (this.AppearanceMonitor[index].GetAndResetIsChangedFlag())
          {
            this.Renderer.Render();
            break;
          }
        }
      }
      this.SpriteBatch.Draw(this.Renderer.Texture, this.Position, Color.White);
    }

    public void Draw(
      Rectangle destinationRectangle,
      Rectangle? sourceRectangle,
      Color color,
      float rotation,
      Vector2 origin,
      SpriteEffects effects,
      float layerDepth)
    {
      if (this.Renderer == null || this.SpriteBatch == null)
        return;
      if (this.Renderer.Texture == null || this.AppearanceMonitor == null)
      {
        this.Renderer.Render();
      }
      else
      {
        for (int index = 0; index < this.AppearanceMonitor.Count; ++index)
        {
          if (this.AppearanceMonitor[index].GetAndResetIsChangedFlag())
          {
            this.Renderer.Render();
            break;
          }
        }
      }
      this.SpriteBatch.Draw(this.Renderer.Texture, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
    }
  }
}
