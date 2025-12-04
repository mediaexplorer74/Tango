// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.AudioVideoCallPage
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using Windows.Phone.Media.Capture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sgiggle.xmpp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Tango.Drivers;
using Tango.Messages;
using Tango.Toolbox;
using WinPhoneTango.Lang;

#nullable disable
namespace WinPhoneTango
{
  public partial class AudioVideoCallPage : TangoEventPageBase
  {
    private const int SCREEN_WIDTH = 480;
    private const int SCREEN_HEIGHT = 800;
    private const int BIG_IMAGE_WIDTH = 480;
    private const int BIG_IMAGE_HEIGHT = 720;
    private const int SWITCH_CAMERA_BUTTON_MARGIN = 30;
    private const int VIDEO_PANEL_HEIGHT = 80;
    private const int BIG_IMAGE_MARGIN = 0;
    private const int SMALL_IMAGE_BORDER = 2;
    private const int SMALL_IMAGE_MARGIN = 12;
    private const int SMALL_IMAGE_WIDTH = 120;
    private const int SMALL_IMAGE_HEIGHT_MAX = 200;
    private const int LOCAL_PREVIEW_TEXTURE_WIDTH = 216;
    private static readonly string VIDEO_ALERT_SHOWN = "video_alert_shown";
    private bool _isLocalCameraOn;
    private bool _isTwoWay;
    private bool _isDualCam;
    private bool _isCallFinished;
    private SpriteEffects _currentEffect;
    private DrawableUIElement _cameraLocalViewFinder = new DrawableUIElement();
    private DrawableUIElement _cameraSmallLocalBorder = new DrawableUIElement();
    private DrawableUIElement _audioPanel = new DrawableUIElement();
    private DrawableUIElement _videoPanel = new DrawableUIElement();
    private DrawableUIElement _switchCameraButton = new DrawableUIElement();
    private DrawableUIElement _videoAlertBar = new DrawableUIElement();
    private DrawableUIElement _cameraAlertBox = new DrawableUIElement();
    private DrawableUIElement _lowNetworkAlertBox = new DrawableUIElement();
    private DrawableUIElement _onscreenLog = new DrawableUIElement();
    private Texture2D _remoteVideoFrameTexture;
    private Texture2D _blackBackground;
    private AppearanceChangeTimingMonitor _localViewerTimeMonitor = new AppearanceChangeTimingMonitor();
    private Stopwatch _pastTimeStopWatch;
    public int _remoteVideoFrameWidth = 10;
    public int _remoteVideoFrameHeight = 10;
    private GameTimer _gameTimer;
    private SpriteBatch _spriteBatch;
    private int SMALL_IMAGE_HEIGHT = 180;
    private int _croppedLocalVideoWidth = 216;
    private int _croppedLocalVideoHeight = 288;
    private Rectangle _blackBackgroundRect = new Rectangle(0, 0, 480, 800);
    private float _drawRemoteVideoRotation = 1.57079637f;
    private Rectangle _drawRemoteVideoFrameRect = new Rectangle(480, 0, 720, 480);
    private Rectangle _cameraViewFinderBigRect = new Rectangle(0, 0, 480, 720);
    private Rectangle _cameraViewFinderSmallRect;
    private Rectangle _cameraViewFinderSourceRect;
    private static readonly TimeSpan UPDATE_INTERVAL_FOR_AUDIO = TimeSpan.FromTicks(833333L);
    private static readonly TimeSpan UPDATE_INTERVAL_FOR_REMOTE_VIDEO = TimeSpan.FromTicks(333333L);
    private static readonly TimeSpan UPDATE_INTERVAL_FOR_LOCAL_VIDEO = TimeSpan.FromTicks(333333L);
    private static readonly TimeSpan UPDATE_INTERVAL_FOR_2WAY_VIDEO = AudioVideoCallPage.UPDATE_INTERVAL_FOR_REMOTE_VIDEO;
    private static readonly TimeSpan UPDATE_INTERVAL_FOR_LOCAL_VIEW_FINDER = TimeSpan.FromTicks(625000L);
    private Stopwatch _drawCalcWatch = new Stopwatch();
   

