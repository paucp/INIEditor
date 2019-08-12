using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace INIEditor
{
    public partial class Main : Form
    {
        private bool SaveFileUpdated = true;

        private Color Green = Color.FromArgb(100, 108, 198, 68);
        private Color Yellow = Color.FromArgb(100, 235, 206, 66);

        private Ini Ini;
        private IniIO IniIO;

        private List<IniKey> ItemCopy;
        private SearchManager SearchManager;
        
        private IniKey LastSelectedKey;
        private string LastSelectedKeyName => LastSelectedKey.Name;
        private string LastSelectedKeyValue => LastSelectedKey.Value;
        private string LastSelectedComment => LastSelectedKey.Comment;

        private int LastSelectedGroupIndex;
        private int LastSelectedItemIndex;

        private SearchPattern SearchPattern;
        public Main()
        {
            this.DoubleBuffered = true;

            InitializeComponent();            
        }

        #region ListviewFunctions                
        private void UpdateLastSelectedItem()
        {          
            LastSelectedGroupIndex = GetGroupIndex(listView1.SelectedItems[0].Group.Header);
            LastSelectedItemIndex = listView1.SelectedIndices[0];
            LastSelectedKey = ItemCopy[LastSelectedItemIndex];
        }
        private int GetGroupIndex(string GroupName)
            => Ini.Groups.FindIndex(x => x.Name == GroupName);
        private void AddKeyToIni(string Name, string Value, string Comment, string GroupName)
        {
            IniKey Key = new IniKey(Name, Value, Comment);
            int GroupIndex = GetGroupIndex(GroupName);
            Ini.Groups[GroupIndex].Keys.Add(Key);
            listView1.Items.Add(new ListViewItem(new[] { Name, Value }, listView1.Groups[GroupIndex]));
            ItemCopy.Add(Key);
        }
        private void AddNewKey()
        {
            NewForm NewForm = new NewForm(Ini.Groups);
            NewForm.ShowDialog();
            if (!NewForm.Cancelled)
            {
                AddKeyToIni(NewForm.KeyName, NewForm.KeyValue, NewForm.Comment, NewForm.GroupName);
                listView1.Items[listView1.Items.Count - 1].BackColor = Green;
            }
            SaveFileUpdated = false;
        }
        private void EditSelectedKey()
        {
            EditForm EditForm = new EditForm(LastSelectedKeyName, LastSelectedKeyValue, LastSelectedComment);
            EditForm.ShowDialog();
            if (!EditForm.Cancelled)
            {
                listView1.SelectedItems[0].BackColor = Yellow;
                string NewName = EditForm.KeyName;
                string NewValue = EditForm.KeyValue;
                string NewComment = EditForm.Comment;
                IniKey Key = new IniKey(NewName, NewValue, NewComment);
                Ini.Groups[LastSelectedGroupIndex].Keys.Remove(ItemCopy[LastSelectedItemIndex]);
                Ini.Groups[LastSelectedGroupIndex].Keys.Add(Key);
                listView1.SelectedItems[0].SubItems[0].Text = NewName;
                listView1.SelectedItems[0].SubItems[1].Text = NewValue;
                listView1.SelectedItems[0].SubItems[2].Text = NewComment;                
                UpdateLastSelectedItem();
                ItemCopy[LastSelectedItemIndex] = Key;
            }
            SaveFileUpdated = false;
        }
        private void RemoveSelectedKey()
        {
            Ini.Groups[LastSelectedGroupIndex].Keys.Remove(LastSelectedKey);
            listView1.SelectedItems[0].Remove();
            if (Ini.Groups[LastSelectedGroupIndex].Keys.Count == 0)
                Ini.Groups.Remove(Ini.Groups[LastSelectedGroupIndex]);
            ItemCopy.RemoveAt(LastSelectedItemIndex);
            SaveFileUpdated = false;
        }     
        private void AddNewGroup()
        {
            NewForm NewForm = new NewForm(Ini.Groups, true);
            NewForm.ShowDialog();
            if (!NewForm.Cancelled)
            {
                IniGroup NewGroup = new IniGroup();
                NewGroup.Name = NewForm.GroupName;
                NewGroup.Keys = new List<IniKey>();
                Ini.Groups.Add(NewGroup);
                listView1.Groups.Add(new ListViewGroup(NewGroup.Name));
                AddKeyToIni(NewForm.KeyName, NewForm.KeyValue, NewForm.Comment, NewForm.GroupName);
                listView1.Items[listView1.Items.Count - 1].BackColor = Green;              
            }
            SaveFileUpdated = false;
        }
        private void EditSelectedGroup()
        {
            EditForm EditForm = new EditForm(Ini.Groups[LastSelectedGroupIndex].Name, "", "", true);
            EditForm.ShowDialog();
            if (!EditForm.Cancelled)
            {
                Ini.Groups[LastSelectedGroupIndex].Name = EditForm.KeyName;
                listView1.Groups[LastSelectedGroupIndex].Name = EditForm.KeyName;
                listView1.Groups[LastSelectedGroupIndex].Header = EditForm.KeyName;                
            }
            SaveFileUpdated = false;
        }
        private void DeleteSelectedGroup()
        {
            if (LastSelectedGroupIndex != -1)
            {
                listView1.BeginUpdate();
                List<ListViewItem> ToRemove = new List<ListViewItem>();
                foreach (ListViewItem Item in listView1.Groups[LastSelectedGroupIndex].Items)
                    ToRemove.Add(Item);
                foreach (ListViewItem Item in ToRemove)
                    listView1.Items.Remove(Item);
                listView1.Groups.RemoveAt(LastSelectedGroupIndex);
                Ini.Groups.RemoveAt(LastSelectedGroupIndex);
                listView1.EndUpdate();
            }
            SaveFileUpdated = false;
        }
        private void LoadIniToListView()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            ItemCopy = new List<IniKey>();
            for (int i = 0; i < Ini.Groups.Count; ++i)
            {
                ListViewGroup Group = new ListViewGroup(Ini.Groups[i].Name);
                listView1.Groups.Add(Group);
                foreach (IniKey Key in Ini.Groups[i].Keys)
                {
                    listView1.Items.Add(new ListViewItem(new[] { Key.Name, Key.Value, Key.Comment }, Group));
                    ItemCopy.Add(Key);
                }
            }
            listView1.EndUpdate();
        }       
        #endregion

        #region ListviewEvents
        private void ListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool EnableButtons = listView1.SelectedItems.Count != 0;
            buttonEditE.Enabled = EnableButtons;
            buttonDeleteE.Enabled = EnableButtons;
            buttonEditG.Enabled = EnableButtons;
            buttonDelelteG.Enabled = EnableButtons;
            if (listView1.SelectedItems.Count != 0)
                UpdateLastSelectedItem();
        }
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                EditSelectedKey();
        }       
        #endregion
        
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
            SearchManager = new SearchManager(ref ItemCopy);
            buttonNewE.Enabled = true;
            buttonNewG.Enabled = true;
            buttonSearchNext.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            textBoxSearch.Enabled = true;
            comboBox1.Enabled = true;
            comboBox1.SelectedIndex = 0;
        }
        private void SaveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            IniIO.WriteIni(Ini);
            SaveFileUpdated = true;
        }
        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            IniIO.WriteAs(Ini, sfd.FileName);
            SaveFileUpdated = true;
        }
        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
           => this.Close();
        #endregion

        #region Buttons               
        private void buttonNewE_Click(object sender, System.EventArgs e)
            => AddNewKey();
        private void buttonEditE_Click(object sender, System.EventArgs e)
           => EditSelectedKey();
        private void buttonDeleteE_Click(object sender, System.EventArgs e)
            => RemoveSelectedKey();
        private void ButtonNewG_Click(object sender, System.EventArgs e)
            => AddNewGroup();      
        private void ButtonEditG_Click(object sender, System.EventArgs e)
            => EditSelectedGroup();
        private void ButtonDelelteG_Click(object sender, System.EventArgs e)
            => DeleteSelectedGroup();

        #endregion

        #region Search
        private void SelectItem(int SearchResultIndex) {
            if (SearchResultIndex != -1)
            {
                listView1.Select();
                listView1.Focus();
                listView1.Items[SearchResultIndex].Focused = true;
                listView1.Items[SearchResultIndex].Selected = true;
                listView1.Items[SearchResultIndex].EnsureVisible();
            }
        }
        private void Search()
        {
            int SearchResultIndex = -1;
            if (SearchManager.CanSearchLastString && SearchManager.LastSearchString == textBoxSearch.Text)
                SearchResultIndex = SearchManager.SearchIndexWithLastString(SearchPattern);
            else SearchResultIndex = SearchManager.SearchIndex(textBoxSearch.Text, SearchPattern);
            SelectItem(SearchResultIndex);
        }
        private void ButtonSearchNext_Click(object sender, System.EventArgs e)
            => Search();        
        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Search();
        }
        private void ListView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && SearchManager.CanSearchLastString)
                SelectItem(SearchManager.SearchIndexWithLastString(SearchPattern));
        }
        private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.Text == "Name")
                SearchPattern = SearchPattern.Name;
            else if (comboBox1.Text == "Value")
                SearchPattern = SearchPattern.Value;
            else SearchPattern = SearchPattern.Comment;
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!SaveFileUpdated)
            {
                DialogResult Result = MessageBox.Show("Ini file not updated with lastest changes, do you want to continue?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                e.Cancel = Result == DialogResult.Cancel;             
            }
        }
    }
}
