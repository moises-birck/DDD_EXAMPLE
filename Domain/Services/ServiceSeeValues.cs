using Domain.Interfaces;
using Entities.Entities.RequestObject;
using Entities.Entities.ResponseObjects;
using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceSeeValues : IServiceSeeValues
    {

        private readonly ISeeValues _ISeeValues;

        private readonly IDDD _IDDD;
        private readonly IPhonePlan _IPhonePlan;

        public ServiceSeeValues(ISeeValues ISeeValues, IDDD IDDD, IPhonePlan IPhonePlan)
        {
            _ISeeValues = ISeeValues;
            _IDDD = IDDD;
            _IPhonePlan = IPhonePlan;

        }
        
        public async Task<SeeValuesResponse> CalculateValues(SeeValuesRequest seeValues)
        {
            int planMinutes = await _IPhonePlan.GetMinutesByPlan(seeValues.Plan);
            decimal taxPerMinutes = await _IDDD.GetEntityByPricePerMinute(seeValues.Origin, seeValues.Destiny);

            string withPlan = "-";
            string noPlan = "-";

            if (planMinutes > 0)
            {
                if (taxPerMinutes > 0)
                {
                    decimal calc = seeValues.CallMinutes - planMinutes;
                    if (calc > 0) { 
                        calc = calc * taxPerMinutes;
                        withPlan = ((calc * 0.1m) + calc).ToString("C");
                    }
                    else
                        withPlan = "0";

                    noPlan = (seeValues.CallMinutes * taxPerMinutes).ToString("C");
                }
            }
            else
                throw new Exception("Não foi encontrado os minutos do plano verificado: " + seeValues.Plan);


            SeeValuesResponse seeValuesResponse = new SeeValuesResponse();

            seeValuesResponse.request = seeValues;

            seeValuesResponse.WithPlan = withPlan;
            seeValuesResponse.NoPlan = noPlan;

            return seeValuesResponse;

        }

        public async Task<List<Notifies>> ValidateSeeValues(SeeValuesRequest values)
        {
            Notifies notifies = new Notifies();

            var planValidate = notifies.ValidateStringProperty(values.Plan, "Plan");
            var originValidate = notifies.ValidateDDD(values.Origin, "Origin");
            var destinyValidate = notifies.ValidateDDD(values.Destiny, "Origin");
            var callMinutesValidate = notifies.ValidateInt(values.CallMinutes, "CallMinutes");

            return notifies.Notifications;
        }

       
    }
}
