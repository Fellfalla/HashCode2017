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

        private int _id;

        private List<CacheConnection> _cacheConnections;

        public Endpoint(int latencyToDataCenter, int id)
        {
            _latencyToDataCenter = latencyToDataCenter;
            _cacheConnections = new List<CacheConnection>();
            Id = id;
        }

        public void AddCacheConnection(CacheServer server, int latency)
        {
            var connection = new CacheConnection();
            connection.latency = latency;
            connection.server = server;

            CacheConnections.Add(connection);
        }

        public struct CacheConnection
        {
            public CacheServer server;
            public int latency;
        }


        public int LatencyToDataCenter
        {
            get { return _latencyToDataCenter; }
            set { _latencyToDataCenter = value; }
        }

        public List<CacheConnection> CacheConnections
        {
            get { return _cacheConnections; }
            set { _cacheConnections = value; }
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public int GetLatencyToCache(CacheServer cache)
        {
            int latency = LatencyToDataCenter;

            for (int index = 0; index < _cacheConnections.Count; index++)
            {
                CacheConnection connection = _cacheConnections[index];
                if (connection.server.Id == cache.Id)
                {
                    return connection.latency;
                }
            }

            return latency;

        }
    }
}
