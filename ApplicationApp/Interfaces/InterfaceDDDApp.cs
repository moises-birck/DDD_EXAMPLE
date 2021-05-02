using Entities.Entities;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceDDDApp : InterfaceGenericaApp<DDD>
    {
        Task AddDDD(DDD ddd);
        Task UpdateDDD(DDD dddd);
    }
}
