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

        public CacheServer(List<Video> videos)
        {
            _videos = videos;
        }

        public List<Video> Videos
        {
            get { return _videos; }
            set { _videos = value; }
        }
    }
}
