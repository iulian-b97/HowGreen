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
            var consumption = new IndexConsumption
            {
                District = model.District
            };

            consumption.IndexConsumptionId = Guid.NewGuid().ToString();
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
            };

            int hhTOmm = _applianceRepository.ConvertHHToMM(appliance.hh);
            int total_mm = hhTOmm + appliance.mm;
            int mmTOss = _applianceRepository.ConvertMMToSS(total_mm);
            float wTokw = _applianceRepository.ConvertWattsToKw(appliance.nrWatts);
            appliance.kwMonth = _applianceRepository.GetKwMonth(wTokw, mmTOss);

            appliance.Id = Guid.NewGuid().ToString();
            appliance.SmallUserId = _userRepository.GetIdByName(UserName);
            appliance.IndexConsumptionId = _userRepository.GetIdConsumptionByName(UserName);

            float priceKw = _applianceRepository.GetPriceKw(appliance.IndexConsumptionId);
            appliance.priceMonth = _applianceRepository.GetPriceMonth(appliance.kwMonth, priceKw);

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

            consumption.nrAppliances = _consumptionContext.Appliances.Where(x => x.SmallUserId.Equals(consumption.SmallUserId)).Count();
            List<Appliance> allAppliances = new List<Appliance>();
            allAppliances =  _consumptionContext.Appliances.Where(x => x.IndexConsumptionId.Equals(consumption.IndexConsumptionId)).ToList();
            consumption.nrKw = _applianceRepository.GetTotalKw(allAppliances);
            consumption.Price = _applianceRepository.GetTotalPrice(allAppliances);

            await _consumptionContext.FinalConsumptions.AddAsync(consumption);
            await _consumptionContext.SaveChangesAsync();

            return Ok(consumption);
        }

        
        [HttpPost]
        [Route("AddEnergyLabel")]
        public async Task<IActionResult> AddEnergyLabel(EnergyLabel model, string UserName)
        {
            EnergyLabel energyLabel = new EnergyLabel
            {
                MP = model.MP,
                HouseType = model.HouseType,
                Data = model.Data
            };

            energyLabel.Id = Guid.NewGuid().ToString();
            energyLabel.SmallUserId = _userRepository.GetIdByName(UserName);
            energyLabel.FinalConsumptionId = _userRepository.GetIdFinalConsumptionByName(UserName);

            energyLabel.TotalConsumption = (_userRepository.GetTotalConsumptionByFinalId(energyLabel.FinalConsumptionId) * 12);

            energyLabel.kW_mpa = (float)_applianceRepository.GetKwMpa(energyLabel.TotalConsumption, energyLabel.MP);
            energyLabel.Index = (float)_applianceRepository.GetIndex(energyLabel.kW_mpa);
            energyLabel.EnergyClass = _applianceRepository.GetEnergyLabel(energyLabel.Index);

            await _consumptionContext.EnergyLabels.AddAsync(energyLabel);
            await _consumptionContext.SaveChangesAsync();

            return Ok(energyLabel);
        }


        [HttpGet]
        [Route("GetAllAppliances")]
        public async Task<IActionResult> GetAllAppliances(string UserName)
        {
            ICollection<Appliance> allAppliances = new List<Appliance>();

            string userId = _userRepository.GetIdByName(UserName);
            allAppliances =  _consumptionContext.Appliances.Where(x => x.SmallUserId.Equals(userId)).OrderBy(x => x.ApplianceType).ToList();

            return Ok(allAppliances);
        }

        [HttpGet]
        [Route("GetFinalConsumption")]
        public async Task<IActionResult> GetFinalConsumption(string UserName)
        {
            FinalConsumption finalConsumption = new FinalConsumption();

            string userId = _userRepository.GetIdByName(UserName);
            finalConsumption = _consumptionContext.FinalConsumptions.FirstOrDefault(x => x.SmallUserId.Equals(userId));

            return Ok(finalConsumption);
        }

        [HttpGet]
        [Route("GetEnergyLabel")]
        public async Task<IActionResult> GetEnergyLabel(string UserName)
        {
            EnergyLabel energyLabel = new EnergyLabel();

            string userId = _userRepository.GetIdByName(UserName);
            energyLabel = _consumptionContext.EnergyLabels.FirstOrDefault(x => x.SmallUserId.Equals(userId));

            return Ok(energyLabel);
        }
    }
}
