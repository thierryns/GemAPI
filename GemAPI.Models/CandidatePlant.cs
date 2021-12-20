using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GemAPI.Models
{

    /// <summary>
    /// for each powerplant how much power each powerplant should deliver. 
    /// The power produced by each powerplant has to be a multiple of 0.1 Mw 
    /// and the sum of the power produced by all the powerplants together should equal the load.
    /// </summary>
    public class CandidatePlant
    {
        public string Name { get; set; }

        /// <summary>
        /// multiple of 0.1 Mw 
        /// </summary>
        [JsonPropertyName("p")]
        public decimal Power { get; set; }

    }
}
