using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolLangSwitcher
{
    class ChineseGame : Game
    {
        public override string locale_text { get { return "LanguageLocaleRegion=ZH_TW"; } }

        public ChineseGame(LolClient lolClient) : base(lolClient)
        {

        }
    }
}
