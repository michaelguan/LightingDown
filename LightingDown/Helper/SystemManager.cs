using System;
using System.Runtime.InteropServices;

namespace LightingDown
{
    public class SystemManager
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool ExitWindowsEx(int DoFlag, int rea);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, uint wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        private static extern long CDdoor(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private const int SE_PRIVILEGE_ENABLED = 0x00000002;
        private const int TOKEN_QUERY = 0x00000008;
        private const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
        private const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
        private const int EWX_LOGOFF = 0x00000000;
        private const int EWX_SHUTDOWN = 0x00000001;
        private const int EWX_REBOOT = 0x00000002;
        private const int EWX_FORCE = 0x00000004;
        private const int EWX_POWEROFF = 0x00000008;
        private const int EWX_FORCEIFHUNG = 0x00000010;
        private const uint WM_SYSCOMMAND = 0x0112;
        private const uint SC_MONITORPOWER = 0xF170;
        private static void DoExitWin(int DoFlag)
        {
            bool ok;
            TokPriv1Luid tp;
            IntPtr htok = IntPtr.Zero;
            ok = OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, ref htok);
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = SE_PRIVILEGE_ENABLED;
            ok = LookupPrivilegeValue(null, SE_SHUTDOWN_NAME, ref tp.Luid);
            ok = AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            ok = ExitWindowsEx(DoFlag, 0);
        }
        public static void Reboot()
        {
            DoExitWin(EWX_FORCE | EWX_REBOOT);
        }
        public static void PowerOff()
        {
            DoExitWin(EWX_FORCE | EWX_POWEROFF);
        }
        public static void LogOff()
        {
            DoExitWin(EWX_FORCE | EWX_LOGOFF);
        }

        public static void ShutDown()
        {
            DoExitWin(EWX_FORCE | EWX_SHUTDOWN);
        }
        public static void CloseMonitor(IntPtr handle)
        {
            SendMessage(handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
        public static void OpenMonitor(IntPtr handle)
        {
            SendMessage(handle, WM_SYSCOMMAND, SC_MONITORPOWER, -1);
        }

        public static void openCD()
        {
            CDdoor("set CDAudio door open", string.Empty, 0, 0);
        }

        public static void closedCD()
        {
            CDdoor("set CDAudio door closed", string.Empty, 0, 0);
        }
    }
}