    private void SetPreferredBackBufferFormat()
    {
      SharedGraphicsDeviceManager.Current.PreferredBackBufferFormat = SurfaceFormat.Color;
    }

    private Texture2D NewRemoteVideoFrameTexture(int width, int height)
    {
      return new Texture2D(SharedGraphicsDeviceManager.Current.GraphicsDevice, width, height, false, SurfaceFormat.Color);
    }

    public AudioVideoCallPage()
    {
      this.IsGoBackable = false;
      this.InitializeComponent();
      this.SetPreferredBackBufferFormat();
      GraphicsDeviceExtensions.SetSharingMode(SharedGraphicsDeviceManager.Current.GraphicsDevice, true);
      this._spriteBatch = new SpriteBatch(SharedGraphicsDeviceManager.Current.GraphicsDevice);
      this._remoteVideoFrameTexture = this.NewRemoteVideoFrameTexture(this._remoteVideoFrameWidth, this._remoteVideoFrameHeight);
      this._blackBackground = new Texture2D(SharedGraphicsDeviceManager.Current.GraphicsDevice, 1, 1, false, SurfaceFormat.Bgr565);
      this.bigButtonMute.Text = LangResource.mute_button;
      this.bigButtonVideo.Text = LangResource.video_button;
      this.bigButtonSpeaker.Text = LangResource.speaker_button;
      ((Control) this.bigButtonVideo).IsEnabled = false;
      ((Control) this.bigButtonSpeaker).IsEnabled = false;
      this.ResetPreviewElements();
      this._audioPanel.BindUIElement((UIElement) this.AudioInProgress, this._spriteBatch, 480, 800);
      this._audioPanel.EnableRenderSkip(true, true);
      this._videoPanel.BindUIElement((UIElement) this.VideoPanel, this._spriteBatch, 480, 80);
      this._videoPanel.EnableRenderSkip(true, true);
      this._switchCameraButton.BindUIElement((FrameworkElement) this.buttonSwitchCamera, this._spriteBatch);
      this._switchCameraButton.EnableRenderSkip(true, true);
      this._cameraAlertBox.BindUIElement((FrameworkElement) this.alertBorder, this._spriteBatch);
      this._cameraAlertBox.EnableRenderSkip(true, true);
      this._cameraAlertBox.IsVisible = false;
      this._videoAlertBar.BindUIElement((FrameworkElement) this.alertBar, this._spriteBatch);
      this._cameraAlertBox.EnableRenderSkip(true, true);
      this._videoAlertBar.IsVisible = !IsolatedStorageSettings.ApplicationSettings.Contains(AudioVideoCallPage.VIDEO_ALERT_SHOWN);
      this._lowNetworkAlertBox.BindUIElement((FrameworkElement) this.networkAlertBorder, this._spriteBatch);
      this._lowNetworkAlertBox.EnableRenderSkip(true, true);
      this._lowNetworkAlertBox.IsVisible = false;
      this._onscreenLog.BindUIElement((FrameworkElement) this.screenLogBorder, this._spriteBatch);
      this._onscreenLog.EnableRenderSkip(true, true);
      this._onscreenLog.IsVisible = false;
      this._pastTimeStopWatch = new Stopwatch();
      this._gameTimer = new GameTimer();
      this._gameTimer.UpdateInterval = AudioVideoCallPage.UPDATE_INTERVAL_FOR_AUDIO;
      this._gameTimer.Update += new EventHandler<GameTimerEventArgs>(this.OnUpdate);
      this._gameTimer.Draw += new EventHandler<GameTimerEventArgs>(this.OnDraw);
      this._gameTimer.FrameAction += new EventHandler<EventArgs>(this.OnFrame);
    }

