using Library.Server.Data;
using Library.Server.Entities.Consumption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Consumption;
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
        private readonly IApplianceRepository _applianceRepository;

        public ConsumptionController(ConsumptionContext consumptionContext, IUserRepository userRepository, IApplianceRepository applianceRepository)
        {
            _consumptionContext = consumptionContext;
            _userRepository = userRepository;
            _applianceRepository = applianceRepository;
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
                priceKw = model.priceKw
            };

            int hhTOmm = _applianceRepository.ConvertHHToMM(appliance.hh);
            int total_mm = hhTOmm + appliance.mm;
            int mmTOss = _applianceRepository.ConvertMMToSS(total_mm);
            float wTokw = _applianceRepository.ConvertWattsToKw(appliance.nrWatts);
            appliance.kwMonth = _applianceRepository.GetKwMonth(wTokw, mmTOss);
            appliance.priceMonth = _applianceRepository.GetPriceMonth(appliance.kwMonth, appliance.priceKw);

            appliance.Id = Guid.NewGuid().ToString();
            appliance.SmallUserId = _userRepository.GetIdByName(UserName);
            appliance.IndexConsumptionId = _userRepository.GetIdConsumptionByName(UserName);

            await _consumptionContext.Appliances.AddAsync(appliance);
            await _consumptionContext.SaveChangesAsync();

            return Ok(appliance);
        }


        [HttpPost]
        [Route("AddFinalConsumption")]
        public async Task<ActionResult> AddFinalConsumption(FinalConsumption model, string UserName)
        {
            var consumption = new FinalConsumption
            {
                Data = model.Data
            };

            consumption.FinalConsumptionId = Guid.NewGuid().ToString();
            consumption.IndexConsumptionId = _userRepository.GetIdConsumptionByName(UserName);
            consumption.SmallUserId = _userRepository.GetIdByName(UserName);

            List<Appliance> allAppliances = new List<Appliance>();
            allAppliances =  _consumptionContext.Appliances.Where(x => x.IndexConsumptionId.Equals(consumption.IndexConsumptionId)).ToList();
            consumption.nrKw = _applianceRepository.GetTotalKw(allAppliances);
            consumption.Price = _applianceRepository.GetTotalPrice(allAppliances);

            await _consumptionContext.FinalConsumptions.AddAsync(consumption);
            await _consumptionContext.SaveChangesAsync();

            return Ok(consumption);
        }

        
        [HttpPost]
        [Route("AddEnergyLabelInput")]
        public async Task<IActionResult> AddEnergyLabelInput(EnergyLabelInput model, string UserName)
        {
            EnergyLabelInput energyLabel = new EnergyLabelInput
            {
                MP = model.MP,
                TypeHouse = model.TypeHouse
            };

            energyLabel.Id = Guid.NewGuid().ToString();
            energyLabel.SmallUserId = _userRepository.GetIdByName(UserName);
            energyLabel.FinalConsumptionId = _userRepository.GetIdFinalConsumptionByName(UserName);

            energyLabel.TotalConsumption = _userRepository.GetTotalConsumptionByFinalId(energyLabel.FinalConsumptionId);

            await _consumptionContext.EnergyLabelInputs.AddAsync(energyLabel);
            await _consumptionContext.SaveChangesAsync();

            return Ok(energyLabel);
        }


        [HttpPost]
        [Route("AddEnergyLabelOutput")]
        public async Task<IActionResult> AddEnergyLabelOutput(EnergyLabelOutput model, string UserName)
        {
            EnergyLabelOutput energyLabel = new EnergyLabelOutput 
            {
                Data = model.Data
            };

            energyLabel.Id = Guid.NewGuid().ToString();
            energyLabel.SmallUserId = _userRepository.GetIdByName(UserName);
            energyLabel.FinalConsumptionId = _userRepository.GetIdFinalConsumptionByName(UserName);
            energyLabel.EnergyLabelInputId = _userRepository.GetIdEnergyLabelInput(energyLabel.FinalConsumptionId);

            int MP = _applianceRepository.GetMP(energyLabel.EnergyLabelInputId);
            float consumptionMonth = _userRepository.GetTotalConsumptionByFinalId(energyLabel.FinalConsumptionId);
            energyLabel.TypeHouse = _applianceRepository.GetHouseType(energyLabel.EnergyLabelInputId);
            energyLabel.kW_mpa = _applianceRepository.GetKwMpa(consumptionMonth, MP);
            energyLabel.Index = _applianceRepository.GetIndex(energyLabel.kW_mpa);
            energyLabel.EnergyClass = _applianceRepository.GetEnergyLabel(energyLabel.Index);
            
            await _consumptionContext.EnergyLabelOutputs.AddAsync(energyLabel);
            await _consumptionContext.SaveChangesAsync();

            return Ok(energyLabel);
        }
    }
}
