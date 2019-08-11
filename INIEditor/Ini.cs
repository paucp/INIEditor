﻿using System.Collections.Generic;
using System.Text;

namespace INIEditor
{
    public class IniGroup
    {
        public string Name;
        public IDictionary<string, string> IniKeys;
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
            Group.IniKeys = new Dictionary<string, string>();
            Group.Name = GetGroupName(IniLines[StartLine]);
            for (int i = StartLine + 1; i < LastLine; ++i)
                Group.IniKeys.Add(GetLineKeyAndValue(IniLines[i]));
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
                foreach (KeyValuePair<string, string> Key in Groups[i].IniKeys)
                    IniText.AppendLine(Key.Key + "=" + Key.Value);
            }
            return IniText.ToString();
        }
    }
}
