using System;

namespace HashCode2017.Practice
{
    public class PizzaDataReader
    {
        public static string[] ReadPizzaData(DataSize size)
        {
            switch (size)
            {
                    case DataSize.Big:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.big.in");
                    case DataSize.Medium:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.big.in");
                    case DataSize.Small:
                        return EmbeddedResourceReader.ReadStrings("HashCode2017.Practice.Resources.big.in");
                default:
                    throw new ArgumentException();
            }

        }


        public enum DataSize { Small, Medium, Big}
    }
}
