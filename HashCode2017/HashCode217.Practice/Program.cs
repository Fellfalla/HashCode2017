using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace HashCode2017.Practice
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var outputDir = Directory.GetCurrentDirectory();
            foreach (var mode in Enum.GetNames(typeof(PizzaDataReader.DataSize)))
            {
                var modeEnum = (PizzaDataReader.DataSize) Enum.Parse(typeof(PizzaDataReader.DataSize), mode);   
                var inData = PizzaDataReader.ReadPizzaData(modeEnum);

                Console.WriteLine("\n\nConstructing {0} Pizza", mode);
                var pizza = Pizza.ConsumePizzaData(inData.ToArray(), new Progress<float>(ProgressHandler));
                Console.WriteLine("\nConstructing {0} Pizza done.", mode);

                Console.WriteLine("Slicing {0} Pizza", mode);
                var slices = PizzaSlicer.SliceWithAnalysis(pizza, new Progress<float>(ProgressHandler)).ToList();
                Console.WriteLine("\nSlicing {0} Pizza done", mode);

                Console.WriteLine("Writing {0} PizzaSlices to output", mode);
                var outData = SlicesToOutput(slices);
                var file = Path.Combine(outputDir, mode + ".out");
                File.WriteAllLines(file, outData);
                Console.WriteLine("Finished\n", mode);

            }
            Process.Start(outputDir);
        }

        private static void ProgressHandler(float f)
        {
            Console.Write("\rProgress: {0} %\t\t", f * 100);
        }

        private static string[] SlicesToOutput(List<Slice> slices)
        {
            List<string> outData = new List<string>();
            outData.Add(slices.Count.ToString());
            foreach (var slice in slices)
            {
                outData.Add(slice.ToString());
            }

            return outData.ToArray();
        }
    }

}
