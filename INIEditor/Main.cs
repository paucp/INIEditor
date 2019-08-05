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

        private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();
            IniIO = new IniIO(ofd.FileName);
            Ini = IniIO.ReadIni();
            LoadIniToListView();
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

        }
    }
}
