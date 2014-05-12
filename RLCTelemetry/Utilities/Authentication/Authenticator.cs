using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RLCTelemetry.Utilities.Authentication
{
    class Authenticator
    {
        public string Key
        {
            get { return this.key; }
        }
        private string key;
        private string settingsPath;

        public Authenticator()
        {
        }

        public bool ReadKey()
        {
            // Loads the key out of config file.
            Console.WriteLine("[Auth] Reading auth token");
            this.settingsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\rlc.settings";

            XmlDocument settingsFile = new XmlDocument();
            settingsFile.Load(this.settingsPath);

            XmlNodeList nodes = settingsFile.GetElementsByTagName("Setting");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes["Name"].Value == "token")
                {
                    // Found the right setting. Continue.
                    this.key = nodes[i].FirstChild.InnerText;
                    Console.WriteLine("[Auth] Saved token to memory");
                    return true;
                }
            }

            Console.WriteLine("[Auth] No token found");
            return false;
        }

        public void WriteKey(string newkey, MainWindow parent)
        {
            Console.WriteLine("[Auth] Saving new auth token");

            this.settingsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\rlc.settings";

            XmlDocument settingsFile = new XmlDocument();
            settingsFile.Load(this.settingsPath);

            XmlNodeList nodes = settingsFile.GetElementsByTagName("Setting");
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes["Name"].Value == "token")
                {
                    // Found the right node. Continue.
                    nodes[i].FirstChild.InnerXml = newkey;
                }
            }

            settingsFile.Save(this.settingsPath);
            Console.WriteLine("[Auth] Saved new token");
            // Writes the new key to the config file.
            // Needs to then this.GetDriverList();

        }

        public List<string> CheckKey(string key)
        {
            List<string> drivers = new List<string>();
            return drivers;
        }

        private HttpWebRequest webRequest;
        private XElement driversnode;
        private System.IO.Stream received;
        private List<string> driverslist = new List<string>();

        public void StartWebRequest()
        {
            Console.WriteLine("[Auth] Checking key against server");
            
            this.webRequest.BeginGetResponse(new AsyncCallback(this.FinishWebRequest), null);
            Console.WriteLine("This should appear straight away after checking key.");
        }

        public void FinishWebRequest(IAsyncResult result)
        {
            Console.WriteLine("[Auth] Response from server received");

            Console.WriteLine(result.CompletedSynchronously);

            //WebResponse response = webRequest.EndGetResponse(result);
            //Console.WriteLine("Got a response");


            //this.received = response.GetResponseStream();
            //StreamReader readStream = new StreamReader(this.received);

            //Console.WriteLine(readStream.ReadToEnd());

            //this.driversnode = XElement.Parse(readStream.ReadToEnd());
            //if (driversnode != null)
            //{
            //    IEnumerable<XElement> drivers = driversnode.Descendants("drivers");
            //    foreach (XElement driver in drivers)
            //    {
            //        this.driverslist.Add(driver.Value);
            //    }
            //}
            //else
            //{
            //    // Server timeout.
            //    Console.WriteLine("[Auth] No driver list returned");
            //}

            //if (this.driverslist.Count > 1)
            //{
            //    // More than 1 driver found
            //    this.parent.UpdateDriverLabel(this.driverslist[0].ToString());
                   
            //}
            //else
            //{
            //    // No auth token.
            //    this.parent.UpdateAnonDriverLabel();
            //}

        }

        public List<string> GetDriverList()
        {
            //this.webRequest = (HttpWebRequest)WebRequest.Create("https://racingleaguecharts.com/drivers.xml?token=" + this.key);
            //this.StartWebRequest();

            this.driversnode = XElement.Load("https://racingleaguecharts.com/drivers.xml?token=" + this.key);
            if (driversnode != null)
            {
                IEnumerable<XElement> drivers = driversnode.Descendants("drivers");
                foreach (XElement driver in drivers)
                {
                    this.driverslist.Add(driver.Value);
                }
            }
            else
            {
                // Server timeout.
                Console.WriteLine("[Auth] No driver list returned");
            }

            return this.driverslist;



        }

    }
}
