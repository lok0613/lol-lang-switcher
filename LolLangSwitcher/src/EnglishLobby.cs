

namespace LolLangSwitcher
{
    class EnglishLobby : Lobby
    {
        public override string locale_text { get { return "locale=EN_US"; } }

        public EnglishLobby(LolClient lolClient) : base(lolClient)
        {
        }

    }
}
