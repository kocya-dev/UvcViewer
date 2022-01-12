using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace UvcViewer.Utils
{
    internal class WindowSizeUtil
    {
        private const int WM_SIZING = 0x214;
        private const int WMSZ_LEFT = 1;
        private const int WMSZ_RIGHT = 2;
        private const int WMSZ_TOP = 3;
        private const int WMSZ_TOPLEFT = 4;
        private const int WMSZ_TOPRIGHT = 5;
        private const int WMSZ_BOTTOM = 6;
        private const int WMSZ_BOTTOMLEFT = 7;
        private const int WMSZ_BOTTOMRIGHT = 8;
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public static void CorrectWindowAspectOnSizing(Message m, double ratio, Form window, Size minimumSize)
        {
            switch (m.Msg)
            {
                case WM_SIZING:
                    RECT r = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    RECT prev_r = r;
                    int w = r.right - r.left - (window.Size.Width - window.ClientSize.Width);
                    int h = r.bottom - r.top - (window.Size.Height - window.ClientSize.Height);
                    int dw = 0;
                    int dh = 0;
                    if ((w < (minimumSize.Width - window.ClientSize.Width)) || (h < (minimumSize.Height - window.ClientSize.Height)))
                    {
                        dw = minimumSize.Width - w;
                        dh = minimumSize.Height - h;
                    }
                    else
                    {
                        dw = (int)(h * ratio + 0.5) - w;
                        dh = (int)(w / ratio + 0.5) - h;
                    }
                    switch (m.WParam.ToInt32())
                    {
                        case WMSZ_TOP:
                        case WMSZ_BOTTOM:
                            r.right += dw;
                            break;
                        case WMSZ_LEFT:
                        case WMSZ_RIGHT:
                            r.bottom += dh;
                            break;
                        case WMSZ_TOPLEFT:
                            if (dw > 0) r.left -= dw;
                            else r.top -= dh;
                            break;
                        case WMSZ_TOPRIGHT:
                            if (dw > 0) r.right += dw;
                            else r.top -= dh;
                            break;
                        case WMSZ_BOTTOMLEFT:
                            if (dw > 0) r.left -= dw;
                            else r.bottom += dh;
                            break;
                        case WMSZ_BOTTOMRIGHT:
                            if (dw > 0) r.right += dw;
                            else r.bottom += dh;
                            break;
                    }
                    Marshal.StructureToPtr(r, m.LParam, false);

                    Debug.WriteLine($"{prev_r.left}:{prev_r.top} - {prev_r.right}:{prev_r.bottom} -> {r.left}:{r.top} - {r.right}:{r.bottom} diff {dw}:{dh}");
                    break;
                default:
                    break;
            }
        }
    }
}
