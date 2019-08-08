using System.Collections.Generic;
using System.Windows.Forms;


namespace INIEditor
{
    public partial class Main : Form
    {
        private Ini Ini;
        private IniIO IniIO;        
        private string LastSelectedKeyName;
        private string LastSelectedKeyValue;        
        private int LastSelectedGroupIndex;
        public Main()
        {
            InitializeComponent();
        }
        #region ListviewFunctions
        private void UpdateLastSelectedItem()
        {
            LastSelectedKeyName = listView1.SelectedItems[0].SubItems[0].Text;
            LastSelectedKeyValue = listView1.SelectedItems[0].SubItems[1].Text;            
            LastSelectedGroupIndex = GetGroupIndex(listView1.SelectedItems[0].Group.Header);
        }
        private int GetGroupIndex(string GroupName)
            => Ini.Groups.FindIndex(x => x.Name == GroupName);
        private void AddKey(string Name, string Value, string GroupName)
        {
            int GroupIndex = GetGroupIndex(GroupName);
            Ini.Groups[GroupIndex].IniKeys.Add(new KeyValuePair<string, string>(Name, Value));
            listView1.Items.Add(new ListViewItem(new[] { Name, Value }, listView1.Groups[GroupIndex]));
        }
        private void RemoveKey()
        {
            Ini.Groups[LastSelectedGroupIndex].IniKeys.Remove(LastSelectedKeyName);
            listView1.SelectedItems[0].Remove();
            if (Ini.Groups[LastSelectedGroupIndex].IniKeys.Count == 0)
                Ini.Groups.Remove(Ini.Groups[LastSelectedGroupIndex]);
        }
        private void EditKey(string NewKeyName, string NewKeyValue)
        {
            Ini.Groups[LastSelectedGroupIndex].IniKeys.Remove(LastSelectedKeyName);
            Ini.Groups[LastSelectedGroupIndex].IniKeys.Add(new KeyValuePair<string, string>(NewKeyName, NewKeyValue));
            listView1.SelectedItems[0].SubItems[0].Text = NewKeyName;
            listView1.SelectedItems[0].SubItems[1].Text = NewKeyValue;
            UpdateLastSelectedItem();
        }
        private void ListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            buttonEdit.Enabled = listView1.SelectedItems.Count != 0;
            buttonDelete.Enabled = listView1.SelectedItems.Count != 0;
            if (listView1.SelectedItems.Count != 0)
                UpdateLastSelectedItem();

        }
        #endregion
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

        #region Menu
        private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();
            IniIO = new IniIO(ofd.FileName);
            Ini = IniIO.ReadIni();            
            LoadIniToListView();                         
            buttonNew.Enabled = true;
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
        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
           => this.Close();
        #endregion

        #region Buttons
        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            EditForm EditForm = new EditForm(LastSelectedKeyName, LastSelectedKeyValue);
            EditForm.ShowDialog();
            if (!EditForm.Cancelled)
                EditKey(EditForm.KeyName, EditForm.KeyValue);
        }
        private void buttonNew_Click(object sender, System.EventArgs e)
        {
            NewForm NewForm = new NewForm(Ini.Groups);
            NewForm.ShowDialog();
            if (!NewForm.Cancelled)
                AddKey(NewForm.KeyName, NewForm.KeyValue, NewForm.GroupName);
        }
        private void buttonDelete_Click(object sender, System.EventArgs e)
            => RemoveKey();       
        #endregion


    }
}
