using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyV1
{
   
    public partial class Welcome : Form
    {
        bool mov;
        int movX;
        int movY;

        public Welcome()
        {

            InitializeComponent();

            var pos = this.PointToScreen(signedinMsg.Location);
            pos = pictureBox1.PointToClient(pos);
            signedinMsg.Parent = pictureBox1;
            signedinMsg.Location = pos;
            signedinMsg.BackColor = Color.Transparent;
            pos = this.PointToScreen(email.Location);
            pos = pictureBox1.PointToClient(pos);
            email.Parent = pictureBox1;
            email.Location = pos;
            email.BackColor = Color.Transparent;


            this.email.Text = DBInterface.FetchUser();
            DBInterface.Connect();

        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
        }

        private void cntdBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void signoutBtn_Click(object sender, EventArgs e)
        {
            File.Delete(DBInterface.path);
            this.Dispose();
            LoginPage lgin = new LoginPage();
            lgin.ShowDialog();
            //this.Dispose();

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            movX = e.X;
            movY = e.Y;
        }
    }
}
