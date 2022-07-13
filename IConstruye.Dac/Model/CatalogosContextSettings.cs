using System;
namespace IConstruye.Dac.Model
{
    public class CatalogosContextSettings
    {
        public static string SettingName = "DatabaseSettings";
        public string ConnectionString { get; set; }
        public string DefaultSchema { get; set; }
    }
}

