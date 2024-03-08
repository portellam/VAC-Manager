using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VACM.NET4_0.Extensions
{
    public sealed class DialogCenteringService : IDisposable
    {
        #region Parameters

        private IntPtr _hHook;
        private readonly IWin32Window _IWin32Window;
        private readonly Win32Native.HookProc _HookProc;

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iWin32Owner">The Win32 window</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DialogCenteringService(IWin32Window iWin32Owner)
        {
            _IWin32Window = iWin32Owner ??
                throw new ArgumentNullException(nameof(iWin32Owner));

            _HookProc = DialogHookProc;

            _hHook = Win32Native.SetWindowsHookEx(Win32Native.WH_CALLWNDPROCRET,
                _HookProc, IntPtr.Zero, Win32Native.GetCurrentThreadId());
        }

        DialogCenteringService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose of managed resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of managed resources.
        /// </summary>
        /// <param name="doDispose">Do dispose</param>
        private void Dispose(bool doDispose)
        {
            if (doDispose)
            {
                //NOTE: Add dispose calls of managed resources here.
            }

            if (_hHook != IntPtr.Zero)
            {
                Win32Native.UnhookWindowsHookEx(_hHook);
                _hHook = IntPtr.Zero;
            }
        }

        private IntPtr DialogHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return Win32Native.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            var msg = (Win32Native.CWPRETSTRUCT)Marshal.PtrToStructure(lParam,
                typeof(Win32Native.CWPRETSTRUCT));

            if (msg.message != (int)Win32Native.CbtHookAction.HCBT_ACTIVATE)
            {
                return Win32Native.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }

            try
            {
                CenterWindow(msg.hwnd);
            }
            finally
            {
                Win32Native.UnhookWindowsHookEx(_hHook);
                _hHook = IntPtr.Zero;
            }

            return Win32Native.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private bool CenterWindow(IntPtr hChildWnd)
        {
            var recParent = GetWindowRect(_IWin32Window.Handle);

            if (recParent is null)
            {
                return false;
            }

            return CenterWindow(hChildWnd, recParent.Value);
        }

        private static bool CenterWindow(IntPtr hChildWnd, Rectangle recParent)
        {
            var recChild = GetWindowRect(hChildWnd);

            if (recChild is null)
            {
                return false;
            }

            var centeredPoint = GetCenteredPoint(recParent, recChild.Value);

            return Win32Native.SetWindowPos(hChildWnd, IntPtr.Zero, centeredPoint.X,
                centeredPoint.Y, -1, -1,
                Win32Native.SetWindowPosFlags.SWP_ASYNCWINDOWPOS
                    | Win32Native.SetWindowPosFlags.SWP_NOSIZE
                    | Win32Native.SetWindowPosFlags.SWP_NOACTIVATE
                    | Win32Native.SetWindowPosFlags.SWP_NOOWNERZORDER
                    | Win32Native.SetWindowPosFlags.SWP_NOZORDER);
        }

        private static Point GetCenteredPoint(Rectangle recParent, Rectangle recChild)
        {
            var ptParentCenter = new Point
            {
                X = recParent.X + (recParent.Width / 2),
                Y = recParent.Y + (recParent.Height / 2)
            };

            var ptStart = new Point
            {
                X = ptParentCenter.X - (recChild.Width / 2),
                Y = ptParentCenter.Y - (recChild.Height / 2)
            };

            var recCentered = new Rectangle(ptStart.X, ptStart.Y, recChild.Width,
                recChild.Height);                                                       // Get centered rectangle.

            var workingArea = Screen.FromRectangle(recParent).WorkingArea;              // Find the working area of the parent.

            if (workingArea.X > recCentered.X)                                          // Make sure child window isn't spanning across multiple screens.
            {
                recCentered = new Rectangle(workingArea.X, recCentered.Y,
                    recCentered.Width, recCentered.Height);
            }

            if (workingArea.Y > recCentered.Y)
            {
                recCentered = new Rectangle(recCentered.X, workingArea.Y,
                    recCentered.Width, recCentered.Height);
            }

            if (workingArea.Right < recCentered.Right)
            {
                recCentered = new Rectangle(workingArea.Right - recCentered.Width,
                    recCentered.Y, recCentered.Width, recCentered.Height);
            }

            if (workingArea.Bottom < recCentered.Bottom)
            {
                recCentered = new Rectangle(recCentered.X,
                    workingArea.Bottom - recCentered.Height, recCentered.Width,
                    recCentered.Height);
            }

            return new Point(recCentered.X, recCentered.Y);
        }

        private static Rectangle? GetWindowRect(IntPtr hWnd)
        {
            var rect = new Win32Native.RECT();

            if (!Win32Native.GetWindowRect(hWnd, ref rect))
            {
                return null;
            }

            return new Rectangle(rect.left, rect.top, rect.right - rect.left,
                rect.bottom - rect.top);
        }

        #endregion

        #region Native/Unsafe

        /// <summary>
        /// Win32 API
        /// </summary>
        private static class Win32Native
        {
            #region Parameters

            private const string kernel32DllString = "kernel32.dll";
            private const string user32DllString = "user32.dll";

            public const int WH_CALLWNDPROCRET = 12;

            #endregion

            #region Structs

            public enum CbtHookAction
            {
                HCBT_MOVESIZE,
                HCBT_MINMAX,
                HCBT_QS,
                HCBT_CREATEWND,
                HCBT_DESTROYWND,
                HCBT_ACTIVATE,
                HCBT_CLICKSKIPPED,
                HCBT_KEYSKIPPED,
                HCBT_SYSCOMMAND,
                HCBT_SETFOCUS
            }

            [Flags]
            public enum SetWindowPosFlags : uint
            {
                SWP_ASYNCWINDOWPOS = 0x4000U,
                SWP_DEFERERASE = 0x2000U,
                SWP_DRAWFRAME = 0x0020U,
                SWP_FRAMECHANGED = 0x0020U,
                SWP_HIDEWINDOW = 0x0080U,
                SWP_NOACTIVATE = 0x0010U,
                SWP_NOCOPYBITS = 0x0100U,
                SWP_NOMOVE = 0x0002U,
                SWP_NOOWNERZORDER = 0x0200U,
                SWP_NOREDRAW = 0x0008U,
                SWP_NOREPOSITION = 0x0200U,
                SWP_NOSENDCHANGING = 0x0400U,
                SWP_NOSIZE = 0x0001U,
                SWP_NOZORDER = 0x0004U,
                SWP_SHOWWINDOW = 0x0040U
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct CWPRETSTRUCT
            {
                public IntPtr lResult;
                public IntPtr lParam;
                public IntPtr wParam;
                public uint message;
                public IntPtr hwnd;
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            #endregion

            #region Delegates

            public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport(user32DllString)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

            [DllImport(user32DllString)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
                int x, int y, int cx, int cy, SetWindowPosFlags uFlags);

            [DllImport(kernel32DllString)]
            public static extern int GetCurrentThreadId();

            [DllImport(user32DllString)]
            public static extern int UnhookWindowsHookEx(IntPtr idHook);

            [DllImport(user32DllString)]
            public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn,
                IntPtr hInstance, int threadId);

            [DllImport(user32DllString)]
            public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode,
                IntPtr wParam, IntPtr lParam);

            #endregion
        }

        #endregion
    }
}