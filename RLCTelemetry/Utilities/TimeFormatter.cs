using System;
namespace RLCTelemetry.Utilities
{
    class TimeFormatter
    {

        public static string FormatFloat(float time)
        {
            double dt = time;
            TimeSpan t = TimeSpan.FromSeconds(dt);

            string answer = string.Format("{1:D2}:{2:D2}.{3:D3}",
                t.Minutes,
                t.Seconds,
                t.Milliseconds);

            return answer;
        }


    }
}
