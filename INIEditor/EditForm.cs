using System.Windows.Forms;

namespace INIEditor
{
    public partial class EditForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public EditForm(string KeyName, string KeyValue)
        {
            this.KeyName = KeyName;
            this.KeyValue = KeyValue;
            InitializeComponent();
            textBox1.Text = KeyName;
            textBox2.Text = KeyValue;
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.KeyName = textBox1.Text;
            this.KeyValue = textBox2.Text;
            this.Close();
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();    
    }
}
