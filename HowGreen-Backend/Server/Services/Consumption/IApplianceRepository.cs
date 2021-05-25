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
    }
}
