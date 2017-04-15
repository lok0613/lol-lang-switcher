using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolLangSwitcher
{
    class EnglishGame : Game
    {
        public override string locale_text { get { return "LanguageLocaleRegion=EN_US"; } }

        public EnglishGame(LolClient lolClient) : base(lolClient)
        {

        }
    }
}
