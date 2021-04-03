using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Entities.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {
        private readonly ConsumptionContext _consumptionContext;

        public ConsumptionController(ConsumptionContext consumptionContext)
        {
            _consumptionContext = consumptionContext;
        }

        [HttpPost]
        [Route("AddAppliance")]
        public async Task<ActionResult> AddAppliance(Appliance model)
        {
            var appliance = new Appliance
            {
                ApplianceType = model.ApplianceType,
                nrWatts = model.nrWatts,
                hoursDay = model.hoursDay,
                priceKw = model.priceKw
            };

            await _consumptionContext.Appliances.AddAsync(appliance);
            await _consumptionContext.SaveChangesAsync();

            return Ok(appliance);
        }
    }
}
