using Library.Server.Data;
using Library.Server.Entities.Consumption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Services.User;
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
        private readonly IUserRepository _userRepository;

        public ConsumptionController(ConsumptionContext consumptionContext, IUserRepository userRepository)
        {
            _consumptionContext = consumptionContext;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("AddIndexConsumption")]
        public async Task<ActionResult> AddIndexConsumption(IndexConsumption model, string UserName)
        {
            var consumption = new IndexConsumption();
            consumption.Id = Guid.NewGuid().ToString();
            consumption.SmallUserId = _userRepository.GetIdByName(UserName);

            await _consumptionContext.IndexConsumptions.AddAsync(consumption);
            await _consumptionContext.SaveChangesAsync();

            return Ok(consumption);
        }

        [HttpPost]
        [Route("AddAppliance")]
        public async Task<ActionResult> AddAppliance(Appliance model, string UserName)
        {
            var appliance = new Appliance
            {
                ApplianceType = model.ApplianceType,
                nrWatts = model.nrWatts,
                hh = model.hh,
                mm = model.mm,
                priceKw = model.priceKw,
                kwMonth = model.kwMonth,
                priceMonth = model.priceMonth
            };

            appliance.Id = Guid.NewGuid().ToString();
            //appliance.SmallUserId = _userRepository.GetIdByName(UserName);
            appliance.IndexConsumptionId = _userRepository.GetIdConsumptionByName(UserName);

            await _consumptionContext.Appliances.AddAsync(appliance);
            await _consumptionContext.SaveChangesAsync();

            return Ok(appliance);
        }


        [HttpPost]
        [Route("AddConsumption")]
        public async Task<ActionResult> AddConsumption(FinalConsumption model, string UserName)
        {
            var consumption = new FinalConsumption
            {
                Data = model.Data,
                nrKw = model.nrKw,
                Price = model.Price
            };

            consumption.IndexConsumptionId = _userRepository.GetIdConsumptionByName(UserName);
            //consumption.SmallUserId = _userRepository.GetIdByName(UserName);

            await _consumptionContext.FinalConsumptions.AddAsync(consumption);
            await _consumptionContext.SaveChangesAsync();

            return Ok(consumption);
        }
    }
}
