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
            int numberOfCalculations = v.RequestsForThisVideo.Count;
            for (int index = 0; index < numberOfCalculations; index++)
            {
                RequestDescription r = v.RequestsForThisVideo[index];
                result += r.RequestAmount*(r.Endpoint.LatencyToDataCenter - r.Endpoint.GetLatencyToCache(c));
            }

            return result;
        }

        public static double calculateCostSavingsHeuristic(Video v, CacheServer c)
        {
            double result = 0;

            int count = v.RequestsForThisVideo.Count;
            for (int index = 0; index < count; index++)
            {
                RequestDescription r = v.RequestsForThisVideo[index];
                //result += r.RequestAmount*(r.Endpoint.LatencyToDataCenter - r.Endpoint.GetLatencyToCache(c))/
                //          c.PercentUsed/v.Size;
                result += r.RequestAmount*(r.Endpoint.LatencyToDataCenter - r.Endpoint.GetLatencyToCache(c)) -
                          c.PercentUsed * v.Size;
            }

            return result;
        }
    }
}
