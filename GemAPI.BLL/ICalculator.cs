using GemAPI.Models;

namespace GemAPI.BLL
{
    public interface ICalculator
    {
        CandidatePlant[] OptimizeProduction(Payload payload);
    }
}