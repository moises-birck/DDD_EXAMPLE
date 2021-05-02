using ApplicationApp.Interfaces;
using Domain.Interfaces;
using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Entities.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Apps
{
    public class AppSeeValues : InterfaceSeeValuesApp
    {
        IServiceSeeValues _IServiceSeeValues;

        public AppSeeValues( IServiceSeeValues IServiceSeeValues) 
        {
            _IServiceSeeValues = IServiceSeeValues;
        }

        public async Task<SeeValuesResponse> CalculateValues(SeeValuesRequest seeValues)
        {
            return await _IServiceSeeValues.CalculateValues(seeValues);
            
        }

        public async Task<List<Notifies>> ValidateSeeValues(SeeValuesRequest values)
        {
            return await _IServiceSeeValues.ValidateSeeValues(values);
        }
    }
}
 