// -----------------------------------------------------------------------
// <copyright file="TopSpeed.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Stream.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class TopSpeed
    {
        private float speed = 0;

        public void Parse(float newspeed)
        {
            if (this.speed < newspeed)
            {
                this.speed = newspeed;
            }
        }

        public int ToInt()
        {
            // So hacky.
            return (int)this.speed;
        }
    }
}
