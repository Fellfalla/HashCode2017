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
            for (int index = 0; index < CostList.Count; index++)
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

    }
}
