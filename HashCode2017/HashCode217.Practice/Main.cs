﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HashCode2017.Practice
{
    public static class Program
    {
        static void Main(string[] args)
        {
            foreach (var mode in Enum.GetNames(typeof(PizzaDataReader.DataSize)))
            {
                var modeEnum = (PizzaDataReader.DataSize) Enum.Parse(typeof(PizzaDataReader.DataSize), mode);   
                var inData = PizzaDataReader.ReadPizzaData(modeEnum);

                var pizza = Pizza.ConsumePizzaData(inData.ToArray());
                var slices = PizzaSlicer.SlicePizze(pizza);

                var outData = SlicesToOutput(slices);

                File.WriteAllLines(mode + ".out", outData);
            }

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
