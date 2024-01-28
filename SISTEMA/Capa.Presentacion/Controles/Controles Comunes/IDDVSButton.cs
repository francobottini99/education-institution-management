using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Capa.Presentacion.Controles
{
    public class IDDVSButton : Button
    {
        private const int WM_ENABLE = 0xA;
        
        private int borderSize = 2;
        private int borderRadius = 10;
        private Color borderColor = Color.FromArgb(0, 120, 214);
        private Color borderFocusColor = Color.FromArgb(3, 254, 202);
        private Color foreFocusColor = Color.FromArgb(3, 254, 202);
        private Color disableBackColor = Color.Gainsboro;
        private Color disableBorderColor = Color.Silver;
        private Color disableForeColor = Color.Gray;

        private Color backupForeColor;
        private Color backupBackColor;
        private Color backupBorderColor;

        private bool savedColors = false;
        private bool settingColors = false;
        private bool isFocus = false;

        private Color defaultForeColor;

        public IDDVSButton()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 120, 214);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(120, 40);
            this.BackColor = Color.FromArgb(33, 35, 38);
            this.ForeColor = Color.White;
            this.Font = new Font("Calibri", 12, FontStyle.Bold);

            defaultForeColor = ForeColor;
        }

        public int BorderSize { get => borderSize; set { borderSize = value; this.Invalidate(); } }
        public int BorderRadius { get => borderRadius; set { borderRadius = value; this.Invalidate(); } }
        public Color BorderColor { get => borderColor; set { borderColor = value; this.Invalidate(); } }
        public Color BorderFocusColor { get => borderFocusColor; set { borderFocusColor = value; this.Invalidate(); } }
        public Color ForeFocusColor { get => foreFocusColor; set => foreFocusColor = value; }

        public Color DisableBackColor 
        { 
            get => disableBackColor; 

            set 
            { 
                if (!value.Equals(Color.Empty))
                    disableBackColor = value;

                SetColors();
            } 
        }

        public Color DisableBorderColor 
        { 
            get => disableBorderColor;

            set
            {
                if (!value.Equals(Color.Empty))
                    disableBorderColor = value;

                SetColors();
            }
        }

        public Color DisableForeColor 
        { 
            get => disableForeColor;

            set
            {
                if (!value.Equals(Color.Empty))
                    disableForeColor = value;

                SetColors();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;

            set
            {
                base.ForeColor = value;

                //if (!isFocus)
                //    defaultForeColor = value;
            }
        }

        [Browsable(false)]
        protected override bool ShowFocusCues { get => false; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp;

                if (!Enabled)
                {
                    Enabled = true;
                    cp = base.CreateParams;
                    Enabled = false;
                }
                else
                    cp = base.CreateParams;

                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);
            int smoothSize = 2;

            if(BorderSize > 0)
                smoothSize = BorderSize;

            if (BorderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - BorderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    Region = new Region(pathSurface);

                    e.Graphics.DrawPath(penSurface, pathSurface);

                    if (isFocus && Enabled)
                        penBorder.Color = BorderFocusColor;

                    e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                e.Graphics.SmoothingMode = SmoothingMode.None;

                this.Region = new Region(rectSurface);
                                
                if (BorderSize > 0)
                {
                    using (Pen penBorder = new Pen(BorderColor, BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;

                        if (isFocus && Enabled)
                            penBorder.Color = BorderFocusColor;

                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_ENABLE:
                    return;
            }

            base.WndProc(ref m);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            isFocus = true;
            ForeColor = ForeFocusColor;

            this.Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            isFocus = false;
            ForeColor = defaultForeColor;

            this.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            isFocus = true;
            ForeColor = ForeFocusColor;

            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            isFocus = false;
            ForeColor = defaultForeColor;

            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (BorderRadius > Height)
                BorderRadius = Height;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            SetColors();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object enviar, EventArgs e)
        { 
            this.Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);

            if (!settingColors)
            {
                backupForeColor = ForeColor;

                SetColors();
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);

            if (!settingColors)
            {
                backupBackColor = BackColor;
                backupBorderColor = BorderColor;

                SetColors();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (!DesignMode)
            {
                if (!savedColors && Visible)
                {
                    backupBackColor = BackColor;
                    backupBorderColor = BorderColor;
                    backupForeColor = ForeColor;

                    savedColors = true;

                    SetColors();
                }
            }
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            float curveSize = radius * 2.0f;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseAllFigures();

            return path;
        }

        private void SetColors()
        {
            if (savedColors)
            {
                settingColors = true;

                if (Enabled)
                {
                    ForeColor = backupForeColor;
                    BackColor = backupBackColor;
                    BorderColor = backupBorderColor;
                }
                else
                {
                    ForeColor = DisableForeColor;
                    BackColor = DisableBackColor;
                    BorderColor = DisableBorderColor;
                }

                settingColors = false;
            }

            this.Invalidate();
        }
    }
}