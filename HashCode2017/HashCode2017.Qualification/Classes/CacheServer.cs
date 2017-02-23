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

        private const int MAXSIZE = 500000;

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

        public float GetFreeSpacePercent()
        {
            int spaceUsed = 0;
            foreach (Video vid in _videos)
            {
                spaceUsed += vid.Size;
            }

            return (float)spaceUsed/MAXSIZE;
        }
    }
}
