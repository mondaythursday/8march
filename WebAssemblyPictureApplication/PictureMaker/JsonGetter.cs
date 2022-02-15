using System;
using System.IO;
using System.Text.Json;
using WebAssemblyPictureApplication.Models;

namespace WebAssemblyPictureApplication.PictureMaker
{
    public class JsonGetter
    {
        public static Quote[] GetSweets(string path)
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
