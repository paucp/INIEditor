using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

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
        private void AddKey(KeyValuePair<string, string> Key, int GroupIndex)
        {
            ListViewItem Item = new ListViewItem(new[] { Key.Key, Key.Value });
            listView1.Groups[GroupIndex].Items.Add(Item);
        }
        private void LoadIni()
        {
            for(int i = 0; i < Ini.Groups.Count; ++i)
            {
                ListViewGroup Group = new ListViewGroup(Ini.Groups[i].Name);
                listView1.Groups.Add(Group);
                foreach (KeyValuePair<string, string> Key in Ini.Groups[i].IniKeys)
                    AddKey(Key, i);              
            }
        }
    }
}
