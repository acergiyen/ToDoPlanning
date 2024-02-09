using YamlDotNet.Serialization;

namespace ToDoPlanning.Console.Config
{
    public class Config
    {
        public Application application { get; set; }
        public Database database { get; set; }

        public static Config LoadConfig(string configFilePath)
        {
            string yamlContent = File.ReadAllText(configFilePath);
            var deserializer = new DeserializerBuilder().Build();
            var config = deserializer.Deserialize<Config>(yamlContent);
            return config;
        }
    }

    public class Application
    {
        public string name { get; set; }
        public string environment { get; set; }
        public List<string> providers { get; set; }
        
    }

    public class Database
    {
        public string connectionString { get; set; }

    }
}
