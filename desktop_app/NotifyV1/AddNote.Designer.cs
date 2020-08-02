namespace NotifyV1
{
    partial class AddNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNote));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.minBtn = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.discardBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bodyBox = new System.Windows.Forms.RichTextBox();
            this.nlistBox = new System.Windows.Forms.ComboBox();
            this.nblistBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.minBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 47);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(370, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "x";
            this.label1.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 13.74046F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 34);
            this.label5.TabIndex = 10;
            this.label5.Text = "Add Note";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(328, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 34);
            this.label2.TabIndex = 10;
            this.label2.Text = "-";
            this.label2.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.AutoSize = true;
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1027, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(31, 34);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "x";
            // 
            // minBtn
            // 
            this.minBtn.AutoSize = true;
            this.minBtn.BackColor = System.Drawing.Color.Transparent;
            this.minBtn.Font = new System.Drawing.Font("Consolas", 15.93893F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minBtn.ForeColor = System.Drawing.Color.White;
            this.minBtn.Location = new System.Drawing.Point(985, 4);
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(31, 34);
            this.minBtn.TabIndex = 8;
            this.minBtn.Text = "-";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.discardBtn);
            this.panel2.Controls.Add(this.saveBtn);
            this.panel2.Controls.Add(this.tagBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.bodyBox);
            this.panel2.Controls.Add(this.nlistBox);
            this.panel2.Controls.Add(this.nblistBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 485);
            this.panel2.TabIndex = 2;
            // 
            // discardBtn
            // 
            this.discardBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.discardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.discardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.99237F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.discardBtn.Location = new System.Drawing.Point(213, 422);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Size = new System.Drawing.Size(180, 49);
            this.discardBtn.TabIndex = 30;
            this.discardBtn.Text = "Discard";
            this.discardBtn.UseVisualStyleBackColor = false;
            this.discardBtn.Click += new System.EventHandler(this.discardBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.99237F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveBtn.Location = new System.Drawing.Point(16, 422);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(180, 49);
            this.saveBtn.TabIndex = 29;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // tagBox
            // 
            this.tagBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagBox.Location = new System.Drawing.Point(16, 196);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(377, 28);
            this.tagBox.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 27;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "Add Tags";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Note Title";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 24);
            this.label7.TabIndex = 24;
            this.label7.Text = "Notebook Title";
            // 
            // bodyBox
            // 
            this.bodyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyBox.Location = new System.Drawing.Point(16, 266);
            this.bodyBox.Name = "bodyBox";
            this.bodyBox.Size = new System.Drawing.Size(377, 139);
            this.bodyBox.TabIndex = 23;
            this.bodyBox.Text = "";
            // 
            // nlistBox
            // 
            this.nlistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nlistBox.FormattingEnabled = true;
            this.nlistBox.Location = new System.Drawing.Point(16, 124);
            this.nlistBox.Name = "nlistBox";
            this.nlistBox.Size = new System.Drawing.Size(377, 30);
            this.nlistBox.TabIndex = 22;
            // 
            // nblistBox
            // 
            this.nblistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.89313F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nblistBox.FormattingEnabled = true;
            this.nblistBox.Location = new System.Drawing.Point(16, 52);
            this.nblistBox.Name = "nblistBox";
            this.nblistBox.Size = new System.Drawing.Size(377, 30);
            this.nblistBox.TabIndex = 21;
            this.nblistBox.SelectedIndexChanged += new System.EventHandler(this.nblistBox_SelectionChangeCommitted);
            // 
            // AddNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 532);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Note";
            this.Load += new System.EventHandler(this.EditSave_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Label minBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button discardBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox bodyBox;
        private System.Windows.Forms.ComboBox nlistBox;
        private System.Windows.Forms.ComboBox nblistBox;
    }
}