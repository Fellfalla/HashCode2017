using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HashCode2017.Qualification.Classes;

namespace HashCode2017.Practice
{
    public class DataParser
    {
        public static IEnumerable<string> ReadFile(ProblemSettings problemSetting)
        {
            var assembly = Assembly.GetExecutingAssembly();
            switch (problemSetting)
            {
                    case ProblemSettings.kittens:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Qualification.Resources.kittens.in", assembly);
                    case ProblemSettings.me_at_the_zoo:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Qualification.Resources.me_at_the_zoo.in", assembly);
                    case ProblemSettings.trending_today:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Qualification.Resources.trending_today.in", assembly);
                    case ProblemSettings.video_worth_spreading:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Qualification.Resources.video_worth_spreading.in", assembly);
                default:
                    throw new ArgumentException();
            }

        }


        public static void ParseFileLines(string[] fileLines, 
            out List<Video> videos,
            out List<Endpoint> endpoints,
            out List<CacheServer> cacheServers,
            out List<RequestDescription> requests,
            IProgress<float> progress 
            )
        {
            progress.Report(0);
            int currentLine = 0;
            int[] specs = fileLines[currentLine].Split(' ').Select(int.Parse).ToArray();

            int videoCount = specs[0];
            int endpointCount = specs[1];
            int requestCount = specs[2];
            int cachServerCount = specs[3];
            int cachecapacity = specs[4];


            // Parse Videos
            videos = new List<Video>();
            int[] videoSizes = fileLines[++currentLine].Split(' ').Select(int.Parse).ToArray();
            if (videoSizes.Length != videoCount)
                {
                    throw new Exception("Video Count mismatch");
                }

            for (int i = 0; i < videoSizes.Length; i++)
            {
                var newVideo = new Video(videoSizes[i], i);
                videos.Add(newVideo);
            }


            // ParseEndpoints and cache Servers
            cacheServers = new List<CacheServer>();
            endpoints = new List<Endpoint>();
            for (int i = 0; i < endpointCount; i++)
            {
                int endpointId = ++currentLine;
                int[] endpointSpecs = fileLines[endpointId].Split(' ').Select(int.Parse).ToArray();
                int endpointLatency = endpointSpecs[0];
                int connectedCaches = endpointSpecs[1];
                var newEndpoint = new Endpoint(endpointId, endpointLatency);

                for (int j = 0; j < connectedCaches; j++)
                {
                    int[] cacheSpecs = fileLines[++currentLine].Split(' ').Select(int.Parse).ToArray();
                    int cacheId = cacheSpecs[0];
                    int cacheLatency = cacheSpecs[1];

                    CacheServer cacheServer = null;
                    if (cacheServers.All(server => server.Id != cacheId))
                    {
                        // add Missing cacheServer
                        var newCacheServer = new CacheServer(cacheId);
                        cacheServers.Add(newCacheServer);
                    }
                    else
                    {
                        cacheServer = cacheServers.First(server => server.Id == cacheId);
                    }

                    newEndpoint.AddCacheConnection(cacheServer, cacheLatency);
                }

                endpoints.Add(newEndpoint);
            }


            // Parse Requests
            requests = new List<RequestDescription>();
            for (int i = 0; i < requestCount; i++)
            {
                int[] requestSpecs = fileLines[++currentLine].Split(' ').Select(int.Parse).ToArray();
                int videoId = requestSpecs[0];
                int endpointId = requestSpecs[1];
                int numberOfRequests = requestSpecs[2];

                // find video
                Video videoR = videos.First(video => video.Id == videoId);
                Endpoint endpointR = endpoints.First(endpoint => endpoint.Id == endpointId);

                var newRequest = new RequestDescription(videoR, endpointR, numberOfRequests);
                requests.Add(newRequest);
            }

            progress.Report(1);
        }


        

        public enum ProblemSettings
        {
            kittens,
            me_at_the_zoo,
            trending_today,
            video_worth_spreading
        }
    }
}
