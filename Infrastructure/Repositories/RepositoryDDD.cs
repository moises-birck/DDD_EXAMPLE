using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryDDD : RepositoryGenerics<DDD>, IDDD
    {

        public async Task<decimal> GetEntityByPricePerMinute(int origin, int destiny)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var result = data.Set<DDD>()
                                .Where(d => d.Origin == origin && d.Destiny == destiny)
                                .ToList();

                if (result != null)
                    return result.Select(s => s.PricePerMinute).FirstOrDefault();
                           
                return 0;

            }
        }
    }
}
