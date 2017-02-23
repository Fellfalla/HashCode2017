using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public static class GenerateHeuristic
    {


        public static void GenerateHeuristicSteps(List<Video> videos, List<CacheServer> cacheServers )
        {

            //calculate Heuristik

            //1 calculate cost savings for all combinations video zu cacheserver

            //2 assign videos to optimal cache server  for every endpoint with full size and with reduced size(10%!?) to all other possible cache servers connected to this endpoint and ignore cahe server size for this step


            for (int iVideo = 0; iVideo < videos.Count; iVideo++)
            {
                for (int iServer = 0; iServer < cacheServers.Count; iServer++)
                {
                    double temp = CostSavings.calculateCostSavings(videos[iVideo], cacheServers[iServer]);

                    if (temp > 0)
                    {
                        cacheServers[iServer].TempVideos.Add(videos[iVideo]);
                    }

                }
            }


            //3 calculate used_space/avilable_space for every chache server

            foreach (var cacheServer in cacheServers)
            {
                cacheServer.CalculatePercentUsed();
            }


        }


    }
}
