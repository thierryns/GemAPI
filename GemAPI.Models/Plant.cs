using System;



namespace GemAPI.Models
{
    public class Plant
    {
        public string Name { get; set; }

        /// <summary>
        /// gasfired, turbojet or windturbine.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// the efficiency at which they convert a MWh of fuel into a MWh of electrical energy. Wind-turbines do not consume 'fuel' and thus are considered to generate power at zero price.
        /// </summary>
        public decimal Efficiency { get; set; }

        /// <summary>
        /// the minimum amount of power the powerplant generates when switched on.
        /// </summary>
        public decimal PMin { get; set; }

        /// <summary>
        /// the maximum amount of power the powerplant can generate.
        /// </summary>
        public decimal PMax { get; set; }
    }
}
