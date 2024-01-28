using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public class IDDVSProgressBar : ProgressBar
    {
        public enum TextPosition
        {
            Left,
            Right,
            Center,
            Sliding,
            None
        }

        private Color chanelColor = Color.FromArgb(33, 35, 38);
        private Color slideColor = Color.FromArgb(0, 120, 214);
        private Color foreBackColor = Color.Transparent;
        private int chanelHeight = 5;
        private int slideHeight = 5;
        private TextPosition showValue = TextPosition.None;
        private string symbolBefore = "";
        private string symbolAfter = "";
        private bool showMaximun = false;

        private bool stopPainting = false;

        public Color ChanelColor
        {
            get => chanelColor;

            set
            {
                chanelColor = value;
                this.Invalidate();
            }
        }

        public Color SlideColor
        {
            get => slideColor;
            
            set
            {
                slideColor = value;
                this.Invalidate();
            }
        }

        public Color ForeBackColor
        {
            get => foreBackColor;

            set
            {
                foreBackColor = value;
                this.Invalidate();
            }
        }

        public int ChanelHeight
        {
            get => chanelHeight;

            set
            {
                chanelHeight = value;
                this.Invalidate();
            }
        }

        public int SlideHeight
        {
            get => slideHeight;

            set
            {
                slideHeight = value;
                this.Invalidate();
            }
        }

        public TextPosition ShowValue
        {
            get => showValue;

            set
            {
                showValue = value;
                this.Invalidate();
            }
        }

        public string SymbolBefore
        {
            get => symbolBefore;
            set => symbolBefore = value;
        }

        public string SymbolAfter
        {
            get => symbolAfter;
            set => symbolAfter = value;
        }

        public bool ShowMaximun
        {
            get => showMaximun;
            set => showMaximun = value;
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        public IDDVSProgressBar()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            ForeColor = Color.White;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            if (!stopPainting)
            {
                Graphics graph = pevent.Graphics;
                Rectangle rectChannel = new Rectangle(0, 0, Width, ChanelHeight);

                using (SolidBrush brushChannel = new SolidBrush(ChanelColor))
                {
                    if (ChanelHeight >= SlideHeight)
                        rectChannel.Y = Height - ChanelHeight;
                    else
                        rectChannel.Y = (int)Math.Round(Height - ((ChanelHeight + SlideHeight) / (double)2), 0);

                    graph.Clear(Parent.BackColor);
                    graph.FillRectangle(brushChannel, rectChannel);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!stopPainting)
            {
                Graphics graph = e.Graphics;
                double scaleFactor = (Value - Minimum) / (double)(Maximum - Minimum);
                int slideWidth = (int)Math.Round(Width * scaleFactor, 0);
                Rectangle rectSlider = new Rectangle(0, 0, slideWidth, SlideHeight);

                using (SolidBrush brushSlide = new SolidBrush(SlideColor))
                {
                    if (SlideHeight >= ChanelHeight)
                        rectSlider.Y = Height - SlideHeight;
                    else
                        rectSlider.Y = (int)Math.Round(Height - ((ChanelHeight + SlideHeight) / (double)2), 0);

                    if (slideWidth > 1)
                        graph.FillRectangle(brushSlide, rectSlider);

                    if (ShowValue != TextPosition.None)
                        DrawnValueText(graph, slideWidth, rectSlider);
                }
            }

            /*if (Value == Maximum)
                stopPainting = true;
            else
                stopPainting = false;*/
        }

        private void DrawnValueText(Graphics graph, int slideWidth, Rectangle rectSlider)
        {
            string text = SymbolBefore + Value.ToString() + SymbolAfter;

            if (ShowMaximun)
                text += "/" + SymbolBefore + Maximum.ToString() + SymbolAfter;

            Size textSize = TextRenderer.MeasureText(text, Font);
            Rectangle rectText = new Rectangle(0, (Height - textSize.Height) / 2, textSize.Width, textSize.Height + 2);

            using (SolidBrush brushText = new SolidBrush(ForeColor))
            {
                using (SolidBrush brushTextBack = new SolidBrush(ForeBackColor))
                {
                    using (StringFormat textFormat = new StringFormat())
                    {
                        switch (ShowValue)
                        {
                            case TextPosition.Left:
                                {
                                    rectText.X = 0;
                                    textFormat.Alignment = StringAlignment.Near;
                                    break;
                                }

                            case TextPosition.Right:
                                {
                                    rectText.X = Width - textSize.Width;
                                    textFormat.Alignment = StringAlignment.Far;
                                    break;
                                }

                            case TextPosition.Center:
                                {
                                    rectText.X = (int)Math.Round((Width - textSize.Width) / (double)2, 0);
                                    textFormat.Alignment = StringAlignment.Center;
                                    break;
                                }

                            case TextPosition.Sliding:
                                {
                                    rectText.X = slideWidth - textSize.Width;
                                    textFormat.Alignment = StringAlignment.Center;

                                    using (SolidBrush brushClear = new SolidBrush(Parent.BackColor))
                                    {
                                        Rectangle rect = rectSlider;

                                        rect.Y = rectText.Y;
                                        rect.Height = rectText.Height;

                                        graph.FillRectangle(brushClear, rect);
                                    }

                                    break;
                                }
                        }

                        graph.FillRectangle(brushTextBack, rectText);
                        graph.DrawString(text, Font, brushText, rectText, textFormat);
                    }
                }
            }
        }
    }
}
