namespace NotifyV1
{
    partial class Widget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Widget));
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.snipBtn = new System.Windows.Forms.ToolStripButton();
            this.noteBtn = new System.Windows.Forms.ToolStripButton();
            this.openBtn = new System.Windows.Forms.ToolStripButton();
            this.aiBtn = new System.Windows.Forms.ToolStripButton();
            this.quitBtn = new System.Windows.Forms.ToolStripButton();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Label();
            this.minBtn = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 104);
            this.panel2.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(100, 100);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snipBtn,
            this.noteBtn,
            this.openBtn,
            this.aiBtn,
            this.quitBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(402, 104);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // snipBtn
            // 
            this.snipBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.snipBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.snipBtn.Image = global::NotifyV1.Properties.Resources.camera;
            this.snipBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.snipBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.snipBtn.Name = "snipBtn";
            this.snipBtn.Size = new System.Drawing.Size(80, 100);
            this.snipBtn.Text = "toolStripButton1";
            this.snipBtn.ToolTipText = "Snip an image";
            this.snipBtn.Click += new System.EventHandler(this.snipBtn_Click);
            // 
            // noteBtn
            // 
            this.noteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.noteBtn.Image = global::NotifyV1.Properties.Resources.note;
            this.noteBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.noteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.noteBtn.Name = "noteBtn";
            this.noteBtn.Size = new System.Drawing.Size(80, 100);
            this.noteBtn.Text = "toolStripButton2";
            this.noteBtn.ToolTipText = "Add a note";
            this.noteBtn.Click += new System.EventHandler(this.noteBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openBtn.Image = global::NotifyV1.Properties.Resources.notebook;
            this.openBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(80, 100);
            this.openBtn.ToolTipText = "Open your notebooks";
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // aiBtn
            // 
            this.aiBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.aiBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aiBtn.Image = global::NotifyV1.Properties.Resources.ai;
            this.aiBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.aiBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aiBtn.Name = "aiBtn";
            this.aiBtn.Size = new System.Drawing.Size(80, 100);
            this.aiBtn.Text = "toolStripButton4";
            this.aiBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.aiBtn.ToolTipText = "Meet Ava";
            this.aiBtn.Click += new System.EventHandler(this.aiBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quitBtn.Image = global::NotifyV1.Properties.Resources.quit;
            this.quitBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.quitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(79, 100);
            this.quitBtn.Text = "toolStripButton5";
            this.quitBtn.ToolTipText = "Quit";
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 40;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.minBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 49);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.AutoSize = true;
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(358, 9);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(31, 34);
            this.closeBtn.TabIndex = 7;
            this.closeBtn.Text = "x";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click_1);
            // 
            // minBtn
            // 
            this.minBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minBtn.AutoSize = true;
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minBtn.ForeColor = System.Drawing.Color.White;
            this.minBtn.Location = new System.Drawing.Point(316, 9);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(31, 34);
            this.minBtn.TabIndex = 6;
            this.minBtn.Text = "-";
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13.74046F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notify";
            // 
            // Widget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 153);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Widget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Widget";
            this.Load += new System.EventHandler(this.Widget_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Label minBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton snipBtn;
        private System.Windows.Forms.ToolStripButton noteBtn;
        private System.Windows.Forms.ToolStripButton openBtn;
        private System.Windows.Forms.ToolStripButton aiBtn;
        private System.Windows.Forms.ToolStripButton quitBtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
    }
}