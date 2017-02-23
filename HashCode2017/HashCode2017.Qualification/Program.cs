using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashCode2017.Practice;
using HashCode2017.Qualification.Classes;

namespace HashCode2017.Qualification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input int 0-4 for requested input");
            Console.WriteLine("0 = kittens");
            Console.WriteLine("1 = me_at_the_zoo");
            Console.WriteLine("2 = trending_today");
            Console.WriteLine("3 = videos_worth_spreading");
            String s;
             s = Console.ReadLine();
            Console.WriteLine("Input " + s);

            //Wir gehen davon aus dass wir nur die richtigen Zahlen eingeben.
            int input;
            if (int.TryParse(s, out  input))
            {   
                // user has type 0 1 2 or 3
                EvaluateData((DataParser.ProblemSettings) input);
            }
            else
            {
                foreach (var mode in Enum.GetNames(typeof(DataParser.ProblemSettings)))
                {
                    var modeEnum = (DataParser.ProblemSettings) Enum.Parse(typeof(DataParser.ProblemSettings), mode);
                    EvaluateData(modeEnum);
                }
                // solve all input files

            }
        }

        public static void EvaluateData(DataParser.ProblemSettings mode)
        {
            Video[] videos;
            Endpoint[] endpoints;
            CacheServer[] cacheServers;
            RequestDescription[] requestsDescriptions;
            
            var progress = new Progress<float>(ProgressHandler);

            DataParser.ParseFileLines
                (DataParser.ReadFile(mode).ToArray(), out videos, out endpoints, out cacheServers, out requestsDescriptions, progress);

            //calculate Heuristik

            //GenerateHeuristic.GenerateHeuristicSteps(videos, cacheServers);
            
            //start greedy assigning

                //1 claculate matrix M VxC with every element beeing: sum_over_all_endpoints(benefit / cacheserver_heuristik / video_size)

                //2 while still space on any cache server: find biggest entry in M and assign V to C --> then set enty to 0. As soon as any cacheserver is full: delete column in M




        }

        public static void NaiveEvaluate(Video[] videos, CacheServer[] servers, RequestDescription[] requests)
        {

            int curVideo = 0;

            for (int i = 0; i < servers.Length; i++)
            {
                while (servers[i].PercentUsed < 1)
                {
                    if (curVideo >= videos.Length)
                    {
                        return;
                    }

                    else
                    {
                        var addedVideo = videos[curVideo++];
                        servers[i].TempVideos.Add(addedVideo);

                        servers[i].CalculatePercentUsed();

                        if (servers[i].PercentUsed > 1)
                        {
                            servers[i].TempVideos.Remove(addedVideo);
                            break;
                        }
                    }
                }
            }
        }

        
        private static void ProgressHandler(float f)
        {
            Console.Write("\rProgress: {0} %\t\t", f * 100);
        }
        
    }
}
