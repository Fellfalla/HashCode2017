using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class GreedyAssign
    {
        //public static List<Item> CostList = new List<Item>();
        //public static Dictionary<Tuple<Video, CacheServer>, float> CostList = new Dictionary<Tuple<Video, CacheServer>, float>();
        //public static SortedList<float, Item> CostList = new SortedList<float, Item>();
        public struct Item
        {
            public Video Video;
            public CacheServer Cache;
            public float HeuristicCosts;
        }

        public static void GenerateHeuristicCosts(Video[] videos, CacheServer[] cacheServers, IProgress<float> progress)
        {
            //CostList.Clear();
            float value;
            int counter = 0;
            int videoCount = videos.Length;
            int cacheServerCount = cacheServers.Length;

            for (int index = 0; index < videoCount; index++)
            {
                var video = videos[index];
                progress.Report(counter++/(float) videoCount);

                for (int i = 0; i < cacheServerCount; i++)
                {
                    var cacheServer = cacheServers[i];
//listItem = CalculateHeuristicForOneItem(video, cacheServer);

                    value = (float) CostSavings.calculateCostSavingsHeuristic(video, cacheServer);
                    //Item item = new Item()
                    //{
                    //    Video = video,
                    //    Cache = cacheServer,
                    //    HeuristicCosts = value
                    //};

                    InsertToList(cacheServer, video, value);
                }
            }
        }


        public static void InsertToList(CacheServer cacheServer, Video video, float savings)
        {
            for (int i = 0; i < cacheServer.CostList.Count; i++)
            {
                if (savings > cacheServer.CostList[i].Item1)
                {
                    cacheServer.CostList.Insert(i, new Tuple<float, Video>(savings, video));
                }
            }
            cacheServer.CostList.Add(new Tuple<float, Video>(savings, video));
        }


        //public static void InsertToList(Item item)
        //{
        //    int count = CostList.Count;
        //    int jumpDivision = 2;
        //    int jumpSize = count / jumpDivision;
        //    int currentIndex = jumpSize;
        //    while (jumpSize > 0)
        //    {
        //        Item element = CostList[currentIndex - 1];
        //        if (item.HeuristicCosts < element.HeuristicCosts)
        //        {
        //            currentIndex += jumpSize;
        //        }
        //        else
        //        {
        //            currentIndex -= jumpSize;
        //        }

        //        jumpSize = jumpSize / jumpDivision;
        //    }
        //    CostList.Insert(currentIndex, item);

        //    //if (item.HeuristicCosts < CostList[currentIndex].HeuristicCosts)
        //    //{
        //    //    CostList.Insert(currentIndex, item);
        //    //}
        //    //else
        //    //{
        //    //    CostList.Insert(currentIndex+1, item);
        //    //}

        //    //CostList.Add(item);
        //}

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
