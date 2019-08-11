using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace INIEditor
{
    public enum SearchPattern
    {
        Name, 
        Value, 
        Comment
    }
    public class SearchManager
    {      
        public bool CanSearchLastString =>
            LastSearchString != null;
        public string LastSearchString { get; set; }

        private List<IniKey> Entries;
        private int ElapsedTime = 0;
        private int LastSearchIndex = -1;       

        public SearchManager(ref List<IniKey> entries)
        {
            Entries = entries;           
            Task.Run(() => AutoResetSearch());
        }

        public int SearchIndexWithLastString(SearchPattern SearchPattern)
            => SearchIndex(LastSearchString, SearchPattern);

        public int SearchIndex(string SearchText, SearchPattern SearchPattern)
        {
            if (SearchText == null)
                return -1;
            SearchText = SearchText.ToLower();
            if(SearchPattern == SearchPattern.Name) 
            LastSearchIndex = Entries.FindIndex
                (LastSearchIndex + 1, x => SearchText.Contains(x.Name.ToLower())
                || x.Name.ToLower().Contains(SearchText));
            else if(SearchPattern == SearchPattern.Value)
                LastSearchIndex = Entries.FindIndex
               (LastSearchIndex + 1, x => SearchText.Contains(x.Value.ToLower())
               || x.Value.ToLower().Contains(SearchText));
            else LastSearchIndex = Entries.FindIndex
               (LastSearchIndex + 1, x => x.Comment != "" && (SearchText.Contains(x.Comment.ToLower())
               || x.Comment.ToLower().Contains(SearchText)));
            ElapsedTime = 0;
            LastSearchString = SearchText;
            return LastSearchIndex;
        }

        private void AutoResetSearch()
        {
            while (true)
            {
                Thread.Sleep(100);
                ElapsedTime += 100;
                if (ElapsedTime == 4000
                    && LastSearchIndex != -1)
                {
                    LastSearchIndex = -1;
                    LastSearchString = null;
                }
            }
        }
    }
}
