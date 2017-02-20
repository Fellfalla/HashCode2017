using System;
using System.Collections.Generic;
using System.Reflection;

namespace HashCode2017.Practice
{
    public class PizzaDataReader
    {
        public static IEnumerable<string> ReadPizzaData(DataSize size)
        {
            var assembly = Assembly.GetExecutingAssembly();
            switch (size)
            {
                    case DataSize.Big:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.big.in", assembly);
                    case DataSize.Medium:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.medium.in", assembly);
                    case DataSize.Small:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.small.in", assembly);
                default:
                    throw new ArgumentException();
            }

        }


        public enum DataSize { Small, Medium, Big}
    }
}
