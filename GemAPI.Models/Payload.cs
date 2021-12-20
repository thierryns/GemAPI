using System;

using System.Collections.Generic;
using System.Text;

namespace GemAPI.Models
{
    public class Payload
    {
        public decimal Load { get; set; }
        public Dictionary<string,decimal> Fuels { get; set; }

        public ICollection<Plant> Powerplants { get; set; }

    }
}
