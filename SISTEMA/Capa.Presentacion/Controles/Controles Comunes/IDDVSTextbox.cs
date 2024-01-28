using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa.Presentacion.Controles
{
    public partial class IDDVSTextbox : UserControl
    {
        private const int WM_COPY = 0x301;
        private const int WM_PASTE = 0x302;

        public event EventHandler TextBeingCopied;
        public event EventHandler TextWasCopied;
        public event EventHandler TextBeingPasted;
        public event EventHandler TextWasPasted;
        public event EventHandler _TextChanged;
        public event EventHandler _KeyPress;

        private Color borderColor = Color.FromArgb(0, 120, 214);
        private int borderSize = 1;
        private bool underlineStyle = false;
        private Color borderFocusColor = Color.FromArgb(3, 254, 202);
        private Color foreFocusColor = Color.FromArgb(3, 254, 202);
        private Color borderColorDisabled = Color.Silver;
        private Color foreColorDisabled = Color.Gray;

        private bool isFocus = false;
        private Color defaultForeColor = Color.White;

        public IDDVSTextbox()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, false);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.Font = new Font("Calibri", 12, FontStyle.Bold);
            this.BackColor = Color.FromArgb(33, 35, 38);
        }

        public Color ForeColorDisabled
        {
            get => foreColorDisabled;

            set
            {
                if (!value.Equals(Color.Empty))
                    foreColorDisabled = value;
            }
        }

        public Color BorderColorDisabled
        {
            get => borderColorDisabled;

            set
            {
                if (!value.Equals(Color.Empty))
                    borderColorDisabled = value;
            }
        }

        public Color BorderColor
        {
            get => borderColor;

            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public Color BorderFocusColor
        {
            get => borderFocusColor;

            set
            {
                borderFocusColor = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get => borderSize;
            
            set
            {
                borderSize = value;
                //UpdateControlHeight();
                Invalidate();
            }
        }

        public bool UnderLinedStyle
        {
            get => underlineStyle;

            set
            {
                underlineStyle = value;
                Invalidate();
            }
        }

        public Color ForeFocusColor
        {
            get => foreFocusColor;
            set => foreFocusColor = value;
        }

        public string Texts
        {
            get => txtControl.Text;
            
            set
            {
                txtControl.Text = value;

                if (DesignMode)
                    Invalidate();
            }
        }

        public bool IsFocus
        {
            get => isFocus;
        }

        public bool ReadOnly
        {
            get => txtControl.ReadOnly;
            set => txtControl.ReadOnly = value;
        }

        public bool PasswordChar
        {
            get => txtControl.UseSystemPasswordChar;
            set => txtControl.UseSystemPasswordChar = value;
        }

        public HorizontalAlignment TextAlign
        {
            get => txtControl.TextAlign;
            set => txtControl.TextAlign = value;
        }

        public int SelectionLength
        {
            get => txtControl.SelectionLength;
            set => txtControl.SelectionLength = value;
        }

        public int SelectionStart
        {
            get => txtControl.SelectionStart;    
            set => txtControl.SelectionStart = value;
        }

        public bool Multiline
        {
            get => txtControl.Multiline;
            set => txtControl.Multiline = value;
        }

        public override Color ForeColor
        {
            get => defaultForeColor;
            set => defaultForeColor = value;
        }

        public override Color BackColor
        {
            get => base.BackColor;

            set
            {
                base.BackColor = value;
                txtControl.BackColor = value;
            }
        }

        public override Font Font
        {
            get => base.Font;
            
            set
            {
                base.Font = value;
                txtControl.Font = value;

                //UpdateControlHeight();
            }
        }

        public override string Text
        {
            get => txtControl.Text;

            set
            {
                txtControl.Text = value;

                if (DesignMode)
                    Invalidate();
            }
        }

        public int MaxLength
        {
            get => txtControl.MaxLength;
            set => txtControl.MaxLength = value;
        }

        public CharacterCasing CharacterCasing
        {
            get => txtControl.CharacterCasing;
            set => txtControl.CharacterCasing = value;
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if(borderSize > 0)
            {
                Graphics graph = e.Graphics;

                using (Pen penBorder = new Pen(BorderColor, BorderSize))
                {
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                    if(!Enabled)
                    {
                        penBorder.Color = BorderColorDisabled;
                        txtControl.ForeColor = ForeColorDisabled;
                    }
                    else
                    {
                        if (IsFocus && !ReadOnly)
                        {
                            penBorder.Color = BorderFocusColor;
                            txtControl.ForeColor = ForeFocusColor;
                        }
                        else
                            txtControl.ForeColor = ForeColor;
                    }

                    if (UnderLinedStyle)
                        graph.DrawLine(penBorder, 0, this.Height, this.Width, this.Height);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5f, this.Height - 0.5f);
                }
            }        
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case WM_COPY:
                    TextBeingCopied(this, new EventArgs());
                    break;
                case WM_PASTE:
                    TextBeingPasted(this, new EventArgs());
                    break;
            }

            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_COPY:
                    TextWasCopied(this, new EventArgs());
                    break;
                case WM_PASTE:
                    TextWasPasted(this, new EventArgs());
                    break;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //UpdateControlHeight();

            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //UpdateControlHeight();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            isFocus = false;

            this.Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            isFocus = true;

            txtControl.Select();

            this.Invalidate();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            this.Invalidate();
        }

        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if(!DesignMode)
                _TextChanged?.Invoke(sender, e);
        }

        private void txtControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!DesignMode)
            {
                _KeyPress?.Invoke(sender, e);

                if (e.KeyChar == (char)Keys.Enter)
                {
                    SendKeys.Send("{TAB}");

                    e.Handled = true;
                }
            }
        }

        private void UpdateControlHeight()
        {
            if (!txtControl.Multiline)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1; 

                txtControl.Multiline = true;
                txtControl.MinimumSize = new Size(0, txtHeight);
                txtControl.Multiline = false;

                this.Padding = new Padding(7, 7, 7, (BorderSize > 7)? BorderSize + 1 : 7);

                this.Height = txtControl.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

    }
}
