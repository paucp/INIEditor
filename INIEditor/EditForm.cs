using System.Windows.Forms;

namespace INIEditor
{
    public partial class EditForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string Comment { get; set; }
        public bool Cancelled { get; set; }
        private bool Group;
        public EditForm(string KeyName, string KeyValue, string Comment, bool Group = false)
        {
            this.KeyName = KeyName;
            this.KeyValue = KeyValue;
            this.Comment = Comment;
            this.Cancelled = true;
            this.Group = Group;            
            InitializeComponent();
            textBox1.Text = KeyName;
            textBox2.Text = KeyValue;
            textBox3.Text = Comment;
            if (Group)
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Name cant be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Group && textBox2.Text == "") MessageBox.Show("Value can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.KeyName = textBox1.Text;
                this.KeyValue = textBox2.Text;
                this.Comment = textBox3.Text;
                this.Cancelled = false;
                this.Close();
            }
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();
    }
}
