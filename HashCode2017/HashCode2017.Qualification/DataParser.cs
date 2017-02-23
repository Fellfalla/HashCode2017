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
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.kittens.in", assembly);
                    case ProblemSettings.me_at_the_zoo:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.me_at_the_zoo.in", assembly);
                    case ProblemSettings.trending_today:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.trending_today.in", assembly);
                    case ProblemSettings.video_worth_spreading:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.video_worth_spreading.in", assembly);
                default:
                    throw new ArgumentException();
            }

        }


        public static void ParseFileLines(string[] fileLines, out List<Video> videos)
        {
            int currentLine = 0;
            int[] specs = fileLines[currentLine].Split(' ').Select(int.Parse).ToArray();

            int videoCount = specs[0];
            int endpointCount = specs[1];
            int requestCount = specs[2];
            int cachServerCount = specs[3];
            int cachecapacity = specs[4];


            // Parse Videos
            videos = new List<Video>();

            for (int i = 0; i < UPPER; i++)
            {
                
            }

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
