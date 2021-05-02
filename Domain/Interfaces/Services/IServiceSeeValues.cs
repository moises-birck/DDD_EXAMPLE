using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Entities.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceSeeValues
    {
        Task<SeeValuesResponse> CalculateValues(SeeValuesRequest values);

        Task<List<Notifies>> ValidateSeeValues(SeeValuesRequest values);


    }
}
