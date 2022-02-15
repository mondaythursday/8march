using Microsoft.Maui.Graphics;
using SkiaSharp;
using System.Runtime.InteropServices;
using WebAssemblyPictureApplication.Models;

namespace WebAssemblyPictureApplication.PictureMaker
{
    public class MauiImageMaker
    {
        byte[] _image;
        Quote[] _quotes;
        Stream _stream;
        public MauiImageMaker(byte[] image, Quote[] quotes)
        {
            _image = image;
            _quotes = quotes;
        }

        public MauiImageMaker(Stream stream, Quote[] quotes)
        {
            _stream = stream;
            _quotes = quotes;
        }

        public async Task<MemoryStream> MakeSweets()
        {
            MemoryStream result = new MemoryStream();

            using (MemoryStream memStream = new MemoryStream())
            {
                await _stream.CopyToAsync(memStream);
                memStream.Seek(0, SeekOrigin.Begin);

                SKBitmap bitmap = SKBitmap.Decode(memStream);

                var image = SKImage.FromBitmap(bitmap);
                var data = image.Encode();
                using (var stream = result) { data.SaveTo(stream); } 
             }
            return result;
        }
    }
}
