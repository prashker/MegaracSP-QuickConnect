using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MegaracSP_QuickConnect
{
    class ServerManager
    {
        // Singleton :)
        private static ServerManager instance;

        public static ServerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerManager();
                }
                return instance;
            }
        }

        public List<Server> servers;
        private XmlSerializer settingsSerializer;

        private ServerManager() {
            servers = new List<Server>();
            settingsSerializer = new XmlSerializer(servers.GetType());
            loadFromSettings();
        }


        // Saving/Loading
        private void loadFromSettings()
        {
            if (Properties.Settings.Default.SerializedServers.Length != 0)
            {
                StringReader sr = new StringReader(Properties.Settings.Default.SerializedServers);
                servers = (List<Server>)settingsSerializer.Deserialize(sr);
            }
        }

        public void saveToSettings()
        {
            Console.WriteLine("ya");
            using (StringWriter textWriter = new StringWriter())
            {
                settingsSerializer.Serialize(textWriter, servers);
                Properties.Settings.Default.SerializedServers = textWriter.ToString();
                Properties.Settings.Default.Save();
            }
        }

        public void connectToServer(int id)
        {
            // Connect to servers[id]
        }

    }
}
