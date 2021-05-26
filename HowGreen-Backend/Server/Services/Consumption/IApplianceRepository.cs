using Library.Server.Entities.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.Consumption
{
    public interface IApplianceRepository
    {
        public float ConvertWattsToKw(float watts);
        public int ConvertHHToMM(int HH);
        public int ConvertMMToSS(int MM);
        public float GetKwMonth(float kW, int SS);
        public float GetPriceMonth(float kwMonth, float priceKw);

        public float GetTotalKw(List<Appliance> allAppliances);
        public float GetTotalPrice(List<Appliance> allAppliances);


        public int GetMP(string EnergyLabelInputId);
        public string GetHouseType(string EnergyLabelInputId);
        public float GetKwMpa(float kwMonth, int mp);
        public float GetIndex(float kwMpa);
        public string GetEnergyLabel(float index);

        public float GetPriceKw(string IndexConsumptionId);
    }
}