    private void ResetPreviewElements()
    {
      int num1 = Math.Max(DriversManager.Instance.CapturerDriver.VideoCapturerResolutionHeight, DriversManager.Instance.CapturerDriver.VideoCapturerResolutionWidth);
      int num2 = Math.Min(DriversManager.Instance.CapturerDriver.VideoCapturerResolutionHeight, DriversManager.Instance.CapturerDriver.VideoCapturerResolutionWidth);
      this._croppedLocalVideoHeight = Math.Max(DriversManager.Instance.CapturerDriver.VideoCropHeight, DriversManager.Instance.CapturerDriver.VideoCropWidth);
      this._croppedLocalVideoWidth = Math.Min(DriversManager.Instance.CapturerDriver.VideoCropHeight, DriversManager.Instance.CapturerDriver.VideoCropWidth);
      if (this._croppedLocalVideoHeight <= 0 || this._croppedLocalVideoHeight > num1)
        this._croppedLocalVideoHeight = num1;
      if (this._croppedLocalVideoWidth <= 0 || this._croppedLocalVideoWidth > num2)
        this._croppedLocalVideoWidth = num2;
      int num3 = Math.Max(1, Math.Min(num1 / this._croppedLocalVideoHeight, num2 / this._croppedLocalVideoWidth));
      this._croppedLocalVideoHeight *= num3;
      this._croppedLocalVideoWidth *= num3;
      Tango.Toolbox.Logger.Trace(string.Format("Try to fit the cropped size (width = {0}, height = {1})", (object) this._croppedLocalVideoWidth, (object) this._croppedLocalVideoHeight));
      double num4 = (double) num1 / (double) num2;
      double num5 = (double) this._croppedLocalVideoHeight / (double) this._croppedLocalVideoWidth;
      double num6 = (double) this._croppedLocalVideoWidth / (double) num2;
      double num7 = (double) this._croppedLocalVideoHeight / (double) num1;
      this.SMALL_IMAGE_HEIGHT = Math.Min(200, (int) (num5 * 120.0));
      int y1 = 720 - this.SMALL_IMAGE_HEIGHT - 12;
      this._cameraViewFinderSmallRect = new Rectangle(12, y1 + 2, 120, this.SMALL_IMAGE_HEIGHT);
      Rectangle rectangle = new Rectangle(10, y1, 124, this.SMALL_IMAGE_HEIGHT + 4);
      ((FrameworkElement) this.PreviewBorder).Margin = new Thickness((double) rectangle.Left, (double) rectangle.Top, 0.0, 0.0);
      this._cameraSmallLocalBorder.BindUIElement((UIElement) this.PreviewBorder, this._spriteBatch, rectangle.Width, rectangle.Height);
      this._cameraSmallLocalBorder.EnableRenderSkip(true, true);
      this._cameraSmallLocalBorder.Position = new Vector2((float) rectangle.Left, (float) rectangle.Top);
      int width;
      int height1;
      int textureWidth;
      int textureHeight;
      if (this._isTwoWay)
      {
        width = 120;
        height1 = this.SMALL_IMAGE_HEIGHT;
        textureWidth = (int) ((double) width / num6);
        textureHeight = (int) ((double) height1 / num7);
      }
      else
      {
        int num8 = (int) (216.0 * num4);
        textureWidth = 216;
        textureHeight = num8;
        width = (int) ((double) textureWidth * num6);
        height1 = (int) ((double) textureHeight * num7);
      }
      this._cameraLocalViewFinder.BindUIElement((UIElement) this.PreviewRectangle, this._spriteBatch, textureWidth, textureHeight);
      this._cameraLocalViewFinder.EnableRenderSkip(false, true);
      this._localViewerTimeMonitor.SetRefreshInterval(AudioVideoCallPage.UPDATE_INTERVAL_FOR_LOCAL_VIEW_FINDER);
      this._cameraLocalViewFinder.AppearanceMonitor.Add((IAppearanceChangeMonitable) this._localViewerTimeMonitor);
      this._cameraViewFinderSourceRect = new Rectangle((textureWidth - width) / 2, (textureHeight - height1) / 2, width, height1);
      int height2 = Math.Min(800, (int) (480.0 * num5));
      int y2 = (800 - height2 - 80) / 2 < 0 ? 0 : (800 - height2 - 80) / 2;
      this._cameraViewFinderBigRect = new Rectangle(0, y2, 480, height2);
      if (this._isTwoWay || !this._isLocalCameraOn)
        return;
      this._switchCameraButton.Position = new Vector2((float) (450 - (int) ((FrameworkElement) this.buttonSwitchCamera).Width), (float) (y2 + 30));
      ((FrameworkElement) this.buttonSwitchCamera).Margin = new Thickness(0.0, (double) this._switchCameraButton.Position.Y, 30.0, 0.0);
    }

