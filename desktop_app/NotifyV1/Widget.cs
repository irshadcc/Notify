using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;

namespace NotifyV1
{
    public partial class Widget : Form
    {

        // For Movable widget

        bool mov;
        int movX;
        int movY;
        

        public Widget()
        {
            InitializeComponent();
        }

        
        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X;
            movY = e.Y;
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minBtn_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void snipBtn_Click(object sender, EventArgs e)
        {
            ScreenCapture snippingTool = new ScreenCapture();
            this.Hide();
            if(snippingTool.SetCanvas())
            {
                Image snip = snippingTool.GetSnapShot();
                SaveNote save_dialog = new SaveNote(snip);
                save_dialog.ShowDialog();
                this.Show();
            }
            else
            {
                this.Show();
            }
            

        }

        private void noteBtn_Click(object sender, EventArgs e)
        {
            /*
             * Image blankImage = new Bitmap(761,504, PixelFormat.Format24bppRgb);

            using (Graphics grp = Graphics.FromImage(blankImage))
            {
                grp.FillRectangle(Brushes.White, 0, 0, 761, 504);
                //resultImage = new Bitmap(image1.Width, image1.Height, grp);
            }*/
            this.Hide();
            AddNote save_dialog = new AddNote();
            save_dialog.ShowDialog();
            this.Show();

        }

        private void Widget_Load(object sender, EventArgs e)
        {
            if (File.Exists(DBInterface.path))
            {
                Welcome wlcm = new Welcome();
                wlcm.ShowDialog();
            }
            else
            {
                //this.Hide();
                LoginPage lginPg = new LoginPage();
                lginPg.ShowDialog();
                //this.Show();
            }

        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://biblography-6adfa.web.app/");
        }

        private void aiBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To be implemented");
        }
    }
}
