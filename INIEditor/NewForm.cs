using System.Collections.Generic;
using System.Windows.Forms;

namespace INIEditor
{
    public partial class NewForm : Form
    {
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public string Comment { get; set; }
        public string GroupName { get; set; }
        public bool Cancelled { get; set; }
        public NewForm(List<IniGroup> Groups, bool NewGroup = false)
        {
            this.Cancelled = true;
            InitializeComponent();
            if (!NewGroup)
            {
                foreach (IniGroup Group in Groups)
                    comboBox1.Items.Add(Group.Name);
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox1.AutoCompleteSource = AutoCompleteSource.None;
            }           
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Name cant be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (textBox2.Text == "") MessageBox.Show("Value can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(comboBox1.Text == "") MessageBox.Show("Group can't be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                this.KeyName = textBox1.Text;
                this.KeyValue = textBox2.Text;
                this.Comment = textBox3.Text;
                this.GroupName = comboBox1.Text;
                this.Cancelled = false;
                this.Close();
            }
        }
        private void Button2_Click(object sender, System.EventArgs e)
            => this.Close();
    }
}
