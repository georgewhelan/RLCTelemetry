using System;
namespace RLCTelemetry.Utilities
{
    public static class TimeFormatter
    {
        private static TimeSpan ts;

        public static string FormatFloat(float time)
        {
            TimeFormatter.ts = TimeSpan.FromSeconds((double)time);

            string answer = string.Format("{1:D2}:{2:D2}.{3:D3}",
                ts.Minutes,
                ts.Seconds,
                ts.Milliseconds);

            return answer;
        }


    }
}
