using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017
{
    public class EmbeddedResourceReader
    {
        public string[] ReadStrings(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MyCompany.MyProduct.MyFile.txt";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result.Split(new [] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
