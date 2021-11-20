using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebPictureApplication.Models;

namespace WebPictureApplication.Shared
{
    public static class JsonGetter
    {
        public static Quote[] GetSweets (string path)
        {
            string jsonstring = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Quote[]>(jsonstring);
        }

        public static LongText[] GetStickers(string path)
        {
            string jsonstring = File.ReadAllText(path);
            return JsonSerializer.Deserialize<LongText[]>(jsonstring);
        }

        public static NamedText[] GetBoxes(string path)
        {
            string jsonstring = File.ReadAllText(path);
            return JsonSerializer.Deserialize<NamedText[]>(jsonstring);
        }

        public static PictureText[] GetChoco(string path)
        {
            string jsonstring = File.ReadAllText(path);
            return JsonSerializer.Deserialize<PictureText[]>(jsonstring);
        }
    }
}
