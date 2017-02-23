using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class GreedyAssign
    {
        public List<Item> CostList = new List<Item>();

        public struct Item
        {
            public Video Video;
            public CacheServer Cache;
            public float HeuristicCosts;
        }

        public void InsertToList(Item item)
        {
            foreach (Item element in CostList)
            {
                
            }
        }

    }
}
