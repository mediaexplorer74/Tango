// Decompiled with JetBrains decompiler
// Type: WinPhoneTango.CallBackManager
// Assembly: WinPhoneTango, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30584BBB-B630-4C4B-8981-EFEC72A92E80
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\WinPhoneTango.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using Tango.Toolbox;

#nullable disable
namespace WinPhoneTango
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class CallBackManager : IEventCallback
  {
    private string _toRemoveNavigationPage;
    private bool _makeCallFromContactList;
    private Queue<CallBackManager.Message> _messageQueue = new Queue<CallBackManager.Message>();
    private object _messageQueueLock = new object();

    public CallBackManager()
    {
      AppManager.Instance.EventManager.CurrentPageUpdated += new EventManager.CurrentPageUpdatedDelegate(this.OnCurrentPageUpdated);
    }

    private void OnCurrentPageUpdated()
    {
      if (AppManager.Instance.EventManager.CurrentPage == null)
        return;
      this.DispatchNextQueueMessage();
    }

    private void DispatchNextQueueMessage()
    {
      if (AppManager.Instance.EventManager.CurrentPage == null)
      {
        Logger.Trace("current page is not available, can't dispatch queue message.");
      }
      else
      {
        int num = 0;
        CallBackManager.Message message = (CallBackManager.Message) null;
        lock (this._messageQueueLock)
        {
          num = this._messageQueue.Count;
          if (num > 0)
            message = this._messageQueue.Dequeue();
        }
        if (message == null)
          return;
        Logger.Trace(string.Format("Handle the first message from the queue (count = {0}), id = {1}", (object) num, (object) message.messageId));
        AppManager.Instance.EventManager.HandleTangoEvent(message.messageId, message.data);
        this.DispatchNextQueueMessage();
      }
    }

    private void ReceiveEvent(int messageId, int size, byte[] data)
    {
      lock (this._messageQueueLock)
        this._messageQueue.Enqueue(new CallBackManager.Message(messageId, data));
      this.DispatchNextQueueMessage();
    }

    void IEventCallback.UIMessageCallback(int messageId, int size, byte[] data)
    {
      if (App.IsQuiting)
        return;
      Logger.Trace(string.Format("IEventCallback.UIMessageCallback() ui event is received from engine-core, id = {0}, size = {1}.", (object) messageId, (object) size));
      if (AppManager.Instance.EventManager.CurrentPage != null && ((DependencyObject) AppManager.Instance.EventManager.CurrentPage).Dispatcher != null)
        ((DependencyObject) AppManager.Instance.EventManager.CurrentPage).Dispatcher.BeginInvoke((Delegate) new CallBackManager.DispatchMessageDelegate(this.ReceiveEvent), new object[3]
        {
          (object) messageId,
          (object) size,
          (object) data
        });
      else if (Deployment.Current != null && ((DependencyObject) Deployment.Current).Dispatcher != null)
      {
        ((DependencyObject) Deployment.Current).Dispatcher.BeginInvoke((Delegate) new CallBackManager.DispatchMessageDelegate(this.ReceiveEvent), new object[3]
        {
          (object) messageId,
          (object) size,
          (object) data
        });
      }
      else
      {
        Logger.Trace("Dispather is not available, put the message back to the queue.");
        lock (this._messageQueueLock)
          this._messageQueue.Enqueue(new CallBackManager.Message(messageId, data));
      }
    }

    private class Message
    {
      public int messageId;
      public byte[] data;

      public Message(int messageId, byte[] data)
      {
        this.messageId = messageId;
        this.data = (byte[]) data.Clone();
      }
    }

    private delegate void DispatchMessageDelegate(int messageId, int size, byte[] data);
  }
}
