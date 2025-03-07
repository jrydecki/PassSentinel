using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace PassSentinel
{
    public class DBDefaultsObj
    {
        public int inactivity_len { get; set; }
        public int password_gen_len { get; set; }
        public bool gen_symbols { get; set; }
        public bool search_username { get; set; }
        public bool search_notes { get; set; }
        public bool search_url { get; set; }

        public bool view_username { get; set; }
        public bool view_url { get; set; }
    }

    public class ConfigObj
    {
        public string db_path { get; set; }
        public int min_pass_length { get; set; }
        public DBDefaultsObj db_defaults { get; set; }
    }

    
    public static class Config
    {
        private static ConfigObj config { get; set; }

        public static object Get(string key)
        { 

            var type = config.GetType();
            var property = type.GetProperty(key);

            if ( property == null)
            {
                throw new ArgumentException($"Property '{key}' not found on type '{type.Name}'.");
            }

            return property.GetValue(config);

        } // end Get

        public static object GetDBDefault(string key)
        {
            var type = config.db_defaults.GetType();
            var property = type.GetProperty(key);

            if (property == null)
            {
                throw new ArgumentException($"Property '{key}' not found on type '{type.Name}'.");
            }

            return property.GetValue(config.db_defaults);
        } // end GetDBDefault


        private static void CreateProgramDataFolder()
        {
            string progData_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PassSentinel");

            if (!Directory.Exists(progData_path))
            {
                Directory.CreateDirectory(progData_path);
            }


        } // end CreateProgramDataFolder

        public static void ReadConfig()
        {
            string filePath = "config.json";

            if (!File.Exists(filePath))
            {
                Globals.ErrorOut($"ERROR: Could not find configuration file '{filePath}'. If issue persists, reinstall application.");
            }

            string jsonContent = File.ReadAllText(filePath);


            config = JsonSerializer.Deserialize<ConfigObj>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            });

            // Put the database in %PROGRAMDATA%
            CreateProgramDataFolder(); 
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PassSentinel", (string)Get("db_path"));
            config.db_path = dbPath;

        } // end ReadConfig


    } // end class

} // end namespace
