using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebPictureApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("sweets/{ids}")]
        public IActionResult DownloadSweets(string ids)
        {
            ////не работает
            //DownloadCover();

            int[] infos = PreparePath(ids);
            ImageMaker sweetsMaker = new ImageMaker(WrapTypes.Sweets, infos);
            return Download(sweetsMaker, "sweets.tif");
        }

        [HttpGet("cover")]
        public IActionResult DownloadCover()
        {
            string path = @"wwwroot\PrintLayouts\sweets_outside.tif";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Image image = Image.FromStream(fs);
            fs.Close();
            Bitmap btm = new Bitmap(image);

            MemoryStream memoryStream = new MemoryStream();
            btm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Tiff);
            memoryStream.Position = 0;
            return File(memoryStream,
                    "application/force-download", "cover.tif");
        }

        [HttpGet("stickers/{ids}")]
        public IActionResult DownloadStickers(string ids)
        {
            int[] infos = PreparePath(ids);
            
            ImageMaker stickersMaker = new ImageMaker(WrapTypes.Stickers, infos);
            return Download(stickersMaker, "stickers.tif");
        }

        private int[] PreparePath (string ids)
        {
            string[] strInfos = ids.Split('-');
            List<int> infos = new List<int>();
            foreach (var id in strInfos)
            {
                infos.Add(int.Parse(id));
            }
            return infos.ToArray();
        }

        [HttpGet("purplebox/{ids}")]
        public IActionResult DownloadPurpleBox(string ids)
        {
            int[] infos = PreparePath(ids);
            ImageMaker purpleBoxMaker = new ImageMaker(WrapTypes.PurpleBox, infos);
            return Download(purpleBoxMaker, "box.tif");
        }

        [HttpGet("greenbox/{ids}")]
        public IActionResult DownloadGreenBox(string ids)
        {
            int[] infos = PreparePath(ids);
            ImageMaker greenBoxMaker = new ImageMaker(WrapTypes.GreenBox, infos);
            return Download(greenBoxMaker, "box.tif");
        }

        private IActionResult Download(ImageMaker ImageMaker, string path)
        {
            Bitmap btm = ImageMaker.Make();
            MemoryStream memoryStream = new MemoryStream();
            btm.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Tiff);
            memoryStream.Position = 0;
            return File(memoryStream,
                    "application/force-download", path);
        }

        [HttpGet("greenchoco/{ids}")]
        public IActionResult DownloadGreenChoco(string ids)
        {
            int id = int.Parse(ids);
            ImageMaker greenChocoMaker = new ImageMaker(WrapTypes.GreenChocolate, new int[] { id });
            return Download(greenChocoMaker, "choco.tif");
        }

        [HttpGet("purplechoco/{ids}")]
        public IActionResult DownloadPurpleChoco(string ids)
        {
            int id = int.Parse(ids);
            ImageMaker purpleChocoMaker = new ImageMaker(WrapTypes.PurpleChocolate, new int[] { id });
            return Download(purpleChocoMaker, "choco.tif");
        }
    }
}
