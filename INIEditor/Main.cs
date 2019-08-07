using System.Windows.Forms;
using System.Collections.Generic;


namespace INIEditor
{
    public partial class Main : Form
    {
        private Ini Ini;
        private IniIO IniIO;
        public Main()
        {
            InitializeComponent();
        }       
        private void LoadIniToListView()
        {           
            for (int i = 0; i < Ini.Groups.Count; ++i)
            {
                ListViewGroup Group = new ListViewGroup(Ini.Groups[i].Name);                
                listView1.Groups.Add(Group);
                foreach (KeyValuePair<string, string> Key in Ini.Groups[i].IniKeys)
                    listView1.Items.Add(new ListViewItem(new[] { Key.Key, Key.Value }, Group));
            }
        }
        private int GetGroupIndex(string GroupName)    
            => Ini.Groups.FindIndex(x => x.Name == GroupName);
        private void AddKey(string Name, string Value, string GroupName)
        {

            int GroupIndex = GetGroupIndex(GroupName);
            Ini.Groups[GroupIndex].IniKeys.Add(new KeyValuePair<string, string>(Name, Value));
            listView1.Items.Add(new ListViewItem(new[] {Name, Value }, listView1.Groups[GroupIndex]));
        }      
        private void RemoveKey()
        {            
            int GroupIndex = GetGroupIndex(listView1.SelectedItems[0].Group.Name);
            Ini.Groups[GroupIndex].IniKeys.Remove(listView1.SelectedItems[0].SubItems[0].ToString());
            listView1.SelectedItems[0].Remove();
            if (Ini.Groups[GroupIndex].IniKeys.Count == 0)
                Ini.Groups.Remove(Ini.Groups[GroupIndex]);
        }
        private void EditKey(string NewKeyName, string NewKeyValue)
        {
            int GroupIndex = GetGroupIndex(listView1.SelectedItems[0].Group.Name);            
            listView1.SelectedItems[0].SubItems[0].Text = NewKeyName;
            listView1.SelectedItems[0].SubItems[0].Text = NewKeyValue;
            //Ini.Groups[GroupIndex].IniKeys[listView1.SelectedItems[0].SubItems[0].Text] = new 
        }
        private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();
            IniIO = new IniIO(ofd.FileName);
            Ini = IniIO.ReadIni();
            LoadIniToListView();
            button1.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;            
        }
        private void SaveToolStripMenuItem_Click(object sender, System.EventArgs e)
            => IniIO.WriteIni(Ini);     
        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            IniIO.WriteAs(Ini, sfd.FileName);
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            EditForm EditForm = new EditForm("", "");
            EditForm.KeyValue = listView1.SelectedItems[0].SubItems[0].ToString();
            EditForm.KeyName = listView1.SelectedItems[0].SubItems[1].ToString();
            EditForm.ShowDialog();
            if (!EditForm.Cancelled)
                EditKey(EditForm.KeyName, EditForm.KeyValue);                            
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            NewForm NewForm = new NewForm(Ini.Groups);
            NewForm.ShowDialog();
            if (!NewForm.Cancelled)
                AddKey(NewForm.KeyName, NewForm.KeyValue, NewForm.GroupName);         
        }
        private void Button3_Click(object sender, System.EventArgs e)                 
            => RemoveKey();          
        
        private void ListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            button2.Enabled = listView1.SelectedItems.Count != 0;
            button3.Enabled = listView1.SelectedItems.Count != 0;           
        }
    }
}
