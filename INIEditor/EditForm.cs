using System.Windows.Forms;

namespace INIEditor
{
    public partial class EditForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public bool Cancelled { get; set; }
        public EditForm(string KeyName, string KeyValue, bool Group = false)
        {
            this.KeyName = KeyName;
            this.KeyValue = KeyValue;
            this.Cancelled = true;
            InitializeComponent();
            textBox1.Text = KeyName;
            textBox2.Text = KeyValue;
            if (Group) textBox2.Enabled = false;
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.KeyName = textBox1.Text;
            this.KeyValue = textBox2.Text;
            this.Cancelled = false;
            this.Close();
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();
    }
}
