namespace NotifyV1
{
    partial class Welcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.signedinMsg = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.signoutBtn = new System.Windows.Forms.Button();
            this.cntdBtn = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.LinkLabel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // signedinMsg
            // 
            this.signedinMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signedinMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.99237F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signedinMsg.ForeColor = System.Drawing.Color.Black;
            this.signedinMsg.Location = new System.Drawing.Point(71, 164);
            this.signedinMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.signedinMsg.Name = "signedinMsg";
            this.signedinMsg.Size = new System.Drawing.Size(248, 27);
            this.signedinMsg.TabIndex = 3;
            this.signedinMsg.Text = "You are signed in as";
            this.signedinMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::NotifyV1.Properties.Resources.animation1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 455);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // signoutBtn
            // 
            this.signoutBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.signoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74046F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signoutBtn.ForeColor = System.Drawing.Color.White;
            this.signoutBtn.Location = new System.Drawing.Point(209, 318);
            this.signoutBtn.Name = "signoutBtn";
            this.signoutBtn.Size = new System.Drawing.Size(161, 50);
            this.signoutBtn.TabIndex = 8;
            this.signoutBtn.Text = "Logout";
            this.signoutBtn.UseVisualStyleBackColor = false;
            this.signoutBtn.Click += new System.EventHandler(this.signoutBtn_Click);
            // 
            // cntdBtn
            // 
            this.cntdBtn.BackColor = System.Drawing.SystemColors.ControlText;
            this.cntdBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cntdBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.74046F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntdBtn.ForeColor = System.Drawing.Color.White;
            this.cntdBtn.Location = new System.Drawing.Point(16, 318);
            this.cntdBtn.Name = "cntdBtn";
            this.cntdBtn.Size = new System.Drawing.Size(161, 50);
            this.cntdBtn.TabIndex = 7;
            this.cntdBtn.Text = "Continue";
            this.cntdBtn.UseVisualStyleBackColor = false;
            this.cntdBtn.Click += new System.EventHandler(this.cntdBtn_Click);
            // 
            // email
            // 
            this.email.DisabledLinkColor = System.Drawing.Color.Blue;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.99237F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.LinkColor = System.Drawing.Color.RoyalBlue;
            this.email.Location = new System.Drawing.Point(11, 220);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(368, 41);
            this.email.TabIndex = 9;
            this.email.TabStop = true;
            this.email.Text = "linkLabel1";
            this.email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 40;
            this.bunifuElipse1.TargetControl = this.cntdBtn;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 40;
            this.bunifuElipse2.TargetControl = this.signoutBtn;
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(391, 455);
            this.Controls.Add(this.email);
            this.Controls.Add(this.signoutBtn);
            this.Controls.Add(this.cntdBtn);
            this.Controls.Add(this.signedinMsg);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.99237F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Welcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label signedinMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button signoutBtn;
        private System.Windows.Forms.Button cntdBtn;
        private System.Windows.Forms.LinkLabel email;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
    }
}