// -----------------------------------------------------------------------
// <copyright file="WebsiteStream.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.Http
{
    using RLCTelemetry.Stream.Data;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;
    using WebAPI;

    /// <summary>
    /// TODO: This class is a bit derp at the minute.
    /// </summary>
    public class WebsiteStream
    {
        public WebsiteStream()
        {
        }

        public int NewSession(string driver, string tracklength, string sessiontype, string race, string token)
        {
            string uri = "https://racingleaguecharts.com/sessions/register.xml?driver=" + driver + "&track=" + tracklength + "&type=" + sessiontype + "&race=" + race + "&token=" + token;
            //170.0 is q, 10.0 is tt, race is anything else.

            WebAPI.Http http = new WebAPI.Http(uri);
            http.HTTPMethod = Http.Method.POST;
            http.Go();
            if (http.StatusCode == 200)
            {
                Console.WriteLine(http.Response);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(http.Response);

                if (doc.HasChildNodes)
                {
                    XmlNode node = doc.SelectSingleNode(".//session-id");
                    int result;
                    int.TryParse(node.InnerXml, out result);
                    return result;
                }
            }
            
            return 0;
        }

        public bool SubmitLap(Lap lap, int sessionid)
        {
            string url = "https://racingleaguecharts.com/laps.xml?";

            string param
                = "session_id=" + sessionid
                + "&lap_number=" + lap.LapNumber
                + "&sector_1=" + lap.Sector1
                + "&sector_2=" + lap.Sector2
                + "&total=" + lap.LapTime.ToString("n3")
                + "&speed=" + lap.TopSpeed
                + "&fuel=" + lap.FuelRemaining
                + "&position=" + lap.RacePosition;

            Console.WriteLine(url + param);

            Http web = new Http(url + param);
            web.HTTPMethod = Http.Method.POST;
            web.Go();
            if (web.StatusCode == 200)
            {
                Console.WriteLine(web.Response);
                return true;
            }
            else
            {
                return false;
                // TODO: Save the lap for later submission.
            }


            
        }
    }
}
