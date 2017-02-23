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
        private List<Video> _videos = new List<Video>();

        //Potential videos that can be stored on this cache
        private List<Video> _tempVideos = new List<Video>();

        private const int MAXSIZE = 500000;

        private int occupied = 0;

        public float PercentUsed = 0;

        public CacheServer(int id)
        {
            Id = id;
        }

        public int _id;
        
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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public void PutVideo(Video video)
        {
            if (occupied + video.Size < MAXSIZE)
            {
                occupied += video.Size;
                Videos.Add(video);
            }
        }

        public void CalculatePercentUsed()
        {
            int spaceUsed = 0;
            foreach (Video vid in _tempVideos)
            {
                spaceUsed += vid.Size;
            }

            PercentUsed = (float)spaceUsed/MAXSIZE;
        }
    }
}
