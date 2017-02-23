using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class CacheServer
    {
        private List<Video> _videos;

        public CacheServer(int id)
        {
            _videos = new List<Video>();
        }

        public int Id { get;set; }

        public List<Video> Videos
        {
            get { return _videos; }
            set { _videos = value; }
        }

        public int GetFreeSpacePercent()
        {
            int space = 0;
            foreach (Video vid in _videos)
            {
                
            }

            return space;
        }
    }
}
