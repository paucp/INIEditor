using System.IO;

namespace INIEditor
{
    public class IniIO
    {
        private string Path;
        public IniIO(string Path)
        {
            this.Path = Path;
        }
        public Ini ReadIni()
           => new Ini(File.ReadAllLines(Path));
        public void WriteIni(Ini Ini)
            => File.WriteAllText(Path, Ini.GetIniText());
        public void WriteAs(Ini Ini, string Path)
            => File.WriteAllText(Path, Ini.GetIniText());
    }
}
