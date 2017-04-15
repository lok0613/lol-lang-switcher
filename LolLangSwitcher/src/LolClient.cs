using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolLangSwitcher
{
    public class LolClient
    {
        protected const string DEFAULT_LOL_CLIENT_LOCATION = "C:\\Program Files (x86)\\GarenaLoLTW\\LoLTWLauncher.exe";

        protected string clientPath = DEFAULT_LOL_CLIENT_LOCATION;

        public LolClient()
        {

        }

        public bool IsLolClientExist()
        {
            return System.IO.File.Exists(clientPath);
        }

        public string ClientLocation
        {
            get { return this.clientPath; }
            set { this.clientPath = value; }
        }

        public string ClientPath()
        {
            return new System.IO.FileInfo(this.clientPath).Directory.FullName;
        }

    }
}
