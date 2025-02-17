using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{

    internal class PassSentinelItem
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

        public PassSentinelItem(string Name, string URL, string Username, string Password, string Notes)
        {
            this.Name = Name;
            this.URL = URL;
            this.Username = Username;
            this.Password = Password;
            this.Notes = Notes;
        }
    } // end PassSentinelItem

    internal class OnePasswordItem
    {
        public string Title { get; set; }
        public string Website { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Notes { get; set; }

    } // end OnePasswordItem Class

    internal class LastPassItem
    {
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string totp { get; set; }
        public string extra { get; set; }
        public string name { get; set; }
        public string grouping { get; set; }
        public string fav { get; set; }

    }  // end LastPassItem Class

    internal class BitwardenItem
    {
        public string folder { get; set; }
        public string favorite { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string fields { get; set; }
        public string reprompt { get; set; }
        public string login_uri { get; set; }
        public string login_username { get; set; }
        public string login_password { get; set; }
        public string login_totp { get; set; }
    }


} // end CSV namespace
