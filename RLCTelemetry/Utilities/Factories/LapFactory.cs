// -----------------------------------------------------------------------
// <copyright file="LapFactory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Utilities.Factories
{
    using System;
    using RLCTelemetry.Stream.Data;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class LapFactory
    {

        //public static LapFactory()
        //{
               
        //}

        public static Lap NewLap()
        {
            Lap lap = new Lap();
            return lap;
        }
    }
}
