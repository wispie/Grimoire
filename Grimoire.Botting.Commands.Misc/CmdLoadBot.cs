using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grimoire.Botting.Commands.Misc
{
    public class CmdLoadBot : IBotCommand
    {
        public string BotFileName
        {
            get;
            set;
        }

        public string BotFilePath
        {
            get;
            set;
        }

        public async Task Execute(IBotEngine instance)
        {
            string name = BotFileName;
            string path = BotFilePath;
            if (File.Exists(path))
            {
                try
                {
                    string value;
                    using (TextReader reader = new StreamReader(path))
                    {
                        value = await reader.ReadToEndAsync();
                    }
                    Configuration configuration = JsonConvert.DeserializeObject<Configuration>(value, new JsonSerializerSettings
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore,
                        TypeNameHandling = TypeNameHandling.All
                    });
                    if (configuration != null && configuration.Commands.Count > 0)
                    {
                        instance.Configuration = configuration;
                        instance.Index = -1;
                        instance.LoadBankItems();
                        instance.LoadAllQuests();
                    }
                }
                catch
                {
                }
            }
        }

        public override string ToString()
        {
            return "Load bot: " + BotFileName;
        }
    }
}