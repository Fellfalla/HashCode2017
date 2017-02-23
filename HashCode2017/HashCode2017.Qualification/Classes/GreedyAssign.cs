using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class GreedyAssign
    {


        public struct Item
        {
            public Video Video;
            public CacheServer Cache;
            public float HeuristicCosts;
        }

        public static void GenerateHeuristicCosts(List<Video> videos, List<CacheServer> cacheServers)
        {
            float listItem;

            foreach (var video in videos)
            {
                foreach (var cacheServer in cacheServers)
                {
                    //listItem = CalculateHeuristicForOneItem(video, cacheServer);
                    listItem = (float)CostSavings.calculateCostSavingsHeuristic(video, cacheServer);
                    InsertToList(listItem);
                }
            }
            
        }

        //public static float CalculateHeuristicForOneItem(Video video, CacheServer cacheServer)
        //{
        //    float listItem = 0;

        //    List<RequestDescription> listRequests = video.RequestsForThisVideo;

        //    foreach (var requestDescription in listRequests)
        //    {

        //        foreach (var endpointCacheConnection in requestDescription.Endpoint.CacheConnections)
        //        {
        //            CostSavings.calculateCostSavingsHeuristic(video, endpointCacheConnection.server);
        //        }
                
        //    }

        //    return listItem;
        //}

    }
}
