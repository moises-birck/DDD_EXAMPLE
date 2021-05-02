using Domain.Interfaces;
using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDDD : IGeneric<DDD>
    {
        Task<decimal> GetEntityByPricePerMinute(int origin, int destiny);
    }
}
