using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace INIEditor
{
    public class SearchManager
    {
        public bool CanSearchLastString =>
            LastSearchString != null;
        public string LastSearchString { get; set; }

        private List<KeyValuePair<string, string>> Entries;
        private int ElapsedTime = 0;
        private int LastSearchIndex = -1;       

        public SearchManager(ref List<KeyValuePair<string,string>> entries)
        {
            Entries = entries;
            Task.Run(() => AutoResetSearch());
        }

        public int SearchIndexWithLastString()
            => SearchIndex(LastSearchString);

        public int SearchIndex(string SearchText)
        {
            if (SearchText == null)
                return -1;
            SearchText = SearchText.ToLower();
            LastSearchIndex = Entries.FindIndex
                (LastSearchIndex + 1, x => SearchText.Contains(x.Key.ToLower())
                || x.Key.ToLower().Contains(SearchText));
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
