using System;
using System.Collections.Generic;
using System.IO;
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

            string[] output;

            //Wir gehen davon aus dass wir nur die richtigen Zahlen eingeben.
            int input;
            if (int.TryParse(s, out  input))
            {   
                // user has type 0 1 2 or 3
                output = EvaluateData((DataParser.ProblemSettings) input);
                WriteOutput(((DataParser.ProblemSettings) input).ToString(), output);
            }
            else
            {
                foreach (var mode in Enum.GetNames(typeof(DataParser.ProblemSettings)))
                {
                    var modeEnum = (DataParser.ProblemSettings) Enum.Parse(typeof(DataParser.ProblemSettings), mode);
                    output = EvaluateData(modeEnum);
                     WriteOutput(mode, output);
                }
                // solve all input files

            }

            Console.WriteLine("Done?");
        }

        public static string[] EvaluateData(DataParser.ProblemSettings mode)
        {
            Video[] videos;
            Endpoint[] endpoints;
            CacheServer[] cacheServers;
            RequestDescription[] requestsDescriptions;
            
            var progress = new Progress<float>(ProgressHandler);

            DataParser.ParseFileLines
                (DataParser.ReadFile(mode).ToArray(), out videos, out endpoints, out cacheServers, out requestsDescriptions, progress);

            CalculateVideoRequests(videos, requestsDescriptions);
            //calculate Heuristik

            GenerateHeuristic.GenerateHeuristicSteps(videos, cacheServers, progress);
            
            //start greedy assigning

                //1 claculate matrix M VxC with every element beeing: sum_over_all_endpoints(benefit / cacheserver_heuristik / video_size)

            GreedyAssign.GenerateHeuristicCosts(videos, cacheServers, progress);
            //2 while still space on any cache server: find biggest entry in M and assign V to C --> then set enty to 0. As soon as any cacheserver is full: delete column in M

            Assigner.Assign();

            return GetOutput(cacheServers);
        }

        private static void CalculateVideoRequests(Video[] videos, RequestDescription[] requestsDescriptions)
        {
            for (int i = 0; i < videos.Length; i++)
            {
                Video video = videos[i];
                for (int index = 0; index < requestsDescriptions.Length; index++)
                {
                    RequestDescription request = requestsDescriptions[index];
                    if (request.Video.Id == video.Id)
                    {
                        video.RequestsForThisVideo.Add(request);
                    }
                }
            }
        }

        private static string[] GetOutput(CacheServer[] cacheServers)
        {
            
            string[] output = new string[cacheServers.Length 
                 + 1];

            output[0] = cacheServers.Length.ToString();

            for (int index = 0; index < cacheServers.Length; index++)
            {
                CacheServer cache = cacheServers[index];

                int stringindex = index + 1;

                output[stringindex] = cache.Id.ToString();

                //Now all the videos stored
                foreach (Video video in cache.Videos)
                {
                    output[stringindex] += " " + video.Id;
                }
            }

            return output;
        }

        private static void WriteOutput(string filename, string[] output)
        {
            var outputDir = Directory.GetCurrentDirectory();
            var file = Path.Combine(outputDir, filename + ".out");
                File.WriteAllLines(file, output);
        }

        public static void NaiveEvaluate(Video[] videos, CacheServer[] servers, RequestDescription[] requests)
        {

            int curVideo = 0;

            foreach (var requestDescription in requests)
            {
                foreach (var connection in requestDescription.Endpoint.CacheConnections.Where(connection => connection.server.PercentUsed < 1))
                {
                    connection.server.TempVideos.Add(requestDescription.Video);
                    connection.server.CalculatePercentUsed();
                    if (connection.server.PercentUsed < 1)
                    {
                        break;
                    }
                    else
                    {
                        
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
