// Decompiled with JetBrains decompiler
// Type: ImageTools.ExtendedImage
// Assembly: ImageTools, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C426CD55-97ED-4956-BA88-5EA2C2D2DF87
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\ImageTools.dll

using ImageTools.Helpers;
using ImageTools.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace ImageTools
{
  [ContractVerification(false)]
  [DebuggerDisplay("Image: {PixelWidth}x{PixelHeight}")]
  public sealed class ExtendedImage : ImageBase
  {
    public const double DefaultDensityX = 75.0;
    public const double DefaultDensityY = 75.0;
    private ImageFrameCollection _frames = new ImageFrameCollection();
    private ImagePropertyCollection _properties = new ImagePropertyCollection();
    private Uri _uriSource;

    public static ExtendedImage Apply(ExtendedImage source, params IImageFilter[] filters)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(filters != null, "Filters cannot be null.");
      return ExtendedImage.PerformAction(source, true, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) =>
      {
        foreach (IImageFilter filter in filters)
          filter.Apply(targetImage, sourceImage, targetImage.Bounds);
      }));
    }

    public static ExtendedImage Apply(
      ExtendedImage source,
      Rectangle rectangle,
      params IImageFilter[] filters)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(filters != null, "Filters cannot be null.");
      return ExtendedImage.PerformAction(source, true, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) =>
      {
        foreach (IImageFilter filter in filters)
          filter.Apply(targetImage, sourceImage, rectangle);
      }));
    }

    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
    public static ExtendedImage Crop(ExtendedImage source, Rectangle bounds)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      return ExtendedImage.PerformAction(source, false, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) => ImageBase.Crop(sourceImage, targetImage, bounds)));
    }

    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
    public static ExtendedImage Transform(
      ExtendedImage source,
      RotationType rotationType,
      FlippingType flippingType)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      return ExtendedImage.PerformAction(source, false, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) => ImageBase.Transform(sourceImage, targetImage, rotationType, flippingType)));
    }

    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
    public static ExtendedImage Resize(
      ExtendedImage source,
      int width,
      int height,
      IImageResizer resizer)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(resizer != null, "Image Resizer cannot be null.");
      return ExtendedImage.PerformAction(source, false, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) => resizer.Resize(sourceImage, targetImage, width, height)));
    }

    [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
    public static ExtendedImage Resize(ExtendedImage source, int size, IImageResizer resizer)
    {
      Contract.Requires<ArgumentNullException>(source != null, "Source image cannot be null.");
      Contract.Requires<ArgumentException>(source.IsFilled, "Source image has not been loaded.");
      Contract.Requires<ArgumentNullException>(resizer != null, "Image Resizer cannot be null.");
      int width = 0;
      int height = 0;
      float num = (float) source.PixelWidth / (float) source.PixelHeight;
      if (source.PixelWidth > source.PixelHeight && (double) num > 0.0)
      {
        width = size;
        height = (int) ((double) width / (double) num);
      }
      else
      {
        height = size;
        width = (int) ((double) height * (double) num);
      }
      return ExtendedImage.PerformAction(source, false, (Action<ImageBase, ImageBase>) ((sourceImage, targetImage) => resizer.Resize(sourceImage, targetImage, width, height)));
    }

    [ContractVerification(false)]
    private static ExtendedImage PerformAction(
      ExtendedImage source,
      bool clone,
      Action<ImageBase, ImageBase> action)
    {
      ExtendedImage.VerifyHasLoaded(source);
      ExtendedImage extendedImage = clone ? new ExtendedImage(source) : new ExtendedImage();
      action((ImageBase) source, (ImageBase) extendedImage);
      foreach (ImageFrame frame in (Collection<ImageFrame>) source.Frames)
      {
        ImageFrame imageFrame = new ImageFrame();
        action((ImageBase) frame, (ImageBase) imageFrame);
        if (!clone)
          extendedImage.Frames.Add(imageFrame);
      }
      return extendedImage;
    }

    private static void VerifyHasLoaded(ExtendedImage image)
    {
      Contract.Requires(image != null);
      if (!image.IsFilled)
        throw new InvalidOperationException("Image has not been loaded");
      foreach (ImageFrame frame in (Collection<ImageFrame>) image.Frames)
      {
        if (frame != null && frame.IsFilled)
          throw new InvalidOperationException("Not all frames has been loaded yet.");
      }
    }

    public event EventHandler LoadingCompleted;

    private void OnLoadingCompleted(EventArgs e)
    {
      EventHandler loadingCompleted = this.LoadingCompleted;
      if (loadingCompleted != null)
        loadingCompleted(this, e);
    }

    // UWP-compatible event handlers
    public event EventHandler<DownloadCompletedEventArgs> DownloadCompleted;

    private void OnDownloadCompleted(DownloadCompletedEventArgs e)
    {
      EventHandler<DownloadCompletedEventArgs> downloadCompleted = this.DownloadCompleted;
      if (downloadCompleted != null)
        downloadCompleted(this, e);
    }

    public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgress;

    private void OnDownloadProgress(DownloadProgressChangedEventArgs e)
    {
      EventHandler<DownloadProgressChangedEventArgs> downloadProgress = this.DownloadProgress;
      if (downloadProgress != null)
        downloadProgress(this, e);
    }

    public event EventHandler<UnhandledExceptionEventArgs> LoadingFailed;

    private void OnLoadingFailed(UnhandledExceptionEventArgs e)
    {
      EventHandler<UnhandledExceptionEventArgs> loadingFailed = this.LoadingFailed;
      if (loadingFailed == null)
        return;
      loadingFailed((object) this, e);
    }

    public bool IsLoading { get; private set; }

    public double DensityX { get; set; }

    public double DensityY { get; set; }

    public double InchWidth
    {
      get
      {
        double num = this.DensityX;
        if (num <= 0.0)
          num = 75.0;
        return (double) this.PixelWidth / num;
      }
    }

    public double InchHeight
    {
      get
      {
        double num = this.DensityY;
        if (num <= 0.0)
          num = 75.0;
        return (double) this.PixelHeight / num;
      }
    }

    public bool IsAnimated => this._frames.Count > 0;

    public ImageFrameCollection Frames
    {
      get
      {
        Contract.Ensures(Contract.Result<ImageFrameCollection>() != null);
        return this._frames;
      }
    }

    public ImagePropertyCollection Properties
    {
      get
      {
        Contract.Ensures(Contract.Result<ImagePropertyCollection>() != null);
        return this._properties;
      }
    }

    public Uri UriSource
    {
      get => this._uriSource;
      set
      {
        this._uriSource = value;
        if (!(this.UriSource != (Uri) null))
          return;
        this.LoadAsync(this.UriSource);
      }
    }

    public ExtendedImage(int width, int height)
      : base(width, height)
    {
      Contract.Requires<ArgumentException>(width >= 0, "Width must be greater or equals than zero.");
      Contract.Requires<ArgumentException>(height >= 0, "Height must be greater or equals than zero.");
      Contract.Ensures(this.IsFilled);
      this.DensityX = 75.0;
      this.DensityY = 75.0;
    }

    public ExtendedImage(ExtendedImage other)
      : base((ImageBase) other)
    {
      Contract.Requires<ArgumentNullException>(other != null, "Other image cannot be null.");
      Contract.Requires<ArgumentException>(other.IsFilled, "Other image has not been loaded.");
      Contract.Ensures(this.IsFilled);
      foreach (ImageFrame frame in (Collection<ImageFrame>) other.Frames)
      {
        if (frame != null)
        {
          if (!frame.IsFilled)
            throw new ArgumentException("The image contains a frame that has not been loaded yet.");
          this.Frames.Add(new ImageFrame(frame));
        }
      }
      this.DensityX = 75.0;
      this.DensityY = 75.0;
    }

    public ExtendedImage()
    {
      this.DensityX = 75.0;
      this.DensityY = 75.0;
    }

    public void SetSource(Stream stream)
    {
      Contract.Requires<ArgumentNullException>(stream != null, "Stream cannot be null.");
      if (!(this._uriSource == (Uri) null))
        return;
      this.LoadAsync(stream);
    }

    private void Load(Stream stream)
    {
      Contract.Requires(stream != null);
      if (!stream.CanRead)
        throw new InvalidOperationException("Cannot read from the stream.");
      if (!stream.CanSeek)
        throw new InvalidOperationException("The stream does not support seeking.");
      IEnumerable<IImageDecoder> availableDecoders = (IEnumerable<IImageDecoder>) Decoders.GetAvailableDecoders();
      int count = availableDecoders.Max<IImageDecoder>((Func<IImageDecoder, int>) (x => x.HeaderSize));
      if (count > 0)
      {
        byte[] header = new byte[count];
        stream.Read(header, 0, count);
        stream.Position = 0L;
        IImageDecoder imageDecoder = availableDecoders.FirstOrDefault<IImageDecoder>((Func<IImageDecoder, bool>) (x => x.IsSupportedFileFormat(header)));
        if (imageDecoder != null)
        {
          imageDecoder.Decode(this, stream);
          this.IsLoading = false;
        }
      }
      if (this.IsLoading)
      {
        this.IsLoading = false;
        throw new UnsupportedImageFormatException();
      }
    }

    private void LoadAsync(Stream stream)
    {
      Contract.Requires(stream != null);
      Contract.Requires<InvalidOperationException>(stream.CanSeek);
      this.IsLoading = true;
      Task.Run(() =>
      {
        try
        {
          this.Load(stream);
          this.OnLoadingCompleted(EventArgs.Empty);
        }
        catch (Exception ex)
        {
          this.OnLoadingFailed(new UnhandledExceptionEventArgs(ex, false));
        }
      });
    }

    private void LoadAsync(Uri uri)
    {
      Contract.Requires(uri != (Uri) null);
      try
      {
        bool flag = false;
        if (!uri.IsAbsoluteUri)
        {
          Stream localResourceStream = Extensions.GetLocalResourceStream(uri);
          if (localResourceStream != null)
          {
            this.LoadAsync(localResourceStream);
            flag = true;
          }
        }
        if (flag)
          return;
        // UWP-compatible WebClient replacement
        this.IsLoading = true;
        
        // Use HttpClient for UWP compatibility
        var httpClient = new System.Net.Http.HttpClient();
        var downloadTask = httpClient.GetAsync(uri);
        downloadTask.ContinueWith(async (task) =>
        {
            try
            {
                if (task.IsFaulted)
                {
                    this.OnLoadingFailed(new UnhandledExceptionEventArgs(task.Exception, false));
                    return;
                }
                
                var response = await task;
                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    this.LoadAsync(stream);
                    this.OnDownloadCompleted(new DownloadCompletedEventArgs(stream, null, false));
                }
                else
                {
                    this.OnLoadingFailed(new UnhandledExceptionEventArgs(new Exception($"HTTP {response.StatusCode}"), false));
                }
            }
            catch (Exception ex)
            {
                this.OnLoadingFailed(new UnhandledExceptionEventArgs(ex, false));
            }
        });
      }
      catch (ArgumentException ex)
      {
        this.OnLoadingFailed(new UnhandledExceptionEventArgs(ex, false));
      }
    }

    private void webClient_OpenReadCompleted(object sender, DownloadCompletedEventArgs e)
    {
      Stream result = (Stream)e.Result;
      if (e.Error == null && result != null)
        this.LoadAsync(result);
      else
        this.OnLoadingFailed(new UnhandledExceptionEventArgs(e.Error, false));
      this.OnDownloadCompleted(e);
    }

    private void webClient_DownloadProgressChanged(
      object sender,
      DownloadProgressChangedEventArgs e)
    {
      this.OnDownloadProgress(e);
    }

    public ExtendedImage Clone()
    {
      Contract.Requires(this.IsFilled);
      Contract.Ensures(Contract.Result<ExtendedImage>() != null);
      return new ExtendedImage(this);
    }
  }
}
