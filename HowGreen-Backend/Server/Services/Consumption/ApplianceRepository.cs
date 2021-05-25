using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.Consumption
{
    public class ApplianceRepository : IApplianceRepository
    {
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

        public float GetKwMonth(float kW, int SS)
        {
            float rez = (SS / 3600) * 30;
            return (kW * rez);
        }

        public float GetPriceMonth(float kwMonth, float priceKw)
        {
            return (kwMonth * priceKw);
        }
    }
}
