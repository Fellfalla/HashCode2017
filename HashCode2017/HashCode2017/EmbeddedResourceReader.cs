using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017
{
    public static class EmbeddedResourceReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource">"MyCompany.MyProduct.MyFile.txt"</param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<string> ReadStrings(string resource, Assembly assembly = null)
        {
            if (assembly == null)
            {
                assembly = Assembly.GetCallingAssembly();
            }

            using (Stream stream = assembly.GetManifestResourceStream(resource))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }

            }
        }
    }
}
