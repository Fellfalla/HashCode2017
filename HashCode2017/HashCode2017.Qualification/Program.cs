using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification
{
    class Program
    {
        static void Main(string[] args)
        {
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
