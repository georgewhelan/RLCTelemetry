namespace RLCTelemetry.Settings.Localisation
{
    class Localisation
    {
        // This class converts base units into the user's chosen units.

        public static float ToMPH(float basespeed)
        {
            float newspeed = basespeed * 2.236f;
            return newspeed;
        
        }

        public static float ToKPH(float basespeed)
        {
            float newspeed = basespeed * 3.6f;
            return newspeed;
        }
    }
}
