using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class GreedyAssign
    {
        public static List<Item> CostList = new List<Item>();

        public struct Item
        {
            public Video Video;
            public CacheServer Cache;
            public float HeuristicCosts;
        }

        public static void GenerateHeuristicCosts(Video[] videos, CacheServer[] cacheServers, IProgress<float> progress)
        {
            float value;
            int counter = 0;
            foreach (var video in videos)
            {
                progress.Report(counter++/(float) videos.Length);
                foreach (var cacheServer in cacheServers)
                {
                    //listItem = CalculateHeuristicForOneItem(video, cacheServer);
                    value = (float)CostSavings.calculateCostSavingsHeuristic(video, cacheServer);
                    Item item = new Item()
                    {
                        Video = video,
                        Cache = cacheServer,
                        HeuristicCosts = value
                    };
                   
                    InsertToList(item);
                }
            }
            
        }

        
        public static void InsertToList(Item item)
        {
            int count = CostList.Count;
            for (int index = 0; index < count; index++)
            {
                Item element = CostList[index];
                if (item.HeuristicCosts < element.HeuristicCosts)
                {
                    CostList.Insert(index, item);
                    return;
                }
            }

            CostList.Add(item);
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