    protected override void OnInitialized()
    {
      DriversManager.Instance.CapturerDriver.Init(new CapturerDriver.SetViewFinderSourceDelegate(this.DoSetViewFinderSource), out this._isDualCam);
      DriversManager.Instance.RendererDriver.Init(new RendererDriver.RenderVideoFrameHandlerDelegate(this.DoRenderVideoFrame));
      DriversManager.Instance.RecorderDriver.Init();
      this._switchCameraButton.IsVisible = this._isDualCam;
      CameraButtons.ShutterKeyPressed += new EventHandler(this.OnShutterPressed);
      this.UpdateDisplayName();
      this.UpdateAudioMode();
    }

    private void UpdateDisplayName()
    {
      if (AppManager.Instance.DataManager.CallingData != null && AppManager.Instance.DataManager.CallingData.Displayname != null && AppManager.Instance.DataManager.CallingData.Displayname.Length > 0)
      {
        this.callUserName.Text = AppManager.Instance.DataManager.CallingData.Displayname;
      }
      else
      {
        if (AppManager.Instance.DataManager.RemoteCallingUserDisplayName == null || AppManager.Instance.DataManager.RemoteCallingUserDisplayName.Length <= 0)
          return;
        this.callUserName.Text = AppManager.Instance.DataManager.RemoteCallingUserDisplayName;
      }
    }

    private void UpdateAudioMode()
    {
      if (AppManager.Instance.DataManager.AudioMode == null)
        return;
      this.bigButtonMute.IsChecked = AppManager.Instance.DataManager.AudioMode.Muted;
      this.smallButtonMute.IsChecked = AppManager.Instance.DataManager.AudioMode.Muted;
      this.bigButtonSpeaker.IsChecked = AppManager.Instance.DataManager.AudioMode.Speakeron;
    }

