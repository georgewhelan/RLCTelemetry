using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RLCTelemetry.Utilities.Authentication
{
    class Authenticator
    {
        private string key;

        public Authenticator()
        {
            // Hard coded a key in place for the time being. 
            this.key = "6e30879454462d1688dfe7fca98a36960ca2d418dbd9a7db87efad64d1898b94";
        }

        public bool ReadKey()
        {
            // Loads the key out of config file.
            Console.WriteLine("[Auth] Reading auth token");
            return true;
        }

        public void WriteKey(string newkey)
        {
            Console.WriteLine("[Auth] Saving new auth token");
            // Writes the new key to the config file.
        }

        public List<string> CheckKey(string key)
        {
            List<string> drivers = new List<string>();

            return drivers;

        }

        public List<string> GetDriverList()
        {
            Console.WriteLine("[Auth] Checking key against server");
            
            List<string> driverslist = new List<string>();


            var request = (HttpWebRequest)WebRequest.Create("https://racingleaguecharts.com/drivers.xml?token=" + this.key);
            request.Timeout = 5000; //Timeout after 5 seconds
            using (var stream = request.GetResponse().GetResponseStream())
            using (var reader = new StreamReader(stream))
            {

                XElement driversnode = XElement.Load("https://racingleaguecharts.com/drivers.xml?token=" + this.key);

                if (driversnode != null)
                {
                    Console.WriteLine("[Auth] Response from server received");

                    IEnumerable<XElement> drivers = driversnode.Descendants("drivers");
                    foreach (XElement driver in drivers)
                    {
                        driverslist.Add(driver.Value);
                    }

                    

                }
                else
                {
                    Console.WriteLine("[Auth] No driver list returned");
                    // Incorrect token or no assigned drivers.
                }

            }
            

            // Maybe not return the actual list here, it can totally be null if it times out.
            return driverslist;

        }

    }
}
