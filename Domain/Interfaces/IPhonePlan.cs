using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPhonePlan : IGeneric<PhonePlan>
    {
        Task<int> GetMinutesByPlan(string Name);
    }
}
