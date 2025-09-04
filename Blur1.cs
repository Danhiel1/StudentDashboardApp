using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class BlurHelper
{
    [StructLayout(LayoutKind.Sequential)]
    private struct ACCENT_POLICY
    {
        public int AccentState;
        public int AccentFlags;
        public int GradientColor;
        public int AnimationId;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct WINDOWCOMPOSITIONATTRIBDATA
    {
        public int Attribute;
        public IntPtr Data;
        public int SizeOfData;
    }

    [DllImport("user32.dll")]
    private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WINDOWCOMPOSITIONATTRIBDATA data);

    public static void EnableBlur(Form form)
    {
        var accent = new ACCENT_POLICY
        {
            AccentState = 3 // ACCENT_ENABLE_BLURBEHIND
        };

        var size = Marshal.SizeOf(accent);
        var ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(accent, ptr, false);

        var data = new WINDOWCOMPOSITIONATTRIBDATA
        {
            Attribute = 19, // WCA_ACCENT_POLICY
            Data = ptr,
            SizeOfData = size
        };

        SetWindowCompositionAttribute(form.Handle, ref data);
        Marshal.FreeHGlobal(ptr);
    }
}
