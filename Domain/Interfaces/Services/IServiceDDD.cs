using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceDDD
    {
        Task AddDDD(DDD ddd);
        Task UpdateDDD(DDD ddd);
    }
}
