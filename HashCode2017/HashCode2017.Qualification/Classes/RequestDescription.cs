using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class RequestDescription
    {
        private Video _video;
        private Endpoint _endpoint;
        private int _requestAmount;

        public RequestDescription(Video video, Endpoint endpoint, int requestAmount)
        {
            _video = video;
            _endpoint = endpoint;
            _requestAmount = requestAmount;
        }

        public Video Video
        {
            get { return _video; }
            set { _video = value; }
        }

        public Endpoint Endpoint
        {
            get { return _endpoint; }
            set { _endpoint = value; }
        }

        public int RequestAmount
        {
            get { return _requestAmount; }
            set { _requestAmount = value; }
        }
    }
}
