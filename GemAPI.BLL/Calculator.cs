using GemAPI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GemAPI.BLL
{
    public class Calculator : ICalculator
    {

        private readonly ILogger<Calculator> _logger;
        public Calculator(ILogger<Calculator> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into Calculator");
        }
        public CandidatePlant[] OptimizeProduction(Payload payload)
        {
            var target = payload.Load;
            var results = new List<CandidatePlant>();
            var orderedListByCost = payload.Powerplants
                .OrderBy(p => p.ComputeCost(payload.Fuels))
                .ThenByDescending(p => p.GetRealPower(payload.Fuels))
                .ToArray();
            for (int i = 0; i < orderedListByCost.Length; i++)
            {
                var item = orderedListByCost[i];
                var realPower = item.GetRealPower(payload.Fuels);
                var remainder = target - realPower;

                if (remainder > 0)
                {
                    target -= realPower;
                    results.Add(new CandidatePlant
                    {
                        Name = item.Name,
                        Power = realPower
                    });

                }
                else
                {

                    var o = new CandidatePlant
                    {
                        Name = item.Name,
                        Power = target
                    };
                    results.Add(o);

                    if (target < item.PMin)
                    {
                        //ADJUST
                        var delta = item.PMin - target;
                        o.Power += delta;
                        //ADJUST PREVIOUS
                        var n = results.Count-2;
                        var previous = results[n];
                        previous.Power -= delta;
                    }
                    
                    break;
                }
            }
            
            //var orderByPower = orderedListByCost;
            _logger.LogInformation(2, "OPT Results {@results}", results);
            return results.ToArray();
        }

        
    }
}
