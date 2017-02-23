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

            //calculate Heuristik

                //1 calculate cost savings for all requests

                //2 assign videos to optimal cache server  for every endpoint with full size and with reduced size(10%!?) to all other possible cache servers connected to this endpoint and ignore cahe server size for this step

                //3 calculate used_space/avilable_space for every chache server

            //start greedy assigning

                //1 claculate matrix M VxC with every element beeing: sum_over_all_endpoints(benefit / cacheserver_heuristik / video_size)

                //2 while still space on any cache server: find biggest entry in M and assign V to C --> then set enty to 0. As soon as any cacheserver is full: delete column in M




        }
    }
}
