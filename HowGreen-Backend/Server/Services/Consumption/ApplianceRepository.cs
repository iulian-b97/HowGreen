using Library.Server.Data;
using Library.Server.Entities.Consumption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.Consumption
{
    public class ApplianceRepository : IApplianceRepository
    {
        private readonly ConsumptionContext _consumptionContext;

        public ApplianceRepository(ConsumptionContext consumptionContext)
        {
            _consumptionContext = consumptionContext;
        }

        public int ConvertHHToMM(int HH)
        {
            return (HH * 60);
        }

        public int ConvertMMToSS(int MM)
        {
            return (MM * 60);
        }

        public float ConvertWattsToKw(float watts)
        {
            return (watts / 1000);
        }

        public string GetEnergyLabel(float index)
        {
            if (index == 0.55)
            {
                return "A++";
            }
            else if (index == 0.70f)
            {
                return "A+";
            }
            else if (index == 0.85f)
            {
                return "A";
            }
            else if (index == 1.00f)
            {
                return "B";
            }
            else if (index == 1.75f)
            {
                return "C";
            }
            else if (index == 2.50f)
            {
                return "D";
            }
            else if (index == 3.25f)
            {
                return "E";
            }
            else if (index == 4.00)
            {
                return "F";
            }
            else
            {
                return "G";
            }
        }

        public string GetHouseType(string EnergyLabelInputId)
        {
            var consumption = _consumptionContext.EnergyLabelInputs.FirstOrDefault(x => x.Id.Equals(EnergyLabelInputId));

            return consumption.TypeHouse;
        }

        public float GetIndex(float kwMpa)
        {
            if(kwMpa <= 10)
            {
                return 0.55f;
            }
            else if((kwMpa <= 15) && (kwMpa > 10))
            {
                return 0.70f;
            }
            else if((kwMpa <= 25) && (kwMpa > 15))
            {
                return 0.85f;
            }
            else if((kwMpa <= 50) && (kwMpa > 25))
            {
                return 1.00f;
            }
            else if((kwMpa <= 100) && (kwMpa > 50))
            {
                return 1.75f;
            }
            else if((kwMpa <= 150) && (kwMpa > 100))
            {
                return 2.50f;
            }
            else if((kwMpa <= 200) && (kwMpa > 150))
            {
                return 3.25f;
            }
            else if((kwMpa <= 250) && (kwMpa > 200))
            {
                return 4.00f;
            }
            else
            {
                return 5.00f;
            }
        }

        public float GetKwMonth(float kW, int SS)
        {
            float rez = ((float)SS / 3600) * 30;
            return (kW * rez);
        }

        public float GetKwMpa(float kwMonth, int mp)
        {
            return (kwMonth * 12) / (float)mp;
        }

        public int GetMP(string EnergyLabelInputId)
        {
            var consumption = _consumptionContext.EnergyLabelInputs.FirstOrDefault(x => x.Id.Equals(EnergyLabelInputId));

            return consumption.MP;
        }

        public float GetPriceMonth(float kwMonth, float priceKw)
        {
            return (kwMonth * priceKw);
        }


        public float GetTotalKw(List<Appliance> allAppliances)
        {
            float sum = 0;

            foreach(Appliance appliance in allAppliances)
            {
                sum += (float)appliance.kwMonth;
            }

            return sum;
        }

        public float GetTotalPrice(List<Appliance> allAppliances)
        {
            float sum = 0;

            foreach (Appliance appliance in allAppliances)
            {
                sum += (float)appliance.priceMonth;
            }

            return sum;
        }
    }
}
