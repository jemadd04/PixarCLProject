using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixarTheater
{
    public class ScoreComparer : IComparer<MovieData>
    {
        public int Compare(MovieData x, MovieData y)
        {
            return x.RTScore.CompareTo(y.RTScore) * -1;
        }
    }
}
