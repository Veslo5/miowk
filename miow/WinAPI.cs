using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace miow
{

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;
    }

    public partial class WinAPI
    {
        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial int GetWindowLongA(IntPtr hWnd, int nIndex);
        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial int SetWindowLongA(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EX_STYLE = -20;
        private const int WS_EX_APPWINDOW = 0x00040000, WS_EX_TOOLWINDOW = 0x00000080;

        [LibraryImport("user32.dll", SetLastError = true)]
        private static partial int GetCursorPos(out POINT lpPoint);


        private static IntPtr raylibHWND;
        public static void InitWinAPI()
        {
            unsafe
            {
                var handle = Raylib.GetWindowHandle();
                var hwnd = new IntPtr(handle);
                raylibHWND = hwnd;
            }
        }
        

        public static void HideRaylibIcon()
        {
            _ = SetWindowLongA(raylibHWND, GWL_EX_STYLE, (GetWindowLongA(raylibHWND, GWL_EX_STYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
        }

        public static Vector2 GetCursorPosition()
        {
            var outparam = new POINT();
            _ = GetCursorPos(out outparam);            

            return new Vector2(outparam.x, outparam.y);
        }
    }
}