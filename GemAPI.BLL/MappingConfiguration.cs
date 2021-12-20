using GemAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GemAPI.BLL
{
    internal static class MappingConfiguration
    {

        internal static decimal ComputeCost(this Plant plant, IDictionary<string, decimal> fuels)
        {
            decimal cost = 1;
            switch (plant.Type)
            {
                case "gasfired":
                    
                    cost = fuels.First(r => r.Key.Contains("gas")).Value / plant.Efficiency;

                    break;
                case "turbojet":                    
                    cost = fuels.First(r => r.Key.Contains("kerosine")).Value / plant.Efficiency;
                    break;
                default:
                    break;
            }            
            return cost;
        }

        internal static decimal GetRealPower(this Plant plant, IDictionary<string, decimal> fuels)
        {
            decimal power = plant.PMax;
            switch (plant.Type)
            {
                case "windturbine":
                    var windEfficiency = fuels.First(r => r.Key.Contains("wind")).Value;
                    power = plant.PMax * windEfficiency/100m;
                    break;
                case "gasfired":                    
                    power = plant.PMax;
                    break;
                default:
                    break;
            }
            return power;
        }
    }
}
