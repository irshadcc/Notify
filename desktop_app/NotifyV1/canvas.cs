using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NotifyV1
{
    class Canvas : Form
    {
        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;

        
        public Canvas()
        {

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = 0;
            this.Left = 0;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Opacity = 0.30;
            this.Cursor = Cursors.Cross;
            this.MouseDown += Canvas_MouseDown;
            this.MouseMove += Canvas_MouseMove;
            this.MouseUp += Canvas_MouseUp;
            this.Paint += Canvas_Paint;
            this.KeyDown += Canvas_KeyDown;
            this.DoubleBuffered = true;
            //Console.WriteLine("{0}", this.Size);
            //Console.WriteLine("{0}", this.ClientSize);
            //Console.WriteLine("{0}", this.Location);


            // InitializeComponent();

        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        public Rectangle GetRectangle()
        {
                return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }


        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;
            //Console.WriteLine("Mouse Down : {0}", startPos);
            currentPos = e.Location;
            drawing = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Refresh();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Mouse Up : {0}", e.Location);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            using (Pen dashed_pen = new Pen(Color.Black, 2))
            {
                dashed_pen.DashStyle = DashStyle.Dash;
                if (drawing) e.Graphics.DrawRectangle(dashed_pen, GetRectangle());

            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(282, 251);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
    }
    
}


