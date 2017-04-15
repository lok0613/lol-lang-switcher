using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolLangSwitcher
{
    class ChineseLobby : Lobby
    {
        public override string locale_text { get { return "locale=zh_TW"; } }

        public ChineseLobby(LolClient lolClient) : base(lolClient)
        {

        }

    }
}