    public override void HandleTangoEvent(int messageId)
    {
      switch (messageId)
      {
        case 35023:
          if (!this._pastTimeStopWatch.IsRunning)
          {
            Tango.Toolbox.Logger.Trace("get event AUDIO_IN_PROGRESS_TYPE, start the timer.");
            this._pastTimeStopWatch.Start();
          }
          else
            Tango.Toolbox.Logger.Trace("get event AUDIO_IN_PROGRESS_TYPE, close video and show audio panel.");
          ((Control) this.bigButtonVideo).IsEnabled = true;
          ((Control) this.bigButtonSpeaker).IsEnabled = true;
          this._audioPanel.IsVisible = true;
          this._lowNetworkAlertBox.IsVisible = false;
          this._isLocalCameraOn = false;
          this._isTwoWay = false;
          this._gameTimer.UpdateInterval = AudioVideoCallPage.UPDATE_INTERVAL_FOR_AUDIO;
          ((UIElement) this.AudioInProgress).Visibility = (Visibility) 0;
          ((UIElement) this.VideoAudioInProgress).Visibility = (Visibility) 1;
          this.UpdateDisplayName();
          this.smallButtonVideo.IsStateLocked = false;
          this.bigButtonVideo.IsStateLocked = false;
          break;
        case 35025:
          this._audioPanel.IsVisible = false;
          this._isTwoWay = false;
          this._isLocalCameraOn = AppManager.Instance.DataManager.CallingData != null && AppManager.Instance.DataManager.CallingData.Direction == MediaSessionPayload.Types.Direction.SEND;
          this._gameTimer.UpdateInterval = !this._isLocalCameraOn ? AudioVideoCallPage.UPDATE_INTERVAL_FOR_REMOTE_VIDEO : AudioVideoCallPage.UPDATE_INTERVAL_FOR_LOCAL_VIDEO;
          this.ResetPreviewElements();
          ((UIElement) this.AudioInProgress).Visibility = (Visibility) 1;
          ((UIElement) this.VideoAudioInProgress).Visibility = (Visibility) 0;
          this.UpdateDisplayName();
          this.smallButtonVideo.IsStateLocked = false;
          this.bigButtonVideo.IsStateLocked = false;
          this.buttonSwitchCamera.IsStateLocked = false;
          break;
        case 35069:
          this._audioPanel.IsVisible = false;
          this._isTwoWay = true;
          this._gameTimer.UpdateInterval = AudioVideoCallPage.UPDATE_INTERVAL_FOR_2WAY_VIDEO;
          this.ResetPreviewElements();
          this.UpdateDisplayName();
          this.smallButtonVideo.IsStateLocked = false;
          this.bigButtonVideo.IsStateLocked = false;
          this.buttonSwitchCamera.IsStateLocked = false;
          break;
        case 35077:
          this._lowNetworkAlertBox.IsVisible = true;
          break;
        case 35079:
          this._lowNetworkAlertBox.IsVisible = false;
          break;
        case 35080:
          this._cameraAlertBox.IsVisible = AppManager.Instance.DataManager.InCallAlert.Hide != 1;
          break;
        case 35083:
          this.UpdateAudioMode();
          break;
        case 35089:
          this.buttonSwitchCamera.IsStateLocked = false;
          break;
      }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      this.SetPreferredBackBufferFormat();
      GraphicsDeviceExtensions.SetSharingMode(SharedGraphicsDeviceManager.Current.GraphicsDevice, true);
      this.Assert((object) this._gameTimer);
      this._gameTimer.Start();
      base.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      this.Assert((object) this._gameTimer);
      this._gameTimer.Stop();
      GraphicsDeviceExtensions.SetSharingMode(SharedGraphicsDeviceManager.Current.GraphicsDevice, false);
      base.OnNavigatedFrom(e);
    }

    private void OnShutterPressed(object sender, EventArgs e)
    {
    }

    private void DoRenderVideoFrame(byte[] buffer, int width, int height)
    {
      if (this._remoteVideoFrameTexture == null || this._remoteVideoFrameWidth != width || this._remoteVideoFrameHeight != height)
      {
        this._remoteVideoFrameWidth = width;
        this._remoteVideoFrameHeight = height;
        this._remoteVideoFrameTexture = this.NewRemoteVideoFrameTexture(this._remoteVideoFrameWidth, this._remoteVideoFrameHeight);
        int num1 = 720;
        double num2 = (double) num1 / 480.0;
        double num3 = (double) width / (double) height;
        double num4 = 0.01;
        if (Math.Abs(num2 - num3) <= num4)
          this._drawRemoteVideoFrameRect = new Rectangle(480, 0, 720, 480);
        else if (num2 - num3 > num4)
        {
          int width1 = (int) (num3 * 480.0);
          this._drawRemoteVideoFrameRect = new Rectangle(480, (num1 - width1) / 2, width1, 480);
        }
        else
        {
          int width2 = (int) (num3 * 480.0);
          if (width2 > 800)
            width2 = 800;
          this._drawRemoteVideoFrameRect = new Rectangle(480, 0, width2, 480);
        }
        this._switchCameraButton.Position = new Vector2((float) (450 - (int) ((FrameworkElement) this.buttonSwitchCamera).Width), (float) (this._drawRemoteVideoFrameRect.Top + 30));
        ((FrameworkElement) this.buttonSwitchCamera).Margin = new Thickness(0.0, (double) this._switchCameraButton.Position.Y, 30.0, 0.0);
      }
      else
        SharedGraphicsDeviceManager.Current.GraphicsDevice.Textures[0] = (Texture) null;
      this._remoteVideoFrameTexture.SetData<byte>(buffer);
      SharedGraphicsDeviceManager.Current.GraphicsDevice.Textures[0] = (Texture) this._remoteVideoFrameTexture;
    }

