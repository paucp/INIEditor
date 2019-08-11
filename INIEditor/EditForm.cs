﻿using System.Windows.Forms;

namespace INIEditor
{
    public partial class EditForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string Comment { get; set; }
        public bool Cancelled { get; set; }
        public EditForm(string KeyName, string KeyValue, string Comment, bool Group = false)
        {
            this.KeyName = KeyName;
            this.KeyValue = KeyValue;
            this.Comment = Comment;
            this.Cancelled = true;
            InitializeComponent();
            textBox1.Text = KeyName;
            textBox2.Text = KeyValue;
            textBox3.Text = Comment;
            if (Group) textBox2.Enabled = false;
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.KeyName = textBox1.Text;
            this.KeyValue = textBox2.Text;
            this.Comment = textBox3.Text;
            this.Cancelled = false;
            this.Close();
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();
    }
}
