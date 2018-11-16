using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixarTheater
{
    public class RootObject
    {
        public Movie[] Movie { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Score { get; set; }

        public int Gross { get; set; }
    }
}
