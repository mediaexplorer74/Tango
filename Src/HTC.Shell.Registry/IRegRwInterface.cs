// Decompiled with JetBrains decompiler
// Type: HTC.Shell.Registry.IRegRwInterface
// Assembly: HTC.Shell.Registry, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEE318F1-7786-4BBB-AFA2-CAB22DF75667
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\HTC.Shell.Registry.dll

using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace HTC.Shell.Registry
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("BB2013C7-A917-4D43-B918-62CD659521EE")]
  [ComImport]
  internal interface IRegRwInterface
  {
    void RegistryGetDword(
      uint uKey,
      string strSubKey,
      string strValueName,
      out uint uData,
      out uint uResult);

    void RegistrySetDword(
      uint uKey,
      string strSubKey,
      string strValueName,
      uint uData,
      out uint uResult);

    void RegistryGetString(
      uint uKey,
      string strSubKey,
      string strValueName,
      StringBuilder strData,
      out uint uResult);

    void RegistrySetString(
      uint uKey,
      string strSubKey,
      string strValueName,
      string pszData,
      out uint uResult);

    void RegFlushKey(uint dwKey, out uint uResult);

    void Init(out uint uResult);

    void Deinit(out uint uResult);

    void IsHTCDevice(out uint isHTCDevice);

    void GetVersionInfo(string szSearchKey, StringBuilder szRequestVersion, out uint uRet);

    void IsAPExist(string szProductID, out uint uResult);

    void LaunchAP(string szProductID, out uint uResult);
  }
}
