using System.IO;
using SixLabors.ImageSharp;

namespace WebAssemblyPictureApplication.PictureMaker
{
    public enum WrapTypes
    {
        GreenBox,
        PurpleBox,
        GreenChocolate,
        PurpleChocolate,
        Sweets,
        Stickers
    }
    public class ImageProvider
    {
        private string _path;
        private string _pathJPG;
        private readonly string _addition = "1";
        public string Result { get; }
        //public string ResultJPG { get; }
        public ImageProvider(WrapTypes type)
        {
            switch (type)
            {
                case WrapTypes.GreenBox:
                    _path = @"wwwroot\PrintLayouts\box_green_A3.tif";
                    break;
                case WrapTypes.PurpleBox:
                    _path = @"wwwroot\PrintLayouts\box_violet_A3.tif";
                    break;
                case WrapTypes.GreenChocolate:
                    _path = @"wwwroot\PrintLayouts\choco_green_A4.tif";
                    break;
                case WrapTypes.PurpleChocolate:
                    _path = @"wwwroot\PrintLayouts\choco_violet_A4.tif";
                    break;
                case WrapTypes.Sweets:
                    _path = @"wwwroot\PrintLayouts\sweets_inside_A4.tif";
                    _pathJPG = @"wwwroot\PrintLayouts\sweets_inside_A4.jpg";
                    break;
                case WrapTypes.Stickers:
                    _path = @"wwwroot\PrintLayouts\stickers_A4.tif";
                    break;
            }
            Result = Path.GetDirectoryName(_path) + "\\" + Path.GetFileNameWithoutExtension(_path) + _addition + Path.GetExtension(_path);
            //ResultJPG = Path.GetDirectoryName(_pathJPG) + "\\" + Path.GetFileNameWithoutExtension(_pathJPG) + _addition + Path.GetExtension(_pathJPG);
        }
        public Image GetImage()
        {
            Image image = Image.Load(_path);
            return image;
        }

        //public Image GetJPG()
        //{
        //    FileStream fs = new FileStream(_pathJPG, FileMode.Open, FileAccess.Read);
        //    Image image = Image.FromStream(fs);
        //    fs.Close();
        //    return image;
        //}

        public string RootPath()
        {
            return @"wwwroot\PrintLayouts\";
        }
    }
}
