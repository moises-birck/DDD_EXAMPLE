using ApplicationApp.Interfaces;
using Entities.Entities.RequestObject;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace API_EXAMPLE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeeValuesController : ControllerBase
    {
      
        private readonly ILogger<SeeValuesController> _logger;
        private readonly InterfaceSeeValuesApp _InterfaceSeeValuesApp;

        public SeeValuesController(ILogger<SeeValuesController> logger, InterfaceSeeValuesApp InterfaceSeeValuesApp)
        {
            _InterfaceSeeValuesApp = InterfaceSeeValuesApp;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SeeValues(SeeValuesRequest see)
        {
            await Task.Delay(1);
            var respValidate = _InterfaceSeeValuesApp.ValidateSeeValues(see);
            if (respValidate.Status.ToString() == "RanToCompletion") {

                if (respValidate.Result.Any())
                    return BadRequest(respValidate.Result);

                var resp = _InterfaceSeeValuesApp.CalculateValues(see);
                if (resp.Status.ToString() == "RanToCompletion")
                {
                    var result = resp.Result;
                    return Ok(result);
                }
            }

            return BadRequest();
        }
    }
}
