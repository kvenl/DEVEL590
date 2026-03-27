using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace The590Box
{
    internal class SilverKnobTrackBar : TrackBar
    {
        public SilverKnobTrackBar()
        {
            AutoSize = false;
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        // Prevent the native Win32 TrackBar from auto-resizing based on range/tick config.
        // BoundsSpecified.None = native-originated resize, not user/designer code.
        // Skip at design time so the designer host can initialize bounds freely.
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (!AutoSize && !DesignMode && IsHandleCreated && specified == BoundsSpecified.None)
            {
                width  = Width;
                height = Height;
            }
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(BackColor);

            int cx = Width / 2;
            const int vPad = 13; // top/bottom padding for the trackable area

            int trackTop    = vPad;
            int trackBottom = Height - vPad;
            int trackH      = trackBottom - trackTop;
            int range       = Maximum - Minimum;

            // Ticks on both sides — white, just outside the knob edges
            if (TickStyle != TickStyle.None && TickFrequency > 0 && range > 0)
            {
                using var tickPen = new Pen(Color.White, 1);
                int steps = range / TickFrequency;
                for (int i = 0; i <= steps; i++)
                {
                    int ty = trackTop + (int)Math.Round((double)i / steps * trackH);
                    g.DrawLine(tickPen, cx - 14, ty, cx - 9, ty); // left
                    g.DrawLine(tickPen, cx +  9, ty, cx + 14, ty); // right
                }
            }

            // Center groove
            using (var groovePen = new Pen(Color.DimGray, 2))
                g.DrawLine(groovePen, cx, trackTop, cx, trackBottom);

            // Silver knob — max at top, min at bottom
            double ratio   = range == 0 ? 0.0 : (double)(Value - Minimum) / range;
            int    thumbCY = trackBottom - (int)Math.Round(ratio * trackH);

            const int thumbW = 20;
            const int thumbH = 10;
            var thumb    = new Rectangle(cx - thumbW / 2, thumbCY - thumbH / 2, thumbW, thumbH);
            var gradRect = new Rectangle(thumb.X, thumb.Y, thumb.Width, Math.Max(thumb.Height, 1));

            using (var grad = new LinearGradientBrush(gradRect, Color.White, Color.Silver, LinearGradientMode.Vertical))
                g.FillRectangle(grad, thumb);

            using (var border = new Pen(Color.Gray, 1))
                g.DrawRectangle(border, thumb);
        }
    }
}
