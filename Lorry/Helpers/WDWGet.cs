using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lorry.Helpers
{
    public class WDWGet
    {
        public static string windowName = string.Empty;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                windowName = Buff.ToString();
                return windowName;
            }
            return null;
        }
    }
}
