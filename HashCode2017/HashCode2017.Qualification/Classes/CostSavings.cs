using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    class CostSavings
    {
        public static double calculateCostSavings(Video v, CacheServer c)
        {
            double result = 0;

            foreach(RequestDescription r in v.RequestsForThisVideo)
            {
                result += r.RequestAmount * (r.Endpoint.LatencyToDataCenter-r.Endpoint.getLatencyToCache(c));
            }

            return result;
        }
    }
}
