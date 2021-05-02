using Domain.Interfaces;
using Entities.Entities;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceDDD : IServiceDDD
    {
        private readonly IDDD _IDDD;

        public ServiceDDD(IDDD IDDD) {
            _IDDD = IDDD;
        }
        public async Task AddDDD(DDD ddd)
        {
            var nameValidate = ddd.ValidateStringProperty(ddd.Name, "Name");
            var originValidate = ddd.ValidateDDD(ddd.Origin, "Origin");
            var destinyValidate = ddd.ValidateDDD(ddd.Destiny, "Origin");
            var priceValidate = ddd.ValidateDecimal(ddd.PricePerMinute, "PricePerMinute");

            if (nameValidate && originValidate && destinyValidate  && priceValidate)
            {
                await _IDDD.Add(ddd);
            }
        }

        public async Task UpdateDDD(DDD ddd)
        {
            var nameValidate = ddd.ValidateStringProperty(ddd.Name, "Name");
            var originValidate = ddd.ValidateDDD(ddd.Origin, "Origin");
            var destinyValidate = ddd.ValidateDDD(ddd.Destiny, "Origin");
            var priceValidate = ddd.ValidateDecimal(ddd.PricePerMinute, "PricePerMinute");

            if (nameValidate && originValidate && destinyValidate && priceValidate)
            {
                await _IDDD.Update(ddd);
            }
        }
    }
}
