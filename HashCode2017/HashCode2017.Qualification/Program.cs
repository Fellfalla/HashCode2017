using System;
using System.Collections.Generic;
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

            //Wir gehen davon aus dass wir nur die richtigen Zahlen eingeben.
            int input = int.Parse(s);

            List<Video> videos;
            List<Endpoint> endpoints;
            
            DataParser.ParseFileLines(DataParser.ReadFile((DataParser.ProblemSettings) input), out videos, out endpoints);



        }
    }
}
