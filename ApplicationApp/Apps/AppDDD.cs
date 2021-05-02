using ApplicationApp.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Apps
{
    public class AppDDD : InterfaceDDDApp
    {
        IDDD _IDDD;

        IServiceDDD _IServiceDDD;

        public AppDDD(IDDD IDDD, IServiceDDD IServiceDDD)
        {
            _IDDD = IDDD;
            _IServiceDDD = IServiceDDD;
        }

        public async Task Add(DDD Objeto)
        {
            await _IDDD.Add(Objeto);
        }

        public async Task Delete(DDD Objeto)
        {
            await _IDDD.Delete(Objeto);
        }

        public async Task<DDD> GetEntityById(int Id)
        {
            return await _IDDD.GetEntityById(Id);
        }

        public async Task<List<DDD>> List()
        {
            return await _IDDD.List();
        }

        public async Task Update(DDD Objeto)
        {
            await _IDDD.Update(Objeto);
        }

        #region Services
        public async Task AddDDD(DDD ddd)
        {
            await _IServiceDDD.AddDDD(ddd);
        }

        public async Task UpdateDDD(DDD ddd)
        {
            await _IServiceDDD.UpdateDDD(ddd);
        }
        #endregion
    }
}
