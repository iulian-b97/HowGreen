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
            if (index == 0.55f)
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
            else if (index == 4.00f)
            {
                return "F";
            }
            else
            {
                return "G";
            }
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
            float x = (kW * rez);
            float xf = (float)Math.Round(x * 100f) / 100f;

            return xf;
        }

        public float GetKwMpa(float kwYear, int mp)
        {
            float x = (kwYear) / (float)mp;
            float xf = (float)Math.Round(x * 100f) / 100f;

            return xf;
        }

        
        public int GetMP(string EnergyLabelId)
        {
            var consumption = _consumptionContext.EnergyLabels.FirstOrDefault(x => x.Id.Equals(EnergyLabelId));

            return consumption.MP;
        }

        public float GetPriceKw(string IndexConsumptionId)
        {
            var consumption = _consumptionContext.IndexConsumptions.FirstOrDefault(x => x.IndexConsumptionId.Equals(IndexConsumptionId));
            string district = consumption.District.ToUpper();

            if (district.Equals("GALATI"))
            {
                return 0.54434f;
            }
            else if (district.Equals("PRAHOVA"))
            {
                return 0.54434f;
            }
            else if (district.Equals("BUZAU"))
            {
                return 0.54434f;
            }
            else if (district.Equals("BRAILA"))
            {
                return 0.54434f;
            }
            else if (district.Equals("DAMBOVITA"))
            {
                return 0.54434f;
            }
            else if (district.Equals("VRANCEA"))
            {
                return 0.54434f;
            }
            else if (district.Equals("BIHOR"))
            {
                return 0.53352f;
            }
            else if (district.Equals("SATU MARE"))
            {
                return 0.53352f;
            }
            else if (district.Equals("SALAJ"))
            {
                return 0.53352f;
            }
            else if (district.Equals("CLUJ"))
            {
                return 0.53352f;
            }
            else if (district.Equals("BISTRITA NASAUD"))
            {
                return 0.53352f;
            }
            else if (district.Equals("MARAMURES"))
            {
                return 0.53352f;
            }
            else if (district.Equals("BRASOV"))
            {
                return 0.53837f;
            }
            else if (district.Equals("ALBA"))
            {
                return 0.53837f;
            }
            else if (district.Equals("HARGHITA"))
            {
                return 0.53837f;
            }
            else if (district.Equals("COVASNA"))
            {
                return 0.53837f;
            }
            else if (district.Equals("SIBIU"))
            {
                return 0.53837f;
            }
            else if (district.Equals("MURES"))
            {
                return 0.53837f;
            }
            else if (district.Equals("ARGES"))
            {
                return 0.56594f;
            }
            else if (district.Equals("VALCEA"))
            {
                return 0.56594f;
            }
            else if (district.Equals("GORJ"))
            {
                return 0.56594f;
            }
            else if (district.Equals("OLT"))
            {
                return 0.56594f;
            }
            else if (district.Equals("TELEORMAN"))
            {
                return 0.56594f;
            }
            else if (district.Equals("DOLJ"))
            {
                return 0.56594f;
            }
            else if (district.Equals("MEHEDINTI"))
            {
                return 0.56594f;
            }
            else if (district.Equals("SUCEAVA"))
            {
                return 0.55164f;
            }
            else if (district.Equals("BOTOSANI"))
            {
                return 0.55164f;
            }
            else if (district.Equals("NEAMT"))
            {
                return 0.55164f;
            }
            else if (district.Equals("IASI"))
            {
                return 0.55164f;
            }
            else if (district.Equals("BACAU"))
            {
                return 0.55164f;
            }
            else if (district.Equals("VASLUI"))
            {
                return 0.55164f;
            }
            else if (district.Equals("TIMIS"))
            {
                return 0.52118f;
            }
            else if (district.Equals("ARAD"))
            {
                return 0.52118f;
            }
            else if (district.Equals("HUNEDOARA"))
            {
                return 0.52118f;
            }
            else if (district.Equals("CARAS-SEVERIN"))
            {
                return 0.52118f;
            }
            else if (district.Equals("TULCEA"))
            {
                return 0.55773f;
            }
            else if (district.Equals("CONSTANTA"))
            {
                return 0.55773f;
            }
            else if (district.Equals("IALOMITA"))
            {
                return 0.55773f;
            }
            else if (district.Equals("CALARASI"))
            {
                return 0.55773f;
            }
            else if (district.Equals("ILFOV"))
            {
                return 0.51677f;
            }
            else if (district.Equals("GIURGIU"))
            {
                return 0.51677f;
            }
            else if (district.Equals("BUCURESTI"))
            {
                return 0.51677f;
            }
            else return 0.5200f;
        }

        public float GetPriceMonth(float kwMonth, float priceKw)
        {
            float x = (kwMonth * priceKw);
            float xf = (float)Math.Round(x * 100f) / 100f;

            return xf;
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
