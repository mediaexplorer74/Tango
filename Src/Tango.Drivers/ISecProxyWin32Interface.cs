// Decompiled with JetBrains decompiler
// Type: Tango.Drivers.ISecProxyWin32Interface
// Assembly: Tango.Drivers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 074EEAC2-86C6-4295-8E6E-DD244C491822
// Assembly location: C:\Users\Admin\Desktop\RE\Tango\Tango.Drivers.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Tango.Drivers
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("2A9C50C0-77AC-4a12-9E26-17395ADF8870")]
  [ComImport]
  public interface ISecProxyWin32Interface
  {
    void GetProxyVersion(out uint version);

    void Reserved();

    void ChekcAPI(uint apiID, out uint result);

    void RegistrySetString(uint HKEY, string pwszPath, string valueName, string value);

    void RegistryGetString(uint HKEY, string pwszPath, string valueName, out string value);

    void RegistrySetDWORD(uint HKEY, string pwszPath, string valueName, uint value);

    void RegistryGetDWORD(uint HKEY, string pwszPath, string valueName, out uint value);

    void CreateFile(
      string lpFileName,
      uint dwDesiredAccess,
      uint dwShareMode,
      uint dwCreationDisposition,
      uint dwFlagsAndAttributes,
      out uint phCreateFile);

    void CloseHandle(uint hObject);

    void ReadFile(
      uint hFile,
      out byte[] lpBuffer,
      uint nNumberOfBytesToRead,
      out uint lpNumberOfBytesRead);

    void WriteFile(
      uint hFile,
      byte[] lpBuffer,
      uint nNumberOfBytesToWrite,
      out uint lpNumberOfBytesWritten);

    void GetFileSize(uint hFile, out uint lpFileSizeHigh);

    void CopyFile(string lpExistingFileName, string lpNewFileName, int bFailIfExists);

    void DeleteFile(string lpFileName);

    void LaunchExe(string szExe, string szArg);

    void DMProcessConfigXML(string lpXmlString, uint dwFlag, out string pbstrout);

    void RegistryGetSubKeys(uint HKEY, string pwszPath, out string pszValue);

    void RegistryGetSubValues(uint HKEY, string pwszPath, out string pszValue);

    void RegistryGetValueType(uint HKEY, string pwszPath, string pwszValueName, out uint dwValue);

    void IsFileExist(string lpFileName, string lpNum);

    void GetAllFileNames(string lpPath, string lpSearch, uint dwOption, out string pszValue);

    void LaunchSessionByUri(string lpUrl);

    void CreateDirectory(string lpPathName);

    void ChangeWlanWatchDogPeriod(uint dwFlag);
  }
}
