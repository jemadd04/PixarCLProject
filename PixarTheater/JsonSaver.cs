using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace PixarTheater
{
    class JsonSaver : Saver<MovieChoice>
    {
        public JsonSaver(string path) : base(path)
        {
        }

        public override void Save(MovieChoice obj)
        {
            var data = JsonConvert.SerializeObject(obj);
            File.WriteAllText(Path, data);
        }
    }
}