    private int GetTickCount() => Environment.TickCount & int.MaxValue;

    private void OnFrame(object sender, EventArgs e)
    {
      VideoRenderBuffer videoRenderBuffer = (VideoRenderBuffer) null;
      lock ("VideoRenderBuffer")
      {
        if (DriversManager.Instance.RendererDriver.VideoRenderQueue != null)
        {
          if (DriversManager.Instance.RendererDriver.VideoRenderQueue.Count > 0)
            videoRenderBuffer = DriversManager.Instance.RendererDriver.VideoRenderQueue.Dequeue();
        }
      }
      if (videoRenderBuffer == null)
        return;
      this.DoRenderVideoFrame(videoRenderBuffer.Buffer, videoRenderBuffer.Width, videoRenderBuffer.Height);
      this.OnDrawImpl(false);
    }

    private void OnUpdate(object sender, GameTimerEventArgs e)
    {
    }

    private void OnDraw(object sender, GameTimerEventArgs e)
    {
      this._drawCalcWatch.Start();
      this.OnDrawImpl(true);
      this._drawCalcWatch.Stop();
      this._drawCalcWatch.Reset();
    }

    private void OnDrawImpl(bool IsPassive)
    {
      this._spriteBatch.Begin();
      this._spriteBatch.Draw(this._blackBackground, this._blackBackgroundRect, Color.White);
      if (this._audioPanel.IsVisible)
      {
        this.textPastTime.Text = !this._pastTimeStopWatch.IsRunning ? (this._isCallFinished ? LangResource.call_status_ended : LangResource.call_status_connecting) : this._pastTimeStopWatch.Elapsed.ToString("mm\\:ss");
        this._audioPanel.DrawIfVisible();
      }
      else
      {
        if (this._isTwoWay)
        {
          this._spriteBatch.Draw(this._remoteVideoFrameTexture, this._drawRemoteVideoFrameRect, new Rectangle?(), Color.White, this._drawRemoteVideoRotation, Vector2.Zero, SpriteEffects.None, 0.0f);
          this._cameraSmallLocalBorder.DrawIfVisible();
          this._cameraLocalViewFinder.Draw(this._cameraViewFinderSmallRect, new Rectangle?(this._cameraViewFinderSourceRect), Color.White, 0.0f, Vector2.Zero, this._currentEffect, 0.0f);
          this._switchCameraButton.DrawIfVisible();
        }
        else if (this._isLocalCameraOn)
        {
          this._cameraLocalViewFinder.Draw(this._cameraViewFinderBigRect, new Rectangle?(this._cameraViewFinderSourceRect), Color.White, 0.0f, Vector2.Zero, this._currentEffect, 0.0f);
          this._switchCameraButton.DrawIfVisible();
        }
        else
        {
          this._spriteBatch.Draw(this._remoteVideoFrameTexture, this._drawRemoteVideoFrameRect, new Rectangle?(), Color.White, this._drawRemoteVideoRotation, Vector2.Zero, SpriteEffects.None, 0.0f);
          this._videoAlertBar.DrawIfVisible();
        }
        this._videoPanel.DrawIfVisible();
        this._cameraAlertBox.DrawIfVisible();
        this._lowNetworkAlertBox.DrawIfVisible();
        if (AppManager.Instance.DataManager.IsEnableOnScreenLog)
        {
          int Length = 1024;
          byte[] numArray = new byte[Length];
          int DataLen;
          DriversManager.Instance.RendererDriver.Connector.GetScreenLog(numArray, Length, out DataLen);
          try
          {
            this.screenLogTextBlock.Text = Encoding.UTF8.GetString(numArray, 0, DataLen);
          }
          catch (Exception ex)
          {
            this.screenLogTextBlock.Text = string.Empty;
            Tango.Toolbox.Logger.Trace("cannot decode screen log.\n" + ex.Message);
          }
          this._onscreenLog.IsVisible = true;
        }
        else
          this._onscreenLog.IsVisible = false;
        this._onscreenLog.DrawIfVisible();
      }
      this._spriteBatch.End();
    }

