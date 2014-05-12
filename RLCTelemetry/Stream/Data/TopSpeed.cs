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
        public float Speed { get { return this.speed; } }

        private int lap = 0;
        public int Lap { get { return this.lap; } }

        public void Parse(float newspeed, int lap)
        {
            if (this.speed < newspeed)
            {
                this.speed = newspeed;
                this.lap = lap;
            }
        }

        public int ToInt()
        {
            return (int)this.speed;
        }

        public override string ToString()
        {
            return this.speed.ToString();
        }

        internal float ToFloat()
        {
            return this.speed;
        }
    }
}
