using Myfirstbot2.Properties;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Resources;
using System.Text;
using YamlDotNet.Serialization;

namespace uwu
{
    internal static class Config
    {
        internal static string token = "";

        public static void LoadConfig()
        {
            // Writes default config to file if it does not already exist
            if (!File.Exists("./config.yml"))
            {
                File.WriteAllText("./config.yml", Encoding.UTF8.GetString(Resources.default_config));
            }

            // Reads config contents into FileStream
            FileStream stream = File.OpenRead("./config.yml");

            // Converts the FileStream into a YAML object
            IDeserializer deserializer = new DeserializerBuilder().Build();
            object yamlObject = deserializer.Deserialize(new StreamReader(stream));

            // Converts the YAML object into a JSON object as the YAML ones do not support traversal or selection of nodes by name 
            ISerializer serializer = new SerializerBuilder().JsonCompatible().Build();
            JObject json = JObject.Parse(serializer.Serialize(yamlObject));

            // Sets up the bot
            token = json.SelectToken("bot.token").Value<string>() ?? "";
        }
    }
}