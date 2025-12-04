// Decompiled with JetBrains decompiler
// Type: Tango.Toolbox.UIElementHelper
// Assembly: Tango.Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66659FBC-C0D0-4E90-B77B-A803101F884B
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Toolbox.dll

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

#nullable disable
namespace Tango.Toolbox
{
  public static class UIElementHelper
  {
    public const int KEYBOARD_HEIGHT_PORTRAIT = 336;
    public const int KEYBOARD_HEIGHT_LANDSCAPE = 256;

    public static Vector2 GetRelativeCoordinatesV2(UIElement element)
    {
      Point relativeCoordinates = UIElementHelper.GetRelativeCoordinates(element);
      return new Vector2((float) relativeCoordinates.X, (float) relativeCoordinates.Y);
    }

    public static Point GetRelativeCoordinates(UIElement element)
    {
      Point relativeCoordinates = new Point(0.0, 0.0);
      if (!(VisualTreeHelper.GetParent((DependencyObject) element) is UIElement parent))
        return relativeCoordinates;
      GeneralTransform generalTransform = (GeneralTransform) null;
      try
      {
        generalTransform = element.TransformToVisual(parent);
      }
      catch (Exception ex)
      {
      }
      if (generalTransform == null)
        return relativeCoordinates;
      Point point = generalTransform.TransformPoint(relativeCoordinates);
      return point;
    }

    public static Vector2 GetAbsoluteCoordinatesV2(UIElement element)
    {
      Point absoluteCoordinates = UIElementHelper.GetAbsoluteCoordinates(element);
      return new Vector2((float) absoluteCoordinates.X, (float) absoluteCoordinates.Y);
    }

    public static Point GetAbsoluteCoordinates(UIElement element)
    {
      Point result = UIElementHelper.GetRelativeCoordinates(element);
      UIElement current = element;
      while (current != null)
      {
        var parent = VisualTreeHelper.GetParent(current as DependencyObject) as UIElement;
        if (parent == null)
          break;
        Point parentOffset = UIElementHelper.GetRelativeCoordinates(parent);
        result.X += parentOffset.X;
        result.Y += parentOffset.Y;
        current = parent;
      }
      return result;
    }
  }
}