    protected override void OnBackKeyPress(CancelEventArgs e)
    {
      e.Cancel = true;
      this.EndCall();
    }

    private void DoSetViewFinderSource(PhotoCamera camera, SpriteEffects effect)
    {
      CameraVideoBrushExtensions.SetSource(this.ViewFinder, (Camera) camera);
      ((Brush) this.ViewFinder).RelativeTransform = (Transform) new RotateTransform()
      {
        CenterX = 0.5,
        CenterY = 0.5,
        Angle = 90.0
      };
      this._currentEffect = effect;
    }

    private void buttonSwitchCamera_Click(object sender, RoutedEventArgs e)
    {
      Tango.Toolbox.Logger.Trace("call switch camera.");
      if (!this._isDualCam || AppManager.Instance.DataManager.CallingData == null)
        return;
      SwitchCameraPayload.Builder builder = SwitchCameraPayload.CreateBuilder();
      builder.SetPeer(AppManager.Instance.DataManager.CallingData.AccountId);
      TangoEventPageBase.SendMessage((ISendableMessage) new SwitchCameraMessage(TangoEventPageBase.GetNextSeqId(), builder));
      this.buttonSwitchCamera.IsStateLocked = true;
    }

    private void bothButtonHangup_Click(object sender, RoutedEventArgs e) => this.EndCall();

