using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryPhonePlan : RepositoryGenerics<PhonePlan>, IPhonePlan
    {

        public RepositoryPhonePlan()
        {
            
        }

        public async Task<int> GetMinutesByPlan(string Name)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var result = data.Set<PhonePlan>()
                        .Where(d => d.Name == Name).ToList();

                if (result != null)
                    return result.Select(s => s.Minute)
                        .FirstOrDefault();
                
                return 0;
            }
        }

    }
}
