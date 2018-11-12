using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace PixarTheater
{
    class PlainTextSaver : Saver<MovieChoice>
    {
        public PlainTextSaver(string path) : base(path)
        {
        }

        public override void Save(MovieChoice obj)
        {
            File.WriteAllText(Path, obj.ToString());
        }
    }
}
