using Entities.Entities;
using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Entities.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceSeeValuesApp 
    {
        Task<SeeValuesResponse> CalculateValues(SeeValuesRequest values);
        Task<List<Notifies>> ValidateSeeValues(SeeValuesRequest values);

    }
}
