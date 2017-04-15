using System.IO;

namespace LolLangSwitcher
{
    class Game
    {
        protected const string CFG_PATH = "\\GameData\\Apps\\LoLTW\\Game\\DATA\\CFG\\";
        protected const string CSS_PATH = "\\GameData\\Apps\\LoLTW\\Game\\DATA\\Menu\\";
        protected const string LOCALE_FILE = "Locale.cfg";
        protected const string FONT_CONFIG_FILE = "fontconfig_en_US.txt";
        protected const string FLAG = "lok_lol_lang_switcher - https://github.com/lok0613/lol-lang-switcher";

        protected LolClient lolClient;

        public virtual string locale_text { get; protected set; }

        public Game(LolClient lolClient)
        {
            this.lolClient = lolClient;
            ChangeLocale();
            //ChangeFont();
        }

        protected void ChangeLocale()
        {
            string localeFile = this.lolClient.ClientPath() + CFG_PATH + LOCALE_FILE;
            var lines = File.ReadAllLines(localeFile);
            for (int t = 0; t < lines.Length; t++)
            {
                if (lines[t].Contains("LanguageLocaleRegion="))
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
            string localeFile = this.lolClient.ClientPath() + CFG_PATH + FONT_CONFIG_FILE;
            var lines = File.ReadAllLines(localeFile);
            
            // save check
            if ( lines[0] == FLAG )
            {
                return;
            }



            File.WriteAllLines(localeFile, lines);
        }
    }
}
