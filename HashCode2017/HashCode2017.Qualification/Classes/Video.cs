using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode2017.Qualification.Classes
{
    public class Video
    {
        private int _size;
        private int _id;

        //constructor
        public Video(int size, int id)
        {
            _size = size;
            _id = id;
        }

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
