using System;
using System.IO;
using System.Net;
using System.Xml;

namespace RLCTelemetry.Utilities.Configuration
{
    class F12013Config2
    {
        public F12013Config2()
        {
            this.server = new IPAddress((new byte[] { 127, 0, 0, 1 }));
            this.configpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\My Games\FormulaOne2013\hardwaresettings\hardware_settings_config.xml";
            this.changed = false;
            this.safe = false;
        }

        public IPAddress Server { get { return this.server; } }
        private IPAddress server;

        private int port = 0;
        public int Port { get { return this.port; } }

        private string configpath;

        private bool changed;

        private bool safe;
        public bool Safe { get { return this.safe; } }

        public void ReadConfig()
        {
            Console.WriteLine("[config] Checking config file");

            XmlDocument configfile = new XmlDocument();
            
            if (File.Exists(this.configpath))
            {
                configfile.Load(this.configpath);

                XmlNode motion = configfile.SelectSingleNode("//motion");

                if (motion.Attributes["extradata"].Value != "3")
                {
                    motion.Attributes["extradata"].Value = "3";
                    Console.WriteLine("[config] Changing extradata");
                    this.changed = true;
                }

                if (motion.Attributes["enabled"].Value != "true")
                {
                    motion.Attributes["enabled"].Value = "true";
                    Console.WriteLine("[config] Changing enabled");
                    this.changed = true;
                }

                int.TryParse(motion.Attributes["port"].Value, out this.port);



                if (this.changed == true) configfile.Save(this.configpath);
                this.safe = true;
                this.changed = false;
            }
            else
            {
                // Config file not found. Seek emergency help.
            }


        }

        public void EditPort(int port)
        {
            Console.WriteLine("[config] Changing port");

             XmlDocument configfile = new XmlDocument();

             if (File.Exists(this.configpath))
             {
                 configfile.Load(this.configpath);

                 XmlNode motion = configfile.SelectSingleNode("//motion");

                 motion.Attributes["port"].Value = port.ToString();

                 configfile.Save(this.configpath);
             }
             else
             {
                 // No config file. Such error.
             }
        }

    }
}
