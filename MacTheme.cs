using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacOSThemes.Theme
{
    // Created by absolutenothing
    // put file inside your solution
    // then build, you will have two controls: MacOSDarkTheme & MacOSLightTheme

    #region DarkTheme
    public class MacOSDarkTheme : ContainerControl
    {
        MacThemeHeader TitleBar = new MacThemeHeader();

        MacThemeBTN Maximize = new MacThemeBTN() { HoverChar = "➕", MacBtnLocation = new Point(1, 2), MacBtnColor = Color.FromArgb(21, 122, 30) };
        MacThemeBTN Minimize = new MacThemeBTN() { HoverChar = "▬", MacBtnLocation = new Point(1, 1), MacBtnColor = Color.FromArgb(147, 76, 37) };
        MacThemeBTN Exit = new MacThemeBTN() { HoverChar = "❌", MacBtnLocation = new Point(1,3), MacBtnColor = Color.FromArgb(135, 8, 7) };

        private Form Form;
        public MacOSDarkTheme()
        {
            this.BackColor = Color.FromArgb(34,34,34);

            TitleBar.Dock = DockStyle.Top;
            TitleBar.Size = new System.Drawing.Size(this.Bounds.X, 30);
            TitleBar.BackColor = Color.FromArgb(20,20,20);
            this.Controls.Add(TitleBar);


            Exit.Location = new Point(771, 8);
            TitleBar.Controls.Add(Exit);

            Maximize.Location = new Point(746, 8);
            TitleBar.Controls.Add(Maximize);

            Minimize.Location = new Point(719, 8);
            TitleBar.Controls.Add(Minimize);

       
            Events();
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void Events()
        {
            Exit.Click += Exit_Click;
            Minimize.Click += Minimize_Click;
            Maximize.Click += Maximize_Click;

            TitleBar.MouseDown += (sender, e) => {mouseDown = true; lastLocation = e.Location; };
            TitleBar.MouseUp += (sender, e) => { mouseDown = false; };
            TitleBar.MouseMove += Title_MouseMove;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (Parent is Form)
                {
                    Parent.Location = new Point(
                        (Parent.Location.X - lastLocation.X) + e.X, (Parent.Location.Y - lastLocation.Y) + e.Y);
                }
                
            }
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            Form.WindowState = Form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;           
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            Form.WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form.Close();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            if (Parent is Form)
            {
                Form parentForm = Parent as Form;
                Form = parentForm;

                parentForm.FormBorderStyle = FormBorderStyle.None;

                base.OnHandleCreated(e);
            }
        }
    }
    #endregion

    #region LightTheme
    public class MacOSLightTheme : ContainerControl
    {
        bool preview = true;
        
        MacThemeHeader TitleBar = new MacThemeHeader();

        MacThemeBTN Maximize = new MacThemeBTN() { HoverChar = "➕", MacBtnLocation = new Point(1, 2), MacBtnColor = Color.FromArgb(21, 122, 30) };
        MacThemeBTN Minimize = new MacThemeBTN() { HoverChar = "▬", MacBtnLocation = new Point(1, 1), MacBtnColor = Color.FromArgb(147, 76, 37) };
        MacThemeBTN Exit = new MacThemeBTN() { HoverChar = "❌", MacBtnLocation = new Point(1, 3), MacBtnColor = Color.FromArgb(135, 8, 7) };

        private Form Form;
        public MacOSLightTheme()
        {
            this.BackColor = Color.White;

            TitleBar.Dock = DockStyle.Top;
            TitleBar.Size = new System.Drawing.Size(this.Bounds.X, 30);
            TitleBar.BackColor = Color.FromArgb(244,244,244,244);
            this.Controls.Add(TitleBar);

            double p1 = 772.2;
            Exit.Location = new Point(772, 8);
            TitleBar.Controls.Add(Exit);

            Maximize.Location = new Point(746, 8);
            TitleBar.Controls.Add(Maximize);

            Minimize.Location = new Point(719, 8);
            TitleBar.Controls.Add(Minimize);


            Events();
        }

        private bool mouseDown = false;
        private Point lastLocation;

        private void Events()
        {
            Exit.Click += Exit_Click;
            Minimize.Click += Minimize_Click;
            Maximize.Click += Maximize_Click;

            TitleBar.MouseDown += (sender, e) => { mouseDown = true; lastLocation = e.Location; };
            TitleBar.MouseUp += (sender, e) => { mouseDown = false; };
            TitleBar.MouseMove += Title_MouseMove;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (Parent is Form)
                {
                    Parent.Location = new Point(
                        (Parent.Location.X - lastLocation.X) + e.X, (Parent.Location.Y - lastLocation.Y) + e.Y);
                }

            }
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            Form.WindowState = Form.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            Form.WindowState = FormWindowState.Minimized;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Form.Close();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            Dock = DockStyle.Fill;
            if (Parent is Form)
            {
                Form parentForm = Parent as Form;
                Form = parentForm;

                parentForm.FormBorderStyle = FormBorderStyle.None;

                base.OnHandleCreated(e);
            }
        }
    }
    #endregion

    #region ThemeParts
    [ToolboxItem(false)]
    public class MacThemeHeader : Panel
    {

        internal int ButtonSize = 14;

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush exitBtnBrush = new SolidBrush(Color.FromArgb(255, 85, 81));
            SolidBrush minimizeBtnBrush = new SolidBrush(Color.FromArgb(255, 189, 0));
            SolidBrush maximizeBtnBrush = new SolidBrush(Color.FromArgb(0, 207, 39));

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.High;

            e.Graphics.FillEllipse(exitBtnBrush, 770, Bounds.Y / 2 + (ButtonSize / 2), ButtonSize, ButtonSize);
            e.Graphics.FillEllipse(maximizeBtnBrush, 745, Bounds.Y / 2 + (ButtonSize / 2), ButtonSize, ButtonSize);
            e.Graphics.FillEllipse(minimizeBtnBrush, 718, Bounds.Y / 2 + (ButtonSize / 2), ButtonSize, ButtonSize);


            exitBtnBrush.Dispose();
            minimizeBtnBrush.Dispose();
            maximizeBtnBrush.Dispose();

            base.OnPaint(e);
        }
    }

    [ToolboxItem(false)]
    class MacThemeBTN : Button
    {
        public string HoverChar { private get; set; }
        public Point MacBtnLocation { private get; set; }
        public Color MacBtnColor { private get; set; }

        private bool HoverTrigger = false;
        private Font drawFont = new Font("Arial", 6, FontStyle.Regular);

        public MacThemeBTN()
        {
            BackColor = Color.Transparent;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;


            Size = new Size(12, 12);
            MouseEnter += MacButton_MouseEnter;
            MouseLeave += MacButton_MouseLeave;
            
        }

        private void MacButton_MouseLeave(object sender, EventArgs e)
        {
            HoverTrigger = false;
            Invalidate();
        }

        private void MacButton_MouseEnter(object sender, EventArgs e)
        {
            HoverTrigger = true;
            Cursor = Cursors.Hand;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (GraphicsPath gPath = new GraphicsPath())
            {
                gPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
                this.Region = new Region(gPath);
            }

            using (SolidBrush drawBrush = new SolidBrush(MacBtnColor))
            {
                if(HoverTrigger)
                  pevent.Graphics.DrawString(HoverChar, drawFont, drawBrush, MacBtnLocation.X, MacBtnLocation.Y);
            }

            Text = String.Empty;
        }
    }
#endregion
}
