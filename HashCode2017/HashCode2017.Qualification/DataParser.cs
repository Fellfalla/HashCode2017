using System;
using System.Collections.Generic;
using System.Reflection;

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

        public static void ParseFileLines(string[] fileLines)
        {
            
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
