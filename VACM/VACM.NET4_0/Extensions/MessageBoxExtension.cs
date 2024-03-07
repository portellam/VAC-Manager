using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VACM.NET4_0.Extensions
{
    /// <summary>
    /// Extension for MessageBox library
    /// </summary>
    public class MessageBoxExtension
    {
        #region Parameters

        private const string dllToImport = "user32.dll";

        private static IntPtr _hHook;
        private static HookProc _hookProc;
        private static IWin32Window _iWin32Window;

        [DllImport(dllToImport)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport(dllToImport)]
        private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth,
            int nHeight, bool bRepaint);

        public const int WH_CALLWNDPROCRET = 12;
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent,
            uint dwTime);

        public enum CbtHookAction : int
        {
            HCBT_MOVESIZE = 0,
            HCBT_MINMAX = 1,
            HCBT_QS = 2,
            HCBT_CREATEWND = 3,
            HCBT_DESTROYWND = 4,
            HCBT_ACTIVATE = 5,
            HCBT_CLICKSKIPPED = 6,
            HCBT_KEYSKIPPED = 7,
            HCBT_SYSCOMMAND = 8,
            HCBT_SETFOCUS = 9
        }

        [DllImport(dllToImport)]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport(dllToImport)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder stringBuilder,
            int maxLength);

        [DllImport(dllToImport)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport(dllToImport)]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport(dllToImport)]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
            IntPtr lParam);

        [DllImport(dllToImport)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn,
            IntPtr hInstance, int threadId);

        [DllImport("User32.dll")]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent,
            uint uElapse, TimerProc lpTimerFunc);

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        #endregion

        #region Logic

        /// <summary>
        /// Constructor
        /// </summary>
        public static void MessageBoxEx()
        {
            _hookProc = new HookProc(MessageBoxHookProc);
            _hHook = IntPtr.Zero;
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam,
            IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam,
                typeof(CWPRETSTRUCT));

            IntPtr hook = _hHook;

            if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
            {
                try
                {
                    CenterWindow(msg.hwnd);
                }
                finally
                {
                    UnhookWindowsHookEx(_hHook);
                    _hHook = IntPtr.Zero;
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void Initialize()
        {
            if (_hHook != IntPtr.Zero)
            {
                throw new NotSupportedException("Multiple calls are not supported.");
            }

            if (_iWin32Window is null)
            {
                return;
            }

            _hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero,
                AppDomain.GetCurrentThreadId());
        }

        private static void CenterWindow(IntPtr hChildWnd)
        {
            Rectangle recChild = new Rectangle(0, 0, 0, 0);
            bool isSuccess = GetWindowRect(hChildWnd, ref recChild);

            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;

            Rectangle recParent = new Rectangle(0, 0, 0, 0);
            isSuccess = GetWindowRect(_iWin32Window.Handle, ref recParent);

            Point ptCenter = new Point(0, 0);
            ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
            ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);


            Point ptStart = new Point(0, 0);
            ptStart.X = (ptCenter.X - (width / 2));
            ptStart.Y = (ptCenter.Y - (height / 2));

            ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
            ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

            int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width,
                height, false);
        }

        public static DialogResult Show(string text)
        {
            Initialize();
            return MessageBox.Show(text);
        }

        public static DialogResult Show(string text, string caption)
        {
            Initialize();
            return MessageBox.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption,
            MessageBoxButtons messageBoxButtons)
        {
            Initialize();
            return MessageBox.Show(text, caption, messageBoxButtons);
        }

        public static DialogResult Show(string text, string caption,
            MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            Initialize();
            return MessageBox.Show(text, caption, messageBoxButtons, messageBoxIcon);
        }

        public static DialogResult Show(string text, string caption,
            MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton messageBoxDefaultButton)
        {
            Initialize();

            return MessageBox.Show(text, caption, messageBoxButtons, messageBoxIcon,
                messageBoxDefaultButton);
        }

        public static DialogResult Show(string text, string caption,
            MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton messageBoxDefaultButton,
            MessageBoxOptions messageBoxOptions)
        {
            Initialize();

            return MessageBox.Show(text, caption, messageBoxButtons, messageBoxIcon,
                messageBoxDefaultButton, messageBoxOptions);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text)
        {
            _iWin32Window = iWin32Window;
            Initialize();
            return MessageBox.Show(iWin32Window, text);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text,
            string caption)
        {
            _iWin32Window = iWin32Window;
            Initialize();
            return MessageBox.Show(iWin32Window, text, caption);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text,
            string caption, MessageBoxButtons messageBoxButtons)
        {
            _iWin32Window = iWin32Window;
            Initialize();
            return MessageBox.Show(iWin32Window, text, caption, messageBoxButtons);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text,
            string caption, MessageBoxButtons messageBoxButtons,
            MessageBoxIcon messageBoxIcon)
        {
            _iWin32Window = iWin32Window;
            Initialize();

            return MessageBox.Show(iWin32Window, text, caption, messageBoxButtons,
                messageBoxIcon);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text,
            string caption, MessageBoxButtons messageBoxButtons,
            MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton messageBoxDefaultButton)
        {
            _iWin32Window = iWin32Window;
            Initialize();

            return MessageBox.Show(iWin32Window, text, caption, messageBoxButtons,
                messageBoxIcon, messageBoxDefaultButton);
        }

        public static DialogResult Show(IWin32Window iWin32Window, string text,
            string caption, MessageBoxButtons messageBoxButtons,
            MessageBoxIcon messageBoxIcon,
            MessageBoxDefaultButton messageBoxDefaultButton, MessageBoxOptions options)
        {
            _iWin32Window = iWin32Window;
            Initialize();

            return MessageBox.Show(iWin32Window, text, caption, messageBoxButtons,
                messageBoxIcon, messageBoxDefaultButton, options);
        }

        #endregion
    }
}