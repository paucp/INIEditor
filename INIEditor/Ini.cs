using System.Collections.Generic;
using System.Text;

namespace INIEditor
{
    public class IniKey
    {
        public string Name;
        public string Value;
        public string Comment;

        public IniKey(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public IniKey(string Name, string Value, string Comment)
        {
            this.Name = Name;
            this.Value = Value;
            this.Comment = Comment;
        }
    }
    public class IniGroup
    {
        public string Name;
        public List<IniKey> Keys;
    }
    public class Ini
    {
        public List<IniGroup> Groups;
        public Ini(string[] IniLines)
        {
            Groups = ParseIni(IniLines);
        }
        private List<IniGroup> ParseIni(string[] IniLines)
        {
            IniLines = RemoveInvalidLines(IniLines);
            List<IniGroup> IniGroups = new List<IniGroup>();
            int GroupStartLine = 0;
            int GroupEndLine = FindGroupLine(IniLines, 1);
            while (GroupStartLine != -1)
            {
                IniGroups.Add(ParseGroup(IniLines, GroupStartLine, GroupEndLine));
                GroupStartLine = FindGroupLine(IniLines, GroupEndLine);
                GroupEndLine = FindGroupLine(IniLines, GroupStartLine + 1);
            }
            return IniGroups;
        }
        private IniGroup ParseGroup(string[] IniLines, int StartLine, int LastLine)
        {
            if (LastLine == -1) LastLine = IniLines.Length;
            IniGroup Group = new IniGroup();
            Group.Keys = new List<IniKey>();
            Group.Name = GetGroupName(IniLines[StartLine]);
            string Comment = "";
            for (int i = StartLine + 1; i < LastLine; ++i)
            {
                if (IniLines[i].StartsWith("#"))
                    Comment = IniLines[i].Substring(1, IniLines[i].Length-1);
                else
                {                    
                    KeyValuePair<string, string> Pair = GetLineKeyAndValue(IniLines[i]);                            
                    Group.Keys.Add(new IniKey(Pair.Key, Pair.Value, Comment));
                    if (Comment != "")
                        Comment = "";
                }                
            }
            return Group;
        }
        string GetGroupName(string Line)
           => Line.Substring(1, Line.IndexOf("]") - 1);
        KeyValuePair<string, string> GetLineKeyAndValue(string Line)
        {
            int SeparatorIndex = Line.IndexOf('=');
            string Name = Line.Substring(0, SeparatorIndex);
            string Value = Line.Substring(SeparatorIndex+1, Line.Length - SeparatorIndex - 1);
            return new KeyValuePair<string, string>(Name, Value);
        }
        int FindGroupLine(string[] Lines, int StartLine)
        {
            if (StartLine >= Lines.Length || StartLine < 0) return -1;
            for (int i = StartLine; i < Lines.Length; ++i) 
                if (Lines[i].StartsWith("[") && Lines[i].EndsWith("]"))
                    return i;
            return -1;
        }
        string[] RemoveInvalidLines(string[] Lines)
        {
            List<string> FormattedLines = new List<string>();
            for (int i = 0; i < Lines.Length; ++i)
                if (!string.IsNullOrEmpty(Lines[i]) && !string.IsNullOrWhiteSpace(Lines[i]))
                    FormattedLines.Add(RemoveWhiteSpaces(Lines[i]));
            return FormattedLines.ToArray();
        }
        string RemoveWhiteSpaces(string Line)
        {
            while (Line.EndsWith(" "))
                Line.Remove(Line.Length);
            return Line;
        }
        public string GetIniText()
        {
            StringBuilder IniText = new StringBuilder();
            for (int i = 0; i < Groups.Count; ++i)
            {
                IniText.AppendLine("[" + Groups[i].Name + "]");
                foreach (IniKey Key in Groups[i].Keys)
                {
                    if (Key.Comment != "") IniText.AppendLine("#" + Key.Comment);
                    IniText.AppendLine(Key.Name + "=" + Key.Value);
                }
            }
            return IniText.ToString();
        }
    }
}
