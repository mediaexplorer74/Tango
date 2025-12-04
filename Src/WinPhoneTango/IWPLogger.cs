using System;
using System.Text;

namespace WinPhoneTango
{
    public interface IWPLogger
    {
        void DebugWriteLine(StringBuilder log);
    }
}