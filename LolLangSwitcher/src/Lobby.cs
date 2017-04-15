using System.IO;

namespace LolLangSwitcher
{
    class Lobby
    {
        protected const string AIR_PATH = "\\GameData\\Apps\\LoLTW\\Air\\";
        protected const string CSS_PATH = "\\GameData\\Apps\\LoLTW\\Air\\css\\";
        protected const string LOCALE_FILE = "locale.properties";

        protected LolClient lolClient;

        public virtual string locale_text { get; protected set; }

        public Lobby(LolClient lolClient)
        {
            this.lolClient = lolClient;
            ChangeLocale();
            ChangeFont();
        }

        protected void ChangeLocale()
        {
            string localeFile = this.lolClient.ClientPath() + AIR_PATH + LOCALE_FILE;
            var lines = File.ReadAllLines(localeFile);
            for (int t = 0; t < lines.Length; t++)
            {
                if (lines[t].Contains("locale="))
                {
                    lines[t] = this.locale_text;
                }
            }
            File.SetAttributes(localeFile, File.GetAttributes(localeFile) & ~FileAttributes.ReadOnly);
            File.WriteAllLines(localeFile, lines);
            File.SetAttributes(localeFile, File.GetAttributes(localeFile) | FileAttributes.ReadOnly);
        }

        protected void ChangeFont()
        {
            string cssPath = this.lolClient.ClientPath() + CSS_PATH;
            if (!File.Exists(cssPath + "fonts.swf.lok_bak"))
            {
                File.Move(cssPath + "fonts.swf", cssPath + "fonts.swf.lok_bak");
                File.Copy(cssPath + "fonts_zh_TW.swf", cssPath + "fonts.swf");
            }
        }

    }
}
