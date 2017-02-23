using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class Endpoint
    {
        private int _latencyToDataCenter;

        private List<CacheConnection> _cacheConnections;

        public Endpoint(int latencyToDataCenter, List<CacheConnection> cacheConnections)
        {
            _latencyToDataCenter = latencyToDataCenter;
            _cacheConnections = cacheConnections;
        }

        public struct CacheConnection
        {
            public int id;
            public int latency;
        }


    }
}
