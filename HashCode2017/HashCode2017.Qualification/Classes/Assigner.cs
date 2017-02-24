using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    class Assigner
    {
        public static void Assign(IEnumerable<CacheServer> cacheServers)
        {
            //for (int index = 0; index < GreedyAssign.CostList.Count; index++)
            foreach (var server in cacheServers)
            {
                foreach (var tuple in server.CostList)
                {
                    server.PutVideo(tuple.Item2);
                }
            }
        }
        //public static void Assign()
        //{
        //    //for (int index = 0; index < GreedyAssign.CostList.Count; index++)
        //    foreach (var index in GreedyAssign.CostList.Keys)
        //    {
        //        var item = GreedyAssign.CostList[index];
        //        item.Cache.PutVideo(item.Video);
        //    }
        //}
    }
}
