using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class RequestDescription
    {
        private Video _videoId;
        private Endpoint _endpointId;
        private int _requestAmount;

        public RequestDescription(Video videoId, Endpoint endpointId, int requestAmount)
        {
            _videoId = videoId;
            _endpointId = endpointId;
            _requestAmount = requestAmount;
        }

        public Video VideoId
        {
            get { return _videoId; }
            set { _videoId = value; }
        }

        public Endpoint EndpointId
        {
            get { return _endpointId; }
            set { _endpointId = value; }
        }

        public int RequestAmount
        {
            get { return _requestAmount; }
            set { _requestAmount = value; }
        }
    }
}
