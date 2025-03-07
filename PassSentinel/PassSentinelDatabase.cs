using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PassSentinel
{
    public class PassSentinelDatabase
    {
        public string connectionString { get; set; }

        public PassSentinelDatabase()
        {
            string filename = (string) Config.Get("db_path"); ;
            this.connectionString = $"Data Source={filename}";
            Initialize();
        } // end constructor


        public void Initialize()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        CREATE TABLE IF NOT EXISTS User (
                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            user_id INT,
                            username TEXT,
                            salt BLOB,
                            hash_salt BLOB,
                            hash BLOB,
                            pass_len INT,
                            gen_symbols INT,
                            search_username INT,
                            search_notes INT,
                            search_url INT,
                            inactivity_len INT,
                            view_username INT,
                            view_url INT
                        );
                        CREATE TABLE IF NOT EXISTS VaultItems (
                            id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            user_id INT,
                            name TEXT,
                            url BLOB,
                            iv BLOB,
                            username BLOB,
                            password BLOB,
                            notes BLOB
                        );
                    ";
                command.ExecuteNonQuery();

            }
        } // end Initialize

        public void CreateUser(string username, byte[] masterSalt, byte[] hashSalt, byte[] masterHash)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        INSERT INTO User (username, salt, hash_salt, hash, pass_len, gen_symbols, search_username, search_notes, search_url, inactivity_len, view_username, view_url) 
                        VALUES (@username, @salt, @hashSalt, @hash, @pass_len, @gen_symbols, @search_username, @search_notes, @search_url, @inactivity_len, @view_username, @view_url);
                    ";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@salt", masterSalt);
                command.Parameters.AddWithValue("@hashSalt", hashSalt);
                command.Parameters.AddWithValue("@hash", masterHash);
                command.Parameters.AddWithValue("@pass_len", (int)Config.GetDBDefault("password_gen_len"));
                command.Parameters.AddWithValue("@gen_symbols", Convert.ToInt32((bool)Config.GetDBDefault("gen_symbols")));
                command.Parameters.AddWithValue("@search_username", Convert.ToInt32((bool)Config.GetDBDefault("search_username")));
                command.Parameters.AddWithValue("@search_notes", Convert.ToInt32((bool)Config.GetDBDefault("search_notes")));
                command.Parameters.AddWithValue("@search_url", Convert.ToInt32((bool)Config.GetDBDefault("search_url")));
                command.Parameters.AddWithValue("@inactivity_len", (int)Config.GetDBDefault("inactivity_len"));
                command.Parameters.AddWithValue("@view_username", Convert.ToInt32((bool)Config.GetDBDefault("view_username")));
                command.Parameters.AddWithValue("@view_url", Convert.ToInt32((bool)Config.GetDBDefault("view_url")));
                command.ExecuteNonQuery();

            } // end connection 'using'

        } // end CreateUser

        public void DeleteUser(Int64 userID)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        DELETE FROM User
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@id", userID);
                command.ExecuteNonQuery();

            } // end connection 'using'
        } // end DeleteUser


        /*
        Returns an array of byte arrays. The first is the salt, the second is the hash
        */
        public byte[][] GetPasswordHash(string username)
        {
            byte[] salt = null;
            byte[] hash = null;

            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT hash_salt, hash
                        FROM User
                        WHERE username = @username;
                    ";
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        salt = (byte[])reader["hash_salt"];
                        hash = (byte[])reader["hash"];
                    }

                } // end reader 'using'

            } // end connection 'using'

            byte[][] output = new byte[2][];
            output[0] = salt;
            output[1] = hash;

            return output;

        } // end GetPasswordHash


        public byte[][] GetPasswordHash(Int64 userID)
        {
            byte[] salt = null;
            byte[] hash = null;

            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT hash_salt, hash
                        FROM User
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@id", userID);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        salt = (byte[])reader["hash_salt"];
                        hash = (byte[])reader["hash"];
                    }

                } // end reader 'using'

            } // end connection 'using'

            byte[][] output = new byte[2][];
            output[0] = salt;
            output[1] = hash;

            return output;

        } // end GetPasswordHash



        public byte[] GetMasterSalt(string username)
        {

            byte[] masterSalt;

            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT salt FROM User WHERE username = @username;
                    ";
                
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        masterSalt = (byte[])reader["salt"];

                    else
                    {
                        masterSalt = null;
                    }
                    
                } // end reader 'using'

            } // end connection 'using'

                return masterSalt;
        } // end GetMasterIV

        public bool UserExists(string username)
        {
            if (username == "" || username == null)
                return false;
            
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT username
                        FROM User
                        WHERE username = @username;
                    ";
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        return true;
                }
            } // end connection 'using'

            return false;

        } // end UserExists

        public void UpdateUserPassword(Int64 userID, byte[] masterSalt, byte[] hashSalt, byte[] masterHash)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        UPDATE User
                        SET salt = @salt, hash_salt = @hash_salt, hash = @hash
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@salt", masterSalt);
                command.Parameters.AddWithValue("@hash_salt", hashSalt);
                command.Parameters.AddWithValue("@hash", masterHash);
                command.Parameters.AddWithValue("@id", userID);
                command.ExecuteNonQuery();

            } // end connection 'using'

        } // end UpdateUserPassword


        public Int64 GetUserID(string username)
        {
            Int64 id = -1;
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT id
                        FROM User
                        WHERE username = @username;
                    ";
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        id = (Int64)reader["id"];
                }
            }
            return id;
        } // end GetUserID

        public string GetUsername(Int64 userID)
        {
            string username = null;
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT username
                        FROM User
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@id", userID);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        username = (String) reader["username"];
                }
            }
            return username;
        } // end GetUsername

        public int GetRandomPasswordLength()
        {
            int length = 30;
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        SELECT pass_len 
                        FROM User
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@id", Globals.UserID);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        length = Convert.ToInt32((Int64)reader["pass_len"]);
                } // end reader 'using'

            } // end connection 'using'
            return length;
        } // end GetRandomPasswordLength

        public Dictionary<string, object> GetPreferences()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        SELECT pass_len, gen_symbols, search_username, search_notes, search_url, inactivity_len, view_username, view_url
                        FROM User
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@id", Globals.UserID);
                command.ExecuteNonQuery();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The Keys EXACTLY MATCH the Preferences Class Attributes
                        dict["RandomPasswordLength"] = Convert.ToInt32((Int64)reader["pass_len"]);
                        dict["GenerateSymbols"] = Convert.ToBoolean((Int64)reader["gen_symbols"]);
                        dict["SearchUsername"] = Convert.ToBoolean((Int64)reader["search_username"]);
                        dict["SearchNotes"] = Convert.ToBoolean((Int64)reader["search_notes"]);
                        dict["SearchURL"] = Convert.ToBoolean((Int64)reader["search_url"]);
                        dict["InactivityTimer"] = Convert.ToInt32((Int64)reader["inactivity_len"]);
                        dict["ViewUsername"] = Convert.ToBoolean((Int64)reader["view_username"]);
                        dict["ViewURL"] = Convert.ToBoolean((Int64)reader["view_url"]);

                    }
                } // end reader 'using'
            } // end connection 'using'
            return dict;
        } // end GetPreferences

        // Update Preferences based on an input dictionary
        public void UpdatePreferences(Dictionary<string, object> dict)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        UPDATE User
                        SET pass_len = @pass_len, gen_symbols = @gen_symbols, search_username = @username, search_notes = @notes, search_url = @url, inactivity_len = @inactivity_len, view_username = @view_username, view_url = @view_url
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@pass_len", (int)dict["RandomPasswordLength"]);
                command.Parameters.AddWithValue("@gen_symbols", Convert.ToInt32((bool)dict["GenerateSymbols"]));
                command.Parameters.AddWithValue("@username", Convert.ToInt32((bool)dict["SearchUsername"]));
                command.Parameters.AddWithValue("@notes", Convert.ToInt32((bool)dict["SearchNotes"]));
                command.Parameters.AddWithValue("@url", Convert.ToInt32((bool)dict["SearchURL"]));
                command.Parameters.AddWithValue("@id", Globals.UserID);
                command.Parameters.AddWithValue("@inactivity_len", (int)dict["InactivityTimer"]);
                command.Parameters.AddWithValue("@view_username", Convert.ToInt32((bool)dict["ViewUsername"]));
                command.Parameters.AddWithValue("@view_url", Convert.ToInt32((bool)dict["ViewURL"]));

                command.ExecuteNonQuery();

            } // end connection 'using'
        } // end UpdatePreferences


        // Update Preferences based on the Preferences static class
        public void UpdatePreferences()
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        UPDATE User
                        SET pass_len = @pass_len, gen_symbols = @gen_symbols, search_username = @username, search_notes = @notes, search_url = @url, inactivity_len = @inactivity_len, view_username = @view_username, view_url = @view_url
                        WHERE id = @id;
                    ";

                command.Parameters.AddWithValue("@pass_len", Preferences.RandomPasswordLength);
                command.Parameters.AddWithValue("@gen_symbols", Convert.ToInt32(Preferences.GenerateSymbols));
                command.Parameters.AddWithValue("@username", Convert.ToInt32(Preferences.SearchUsername));
                command.Parameters.AddWithValue("@notes", Convert.ToInt32(Preferences.SearchNotes));
                command.Parameters.AddWithValue("@url", Convert.ToInt32(Preferences.SearchURL));
                command.Parameters.AddWithValue("@id", Globals.UserID);
                command.Parameters.AddWithValue("@inactivity_len", Preferences.InactivityTimer);
                command.Parameters.AddWithValue("@view_username", Convert.ToInt32(Preferences.ViewUsername));
                command.Parameters.AddWithValue("@view_url", Convert.ToInt32(Preferences.ViewURL));

                command.ExecuteNonQuery();

            } // end connection 'using'
        } // end UpdatePreferences


        public void SetRandomPasswordLength(int length)
        {
            using (var connection = new SqliteConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                    @"
                        UPDATE User
                        SET pass_len = @length
                        WHERE id = @id;
                    ";
                command.Parameters.AddWithValue("@length", length);
                command.Parameters.AddWithValue("@id", Globals.UserID);
                command.ExecuteNonQuery();

            } // end connection 'using'

        } // end SetRandomPasswordLength



    } // end class
} // end namespace
