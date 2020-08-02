using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotifyV1
{
    
    public partial class SaveNote : Form
    {
        private static Image snip;
        bool mov;
        int movX;
        int movY;

        public SaveNote(Image init)
        {
            InitializeComponent();
            snip = init;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov)
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


        public void SetNBList(List<string> nblist)
        {
            nblistBox.Items.Clear();
            foreach (string nb in nblist)
            {
                nblistBox.Items.Add(nb);
            }
        }

        public void SetNoteList(List<string> nlist)
        {
            nlistBox.Items.Clear();
            foreach (string nb in nlist)
            {
                nlistBox.Items.Add(nb);
            }
        }



        private void nblistBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (nblistBox.Items.Contains(nblistBox.Text))
            {
                //DBInterface.GetNBid(nblistBox.Text, SetNbId);
                DBInterface.GetNoteList(nblistBox.Text, SetNoteList);
            }
        }

        private void discardBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string nbtitle = nblistBox.Text;
            string notetitle = nlistBox.Text;
            string body = bodyBox.Text;
            bool ocr = ocrBox.Checked;
            string tags = tagBox.Text;
            Image img = snip;


            if (!nblistBox.Items.Contains(nbtitle))
            {
                DBInterface.AddNotebook(nbtitle);
            }
            //DBInterface.GetNBid(nbtitle, SetNbId);
            //MessageBox.Show(nbid);
            if (!nlistBox.Items.Contains(notetitle))
            {
                DBInterface.AddImgNote(notetitle, nbtitle, body, tags, img, ocr);
            }
            else
            {
                //DBInterface.GetNoteid(nblistBox.Text, SetNoteId);
                DBInterface.UpdateNote(notetitle, tags, body, img, ocr);
            }

            this.Dispose();
        }

        public void setText(string s)
        {
            s = Regex.Replace(s, @"\s+", " ");
            richTextBox1.Text = s;
            richTextBox1.Visible = true;
        }

        private void EditSave_Load(object sender, EventArgs e)
        {
            snipImg.Image = snip;
            DBInterface.GetNotebookList(SetNBList);
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ocrBox_CheckedChanged(object sender, EventArgs e)
        {
            if(ocrBox.Checked)
            {
                DBInterface.GetOCR(snip, setText);
            }
            else
            {
                richTextBox1.Visible = false;
            }
        }
    }
}
