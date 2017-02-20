using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017
{
    public static class IntegerExtensionMethod
    {
        /// <summary>
        /// With borders
        /// </summary>
        /// <param name="toTest"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static bool IsInRange(this int toTest, int start, int stop)
        {
            return start <= toTest && toTest <= stop;
        }

        /// <summary>
        /// Without borders
        /// </summary>
        /// <param name="toTest"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        public static bool IsInsideRange(this int toTest, int start, int stop)
        {
            return start < toTest && toTest < stop;
        }
    }
}
