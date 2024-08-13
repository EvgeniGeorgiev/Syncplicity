using Newtonsoft.Json;

public class ConfigurationSettings
{
    public class Config
    {
        public required string Browser { get; set; }
        public required string BaseUrl { get; set; }

    }

    public static Config GetConfig()
    {
        string json = System.IO.File.ReadAllText(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory() + "\\..\\..\\..\\config.json")));
        return JsonConvert.DeserializeObject<Config>(json);
    }

    public static string GetBaseUrl()
    {
        Config config = ConfigurationSettings.GetConfig();
        return config.BaseUrl;
    }

}