using System.Collections.Generic;

namespace INIEditor
{
    public struct IniGroup
    {
        public string Name;
        public Dictionary<string, string> IniKeys;
    }    
    public class Ini
    {        
        private List<IniGroup> Groups;
        public Ini(string[] IniLines)
        {
            Groups = ParseIni(IniLines);
        }
        private List<IniGroup> ParseIni(string[] IniLines)
        {
            IniLines = RemoveInvalidLines(IniLines);
            List<IniGroup> IniGroups = new List<IniGroup>();
            int GroupStartLine = FindGroupLine(IniLines, 0);
            int GroupEndLine = FindGroupLine(IniLines, 1);

        }
        private IniGroup ParseGroup(string[] GroupText, int StartLine, int EndLine)
        {
            IniGroup Group;
            Group.IniKeys = new Dictionary<string, string>();

        }
        public string GetIniText()
        {
            return "";
        }
        
        int FindGroupLine(string[] Lines, int StartLine)
        {
            for (int i = StartLine; i < Lines.Length; ++i)
                if (Lines[i].StartsWith("[") && Lines[i].EndsWith("]"))
                    return i;
            return -1;
        }
        string[] RemoveInvalidLines(string[] Lines)
        {
            string[] FormattedLines = new string[Lines.Length];
            for (int i = 0; i < Lines.Length; ++i)
                if (!string.IsNullOrEmpty(Lines[i]) && !string.IsNullOrWhiteSpace(Lines[i])
                    && !Lines[i].StartsWith("#") && !Lines[i].StartsWith("//") && !Lines[i].StartsWith("*"))
                {
                    FormattedLines[i] = Lines[i];
                }
            return FormattedLines;
        }
    }
}
