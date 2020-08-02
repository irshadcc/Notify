using System;
using System.Drawing;
using System.Windows.Forms;

namespace NotifyV1
{
    public partial class LoginPage : Form
    {
        bool mov;
        int movX;
        int movY;

        public LoginPage()
        {
            InitializeComponent();
            var pos = this.PointToScreen(registerLabel.Location);
            pos = pictureBox1.PointToClient(pos);
            registerLabel.Parent = pictureBox1;
            registerLabel.Location = pos;
            registerLabel.BackColor = Color.Transparent;
            pos = this.PointToScreen(label1.Location);
            pos = pictureBox1.PointToClient(pos);
            label1.Parent = pictureBox1;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;
            
            pos = this.PointToScreen(rememberBox.Location);
            pos = pictureBox1.PointToClient(pos);
            rememberBox.Parent = pictureBox1;
            rememberBox.Location = pos;
            rememberBox.BackColor = Color.Transparent;


        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            pictureBox1.Enabled = true;
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

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }
        

        private void quitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string email = useremailBox.Text;
            string pwd = passwordBox.Text;
            bool remember = rememberBox.Checked;
            await DBInterface.Authenticate(email, pwd, remember, SignIn);
            DBInterface.Connect();
        }

        public void SignIn()
        {
            this.Dispose();
        }

        private void registerLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://biblography-6adfa.web.app/");
        }
    }
}
