using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class CacheServer
    {
        //Real videos that are stored on this cache
        private List<Video> _videos;

        //Potential videos that can be stored on this cache
        private List<Video> _tempVideos;

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

        public List<Video> TempVideos
        {
            get { return _tempVideos; }
            set { _tempVideos = value; }
        }

        public float GetFreeSpacePercent()
        {
            int spaceUsed = 0;
            foreach (Video vid in _tempVideos)
            {
                spaceUsed += vid.Size;
            }

            return (float)spaceUsed/MAXSIZE;
        }
    }
}
