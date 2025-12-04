// Decompiled with JetBrains decompiler
// Type: Google.ProtocolBuffers.IRpcController
// Assembly: Google.ProtocolBuffers, Version=2.3.0.277, Culture=neutral, PublicKeyToken=17b3b1f090c3ea48
// MVID: DCD4250F-A6B8-4ABE-ACAD-D5AB755B0D2E
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Google.ProtocolBuffers.dll

using System;

#nullable disable
namespace Google.ProtocolBuffers
{
  public interface IRpcController
  {
    void Reset();

    bool Failed { get; }

    string ErrorText { get; }

    void StartCancel();

    void SetFailed(string reason);

    bool isCanceled();

    void NotifyOnCancel(Action<object> callback);
  }
}
