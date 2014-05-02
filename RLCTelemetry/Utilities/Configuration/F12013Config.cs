using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Linq;

namespace RLCTelemetry.Utilities.Configuration
{
    class F12013Config
    {
        // This class opens the config file for F1 2013, reads the server, port and extra data params. Edits the data params as appropriate, returns the server and port.

        public F12013Config()
        {
            this.Success = false;
        }

        public bool Success;

        private string server;
        public IPAddress Server 
        { 
            get 
            {
                // Hardcoded to localhost. It should always be that, in reality we shouldn't be letting the server be changed.
                return new IPAddress((new byte[] { 127, 0, 0, 1 }));
            }
        }

        private int port = 0;
        public int Port { get { return this.port; } }

        private string data = "";
        public string Data { get { return this.data; } }

        private string enabled = "";
        public bool Enabled { 
            get { 
                if (this.enabled == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //public void ReadConfig()
        //{
        //    Console.WriteLine("[config] Checking config file");
        //    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\FormulaOne2013\hardwaresettings\hardware_settings_config.xml";

        //    XmlDocument allData = new XmlDocument();
        //    allData.Load(path);

        //    if (allData != null)
        //    {
        //        IEnumerable<XElement> tasks = allData.Descendants("motion");
        //        foreach (XElement task in tasks)
        //        {
        //            this.data       = task.Attribute("extradata").Value;
        //            this.server     = task.Attribute("ip").Value;
        //            this.enabled    = task.Attribute("enabled").Value;
        //            int.TryParse(task.Attribute("port").Value, out this.port);
        //        }

        //        // Awful nested ifs... if you stick this on /r/shittyprogramming I hope you get lots of internet points.

        //        if (this.Enabled == true)
        //            // The motion is actually enabled.
        //        {
        //            if (this.data == "3")
        //                // Extra data enabled.
        //            {
        //                if (this.server != null && this.port != 0)
        //                    // We have a server and a port to work with.
        //                {
        //                    this.Success = true;
        //                    Console.WriteLine("[config] Config is fine to stream");
        //                }
        //            }
        //            else
        //            {
        //                // Make the extra data attribute 3.
        //                Console.WriteLine("[config] Changing extra data value to 3");
        //                this.Edit("extradata", "3");
        //                this.ReadConfig();
        //            }
        //        }
        //        else
        //        {
        //            // Config needs motion enabling.
        //            Console.WriteLine("[config] Changing motion value to true");
        //            this.Edit("motion", "true");

        //            // This might end up stuck in an endless loop if it can't write the file.
        //            this.ReadConfig();
        //        }

        //    }
        //}

        public void ReadConfig(string filepath)
        {
            // Do not use this method.


        }

        public void Edit(string node, string value)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\FormulaOne2013\hardwaresettings\hardware_settings_config.xml";

            XElement allData = XElement.Load(path);
            if (allData != null)
            {
                IEnumerable<XElement> tasks = allData.Descendants("motion");
                foreach (XElement task in tasks)
                {
                    task.Attribute(node).Value = value;
                }

                allData.Save(path);
                Console.WriteLine("[config] Saved config file");
            }

        }

    }
}
