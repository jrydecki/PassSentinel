using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace PassSentinel
{
    internal class VaultItem
    {
        public Int64 ID {  get; set; }
        public string Name { get; set; }
        public byte[] URL { get; set; }
        public byte[] IV { get; set; }
        public byte[] Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Notes { get; set; }

        public bool Encrypted { get; set; }

        public VaultItem() {
            this.ID = -1;
            this.Encrypted = false;
            this.IV = Security.GenerateIV();
            this.Notes = new byte[0];
        }

        public VaultItem(SqliteDataReader reader)
        {
            this.ID = (Int64) reader["id"];
            this.Encrypted = true;
            this.Name = (string) reader["name"];
            this.URL = (byte[]) reader["url"];
            this.IV = (byte[]) reader["iv"];
            this.Username = (byte[]) reader["username"];
            this.Password = (byte[]) reader["password"];
            this.Notes = (byte[])reader["notes"];
            
        }

        public VaultItem(CSV.LastPassItem item)
        {
            this.ID = -1;
            this.Encrypted = false;
            this.IV = Security.GenerateIV();
            this.Name = item.name;
            this.URL = Util.Encode(item.url);
            this.Username = Util.Encode(item.username);
            this.Password = Util.Encode(item.password);
            this.Notes = Util.Encode(item.extra);

        } // end LastPassItem constructor

        public VaultItem(CSV.BitwardenItem item)
        {
            this.ID = -1;
            this.Encrypted = false;
            this.IV = Security.GenerateIV();
            this.Name = item.name;
            this.URL = Util.Encode(item.login_uri);
            this.Username = Util.Encode(item.login_username);
            this.Password = Util.Encode(item.login_password);
            this.Notes = Util.Encode(item.notes);
        } // end BitwardenItem constructor

        public VaultItem(CSV.OnePasswordItem item)
        {
            this.ID = -1;
            this.Encrypted = false;
            this.IV = Security.GenerateIV();
            this.Name = item.Title;
            this.URL = Util.Encode(item.Website);
            this.Username = Util.Encode(item.Username);
            this.Password = Util.Encode(item.Password);
            this.Notes = Util.Encode(item.Notes);

        } // end OnePasswordItem

        public VaultItem(CSV.PassSentinelItem item)
        {
            this.ID = -1;
            this.Encrypted = false;
            this.IV = Security.GenerateIV();
            this.Name = item.Name;
            this.URL = Util.Encode(item.URL);
            this.Username = Util.Encode(item.Username);
            this.Password = Util.Encode(item.Password);
            this.Notes = Util.Encode(item.Notes);
        }


    } // end class
} // end namespace
