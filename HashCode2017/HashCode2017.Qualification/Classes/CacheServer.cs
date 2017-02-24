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
        public List<Video> Videos = new List<Video>();

        //Potential videos that can be stored on this cache
        public List<Video> TempVideos = new List<Video>();

        public List<Tuple<float, Video>> CostList = new List<Tuple<float, Video>>();

        public static int MAXSIZE;

        private int occupied = 0;

        public float PercentUsed = 0;

        public CacheServer(int id)
        {
            Id = id;
        }

        public int _id;



        public int Id;

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
            foreach (Video vid in TempVideos)
            {
                spaceUsed += vid.Size;
            }

            PercentUsed = (float)spaceUsed/MAXSIZE;
        }
    }
}
