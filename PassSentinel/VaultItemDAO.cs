using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PassSentinel
{
    internal class VaultItemDAO
    {
        public string connectionString { get; set; }

        public VaultItemDAO()
        {
            string filename = (string)Config.Get("db_path");
            this.connectionString = $"Data Source={filename}";

        } // end constructor


        public void Add(VaultItem item)
        {
            if (!item.Encrypted)
                throw new InvalidOperationException("Item must be encrypted to be inserted into database.");

            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        INSERT INTO VaultItems (user_id, name, url, iv, username, password, notes)
                        VALUES (@user_id, @name, @url, @iv, @username, @password, @notes);
                        SELECT last_insert_rowid();
                    ";
                command.Parameters.AddWithValue("@user_id", Globals.UserID);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@url", item.URL);
                command.Parameters.AddWithValue("@iv", item.IV);
                command.Parameters.AddWithValue("@username", item.Username);
                command.Parameters.AddWithValue("@password", item.Password);
                command.Parameters.AddWithValue("@notes", item.Notes);

                //command.ExecuteNonQuery();
                long newId = (long)command.ExecuteScalar();
                if (item.ID == -1)
                    item.ID = newId;

            }
        } // end Add

        public void Update(VaultItem item)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        UPDATE VaultItems 
                        SET name = @name, url = @url, iv = @iv, 
                            username = @username, password = @password, notes = @notes
                        WHERE id = @id
                    ";
                command.Parameters.AddWithValue("@id", item.ID);
                command.Parameters.AddWithValue("@name", item.Name);
                command.Parameters.AddWithValue("@url", item.URL);
                command.Parameters.AddWithValue("@iv", item.IV);
                command.Parameters.AddWithValue("@username", item.Username);
                command.Parameters.AddWithValue("@password", item.Password);
                command.Parameters.AddWithValue("@notes", item.Notes);
                command.ExecuteNonQuery();
            }
        } // end Update

        public void Delete(VaultItem item)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        DELETE FROM VaultItems 
                        WHERE id = @id
                    ";
                command.Parameters.AddWithValue("@id", item.ID);
                command.ExecuteNonQuery();
            }
        } // end Delete
        
        public VaultItem Get(int ID)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT id, name, url, iv, username, password, notes
                        FROM VaultItems
                        WHERE id = @id
                    ";
                command.Parameters.AddWithValue("@id", ID);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        VaultItem item = new VaultItem(reader);
                        return item;
                    }
                    else
                    {
                        return null;
                    }
                } // end reader 'using'
            } // end connection 'using'
        } // end Get

        public List<VaultItem> GetAll()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT id, name, url, iv, username, password, notes
                        FROM VaultItems
                        WHERE user_id = @user_id;
                    ";
                command.Parameters.AddWithValue("@user_id", Globals.UserID);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    List<VaultItem> VaultItems = new List<VaultItem>();
                    while (reader.Read())
                    {
                        VaultItems.Add(new VaultItem(reader));
                    }
                    return VaultItems;
                } // end reader 'using'
            } // end connection 'using'

        } // end GetAll


    } // end class

} // end namespace
