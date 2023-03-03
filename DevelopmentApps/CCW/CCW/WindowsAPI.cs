using System.Runtime.InteropServices;
using System.Text;

namespace LOS
{
    internal class WindowsAPI
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);
        public struct Rect
        {
            public int left, top, right, bottom;
        }
    }
}
