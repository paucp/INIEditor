using System.Collections.Generic;
using System.Windows.Forms;

namespace INIEditor
{
    public partial class NewForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string GroupName { get; set; }
        public bool Cancelled { get; set; }
        public NewForm(List<IniGroup> Groups)
        {           
            this.Cancelled = true;
            InitializeComponent();
            foreach (IniGroup Group in Groups)
                comboBox1.Items.Add(Group.Name);
            comboBox1.Text = comboBox1.Items[0].ToString();
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.KeyName = textBox1.Text;
            this.KeyValue = textBox2.Text;
            this.GroupName = comboBox1.Text;
            this.Cancelled = false;
            this.Close();
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();    
    }
}