    private void EndCall()
    {
      if (this.WaitingForClickResult)
        return;
      this.WaitingForClickResult = true;
      this._pastTimeStopWatch.Stop();
      this._isCallFinished = true;
      if (AppManager.Instance.DataManager.CallingData != null)
        TangoEventPageBase.SendMessage((ISendableMessage) new TerminateCallMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
      this.smallButtonVideo.IsStateLocked = true;
      this.bigButtonVideo.IsStateLocked = true;
      this.buttonSwitchCamera.IsStateLocked = true;
      this.smallButtonMute.IsStateLocked = true;
      this.bigButtonSpeaker.IsStateLocked = true;
      this.bigButtonMute.IsStateLocked = true;
    }

    private void bigButtonMute_Click(object sender, RoutedEventArgs e)
    {
      this.OnMuteButtonClick(this.bigButtonMute.IsChecked);
    }

    private void bigButtonVideo_Click(object sender, RoutedEventArgs e)
    {
      if (!this._pastTimeStopWatch.IsRunning)
        return;
      this.OnVideoButtonClick(this.bigButtonVideo.IsChecked);
    }

    private void bigButtonSpeaker_Click(object sender, RoutedEventArgs e)
    {
      Tango.Toolbox.Logger.Trace("speaker pressed, checked = " + this.bigButtonSpeaker.IsChecked.ToString());
      if (AppManager.Instance.DataManager.AudioMode != null)
        AppManager.Instance.DataManager.AudioMode.SetSpeakeron(this.bigButtonSpeaker.IsChecked);
      AudioControlPayload.Builder builder = AudioControlPayload.CreateBuilder();
      builder.SetSpeakeron(this.bigButtonSpeaker.IsChecked);
      TangoEventPageBase.SendMessage((ISendableMessage) new AudioControlMessage(TangoEventPageBase.GetNextSeqId(), builder));
    }

    private void smallButtonMute_Click(object sender, RoutedEventArgs e)
    {
      this.OnMuteButtonClick(this.smallButtonMute.IsChecked);
    }

    private void smallButtonVideo_Click(object sender, RoutedEventArgs e)
    {
      this.OnVideoButtonClick(this.smallButtonVideo.IsChecked);
    }

    private void OnMuteButtonClick(bool isChecked)
    {
      if (this.WaitingForClickResult || AppManager.Instance.DataManager.CallingData == null)
        return;
      if (isChecked)
      {
        if (this.smallButtonMute.IsChecked && this.bigButtonMute.IsChecked)
          return;
        Tango.Toolbox.Logger.Trace("mute checked pressed");
        this.smallButtonMute.IsChecked = true;
        this.bigButtonMute.IsChecked = true;
        if (AppManager.Instance.DataManager.AudioMode != null)
          AppManager.Instance.DataManager.AudioMode.SetMuted(true);
        AudioControlPayload.Builder builder = AudioControlPayload.CreateBuilder();
        builder.SetMute(true);
        TangoEventPageBase.SendMessage((ISendableMessage) new AudioControlMessage(TangoEventPageBase.GetNextSeqId(), builder));
      }
      else
      {
        if (!this.smallButtonMute.IsChecked && !this.bigButtonMute.IsChecked)
          return;
        Tango.Toolbox.Logger.Trace("mute unchecked pressed");
        this.smallButtonMute.IsChecked = false;
        this.bigButtonMute.IsChecked = false;
        if (AppManager.Instance.DataManager.AudioMode != null)
          AppManager.Instance.DataManager.AudioMode.SetMuted(false);
        AudioControlPayload.Builder builder = AudioControlPayload.CreateBuilder();
        builder.SetMute(false);
        TangoEventPageBase.SendMessage((ISendableMessage) new AudioControlMessage(TangoEventPageBase.GetNextSeqId(), builder));
      }
    }

    private void OnVideoButtonClick(bool isChecked)
    {
      if (this.WaitingForClickResult || AppManager.Instance.DataManager.CallingData == null)
        return;
      if (isChecked)
      {
        this.HideVideoAlertBar();
        if (this.smallButtonVideo.IsChecked && this.bigButtonVideo.IsChecked)
          return;
        Tango.Toolbox.Logger.Trace("video checked pressed");
        TangoEventPageBase.SendMessage((ISendableMessage) new AddVideoMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
        this.smallButtonVideo.IsChecked = true;
        this.bigButtonVideo.IsChecked = true;
      }
      else
      {
        if (!this.smallButtonVideo.IsChecked && !this.bigButtonVideo.IsChecked)
          return;
        Tango.Toolbox.Logger.Trace("video unchecked pressed");
        TangoEventPageBase.SendMessage((ISendableMessage) new RemoveVideoMessage(TangoEventPageBase.GetNextSeqId(), AppManager.Instance.DataManager.CallingData.ToBuilder()));
        this.smallButtonVideo.IsChecked = false;
        this.bigButtonVideo.IsChecked = false;
      }
      this.smallButtonVideo.IsStateLocked = true;
      this.bigButtonVideo.IsStateLocked = true;
    }

    private void alertBar_Tap(object sender, TappedRoutedEventArgs e) => this.HideVideoAlertBar();

    private void HideVideoAlertBar()
    {
      if (!this._videoAlertBar.IsVisible)
        return;
      this._videoAlertBar.IsVisible = false;
      IsolatedStorageSettings applicationSettings = IsolatedStorageSettings.ApplicationSettings;
      applicationSettings[AudioVideoCallPage.VIDEO_ALERT_SHOWN] = (object) true;
      applicationSettings.Save();
    }

   
  }
}
