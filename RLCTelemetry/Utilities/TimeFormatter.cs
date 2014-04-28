using System;
namespace RLCTelemetry.Utilities
{
    class TimeFormatter
    {

        public static string FormatFloat(float time)
        {
            //return TimeSpan.FromMilliseconds((double)time).TotalMinutes;
            double dt = time;



            TimeSpan t = TimeSpan.FromSeconds(dt);

            //string answer = string.Format("{1:D2}m:{2:D2}s:{3:D3}ms",
            //    t.Minutes,
            //    t.Seconds,
            //    t.Milliseconds);

            string answer = t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;

            //string answer = t.Minutes.ToString();

            return answer;
        }


    }
}
