using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSRadioButton : RadioButton
    {
        private Color checkedColor = Color.FromArgb(0, 120, 214);
        private Color unChekedColor = Color.FromArgb(0, 120, 214);
        private Color checkedForeColor = Color.FromArgb(0, 120, 214);
        private Color disableColor = Color.Silver;

        private Color backupForeColor = Color.White;

        public Color CheckedColor
        {
            get => checkedColor;

            set
            {
                checkedColor = value;
                Invalidate();
            }
        }

        public Color UnChekedColor
        {
            get => unChekedColor;

            set
            {
                unChekedColor = value;
                Invalidate();
            }
        }

        public Color CheckedForeColor
        {
            get => checkedForeColor;
            set => checkedForeColor = value;
        }

        public Color DisableColor
        {
            get => disableColor;
            set => disableColor = value;
        }

        public IDDVSRadioButton()
        {
            MinimumSize = new Size(0, 21);
            Font = new Font("Calibri", 12.0f, FontStyle.Bold);
            ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Graphics g = pevent.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float rbBorderSize = 14.0F;
            float rbCheckSize = 8.0F;

            RectangleF rectRbBorder = new RectangleF()
            {
                X = 2.0F,
                Y = (Height - rbBorderSize) / 2,
                Width = rbBorderSize,
                Height = rbBorderSize
            };

            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
                Y = (Height - rbCheckSize) / 2,
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            using (Pen penBorder = new Pen(CheckedColor, 1.6F))
            {
                using (SolidBrush brushRbCheck = new SolidBrush(CheckedColor))
                {
                    using (SolidBrush brushText = new SolidBrush(ForeColor))
                    {
                        g.Clear(BackColor);

                        if (!Enabled)
                        {
                            brushText.Color = DisableColor;
                            penBorder.Color = DisableColor;
                            brushRbCheck.Color = DisableColor;
                        }

                        if (Checked)
                        {
                            g.DrawEllipse(penBorder, rectRbBorder);
                            g.FillEllipse(brushRbCheck, rectRbCheck);
                        }
                        else
                        {
                            if (Enabled)
                                penBorder.Color = UnChekedColor;

                            g.DrawEllipse(penBorder, rectRbBorder);
                        }

                        g.DrawString(Text, Font, brushText, rbBorderSize + 8, (Height - TextRenderer.MeasureText(Text, Font).Height) / 2);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);

            if (Checked)
            {
                backupForeColor = ForeColor;
                ForeColor = CheckedForeColor;
            }
            else
                ForeColor = backupForeColor;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");

                e.Handled = true;
            }
        }
    }
}
