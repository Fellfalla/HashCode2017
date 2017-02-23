﻿using System;
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

        public Endpoint(int latencyToDataCenter)
        {
            _latencyToDataCenter = latencyToDataCenter;
            _cacheConnections = new List<CacheConnection>();
        }

        public void AddCacheConnection(CacheServer server, int latency, int id)
        {
            var connection = new CacheConnection();
            connection.latency = latency;
            connection.server = server;
            Id = id;

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
    }
}
