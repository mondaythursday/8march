using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebAssemblyPictureApplication.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System.Net.Http;
using System.Threading.Tasks;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
//using Microsoft.Maui.Graphics;

namespace WebAssemblyPictureApplication.PictureMaker
{
    public class ImageMaker
    {
        SolidBrush _greenBrush = new SolidBrush(Color.FromRgb(0, 55, 25));
        SolidBrush _whiteBrush = new SolidBrush(Color.FromRgb(255, 255, 255));
        SolidBrush _purpleBrush = new SolidBrush(Color.FromRgb(94, 45, 133));
        //StringFormat _stringFormat = new StringFormat
        //{
        //    Alignment = StringAlignment.Center,
        //    LineAlignment = StringAlignment.Near
        //};

        //StringFormat _verticalFormat = new StringFormat
        //{
        //    Alignment = StringAlignment.Center,
        //    LineAlignment = StringAlignment.Center
        //};

        FontCollection _fontCollection;
        FontFamily _didonaFamily;
        FontFamily _forumFamily;

        WrapTypes _type;
        int[] _infoIds;
        public string Result { get; private set; }

        public ImageMaker(WrapTypes type, int[] infoIds)
        {
            _type = type;
            _infoIds = infoIds;
            _fontCollection = new FontCollection();

            

            //C:\Users\Kitar\source\repos\TestDrawingApp\TestDrawingApp\bin\Debug\netcoreapp3.1\stickers_A4.tif

            //_didonaFamily = _fontCollection.Install("Didona.ttf");

            //_forumFamily = _fontCollection.Install("Forum.ttf");
        }

        public void Make(Stream stream)
        {
            Image image = Image.Load(stream);

        }

        public Image Make(Image image)
        {
            int w = image.Width;
            int h = image.Height;
            return image;
        }
        public void Make()
        {
            ImageProvider imageProvider = new ImageProvider(_type);
            Image image = imageProvider.GetImage();




            //Bitmap bitmap = new Bitmap(image);
            //Graphics _graphics = Graphics.FromImage(bitmap);

            switch (_type)
            {
                case WrapTypes.GreenBox:
                    //NamedText[] gbInfos = JsonGetter.GetBoxes(@"wwwroot\Data\BoxData.json");

                    //List<NamedText> greenBoxInfo = new List<NamedText>();
                    //for (int i = 0; i < _infoIds.Length; i++)
                    //{
                    //    greenBoxInfo.Add(gbInfos[_infoIds[i]]);
                    //}

                    //MakeBoxEqual(greenBoxInfo, _greenBrush, _graphics);
                    break;
                case WrapTypes.PurpleBox:

                    //NamedText[] pbInfos = JsonGetter.GetBoxes(@"wwwroot\Data\BoxData.json");

                    //List<NamedText> purpleBoxInfo = new List<NamedText>();
                    //for (int i = 0; i < _infoIds.Length; i++)
                    //{
                    //    purpleBoxInfo.Add(pbInfos[_infoIds[i]]);
                    //}

                    //MakeBoxEqual(purpleBoxInfo, _whiteBrush, _graphics);
                    break;
                case WrapTypes.GreenChocolate:
                    //PictureText[] gcInfos = JsonGetter.GetChoco(@"wwwroot\Data\ChocoData.json");
                    //PictureText gcInfo = gcInfos[_infoIds[0]];
                    //string pictureGreenPath = imageProvider.RootPath();
                    //MakeChocolate(gcInfo, _greenBrush, _graphics, pictureGreenPath);
                    break;
                case WrapTypes.PurpleChocolate:
                    //PictureText[] pcInfos = JsonGetter.GetChoco(@"wwwroot\Data\ChocoData.json");
                    //PictureText pcInfo = pcInfos[_infoIds[0]];
                    //string picturePurplePath = imageProvider.RootPath();
                    //MakeChocolate(pcInfo, _whiteBrush, _graphics, picturePurplePath);
                    break;
                case WrapTypes.Sweets:
                    Quote[] qInfos = JsonGetter.GetSweets(@"wwwroot\Data\SweetsData.json");
                    List<Quote> _sweetsInfo = new List<Quote>();
                    for (int i = 0; i < _infoIds.Length; i++)
                    {
                        _sweetsInfo.Add(qInfos[_infoIds[i]]);
                    }
                    MakeSweets(_sweetsInfo, image);
                    break;
                case WrapTypes.Stickers:
                    //LongText[] ltInfos = JsonGetter.GetStickers(@"wwwroot\Data\StickersData.json");
                    //List<LongText> _stickersInfo = new List<LongText>();
                    //for (int i = 0; i < _infoIds.Length; i++)
                    //{
                    //    _stickersInfo.Add(ltInfos[_infoIds[i]]);
                    //}
                    //MakeStickers(_stickersInfo, _graphics);
                    break;
            }

            //bitmap.Save(imageProvider.Result, image.RawFormat);
            //Result = imageProvider.Result;

            //return bitmap;
        }

        //void MakeBoxEqual(List<NamedText> boxInfo, SolidBrush brush, Graphics graphics)
        //{
        //    var DidonaFont = _didonaFamily.CreateFont(34, FontStyle.Bold);
        //    var ForumFont = _forumFamily.CreateFont(34, FontStyle.Regular);

        //    int boxWidth = 680;
        //    int firstX = 85;
        //    int firstY = 1190;
        //    float innerInterval = DidonaFont.LineHeight * 1.1f;

        //    int[] allX = new int[] { firstX, 3 * firstX + boxWidth, 5 * firstX + 2 * boxWidth, 7 * firstX + 3 * boxWidth };

        //    for (int i = 0; i < boxInfo.Count() / 3; i++)
        //    {
        //        SizeF firstTextSizeF = graphics.MeasureString(boxInfo[i * 3].Text, ForumFont, boxWidth, _stringFormat);
        //        float firstTextSize = firstTextSizeF.Height + innerInterval;
        //        SizeF secondTextSizeF = graphics.MeasureString(boxInfo[i * 3 + 1].Text, ForumFont, boxWidth, _stringFormat);
        //        float secondTextSize = secondTextSizeF.Height + innerInterval;
        //        SizeF thirdTextSizeF = graphics.MeasureString(boxInfo[i * 3 + 2].Text, ForumFont, boxWidth, _stringFormat);
        //        float thirdTextSize = thirdTextSizeF.Height + innerInterval;

        //        float textSize = firstTextSize + secondTextSize + thirdTextSize;
        //        float interval = (1620 - textSize) / 2;

        //        DrawBoxParafraph(firstY, allX[i], boxWidth, innerInterval, firstTextSize,
        //            boxInfo[i * 3].Name, boxInfo[i * 3].Text, brush, DidonaFont, ForumFont, graphics);

        //        float secondY = firstY + firstTextSize + interval;
        //        DrawBoxParafraph(secondY, allX[i], boxWidth, innerInterval, secondTextSize,
        //            boxInfo[i * 3 + 1].Name, boxInfo[i * 3 + 1].Text, brush, DidonaFont, ForumFont, graphics);

        //        float thirdY = secondY + secondTextSize + interval;
        //        DrawBoxParafraph(thirdY, allX[i], boxWidth, innerInterval, thirdTextSize,
        //            boxInfo[i * 3 + 2].Name, boxInfo[i * 3 + 2].Text, brush, DidonaFont, ForumFont, graphics);
        //    }
        //}
        //void DrawBoxParafraph(float y, int x, int width,
        //    float innerInterval, float size, string name, string text, SolidBrush brush,
        //    Font nameFont, Font textFont, Graphics _graphics)
        //{
        //    Rectangle rect = new Rectangle(x, (int)y, width, (int)size);
        //    _graphics.DrawString(name, nameFont, brush, rect, _stringFormat);
        //    DrawParagraph(_graphics, rect, textFont, brush, text, y + innerInterval, 0.9f);
        //}

        //void MakeChocolate(PictureText info, SolidBrush brush, Graphics graphics, string directoryName)
        //{
        //    string fileName = Path.GetFileName(info.Picture);
        //    string path = directoryName + fileName;
        //    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        //    Image img = Image.FromStream(fs);
        //    fs.Close();

        //    var DidonaFont = _didonaFamily.CreateFont(45, FontStyle.Regular);

        //    float size = 70f;
        //    float yKoef = 1f;

        //    if (info.Name.Length > 15)
        //    {
        //        size = 50f;
        //        if (info.Name.Length > 20)
        //        {
        //            yKoef = 2f;
        //        }
        //    }

        //    var ForumFont = _forumFamily.CreateFont(30, FontStyle.Regular);

        //    var BigDidonaFont = _didonaFamily.CreateFont(size, FontStyle.Regular);

        //    graphics.DrawImage(img, new Rectangle(700, 150, 927, 1100),
        //        new Rectangle(new Point(), img.Size), GraphicsUnit.Pixel);

        //    Rectangle textRect = new Rectangle(750, 1300, 827, 500);
        //    graphics.DrawString(info.Name, BigDidonaFont, brush, textRect, _stringFormat);

        //    float y = textRect.Top + BigDidonaFont.LineHeight * yKoef;
        //    float x = textRect.Left + textRect.Width / 2;
        //    graphics.DrawString(info.Author, DidonaFont, brush, x, y, _stringFormat);
        //    y += DidonaFont.LineHeight * 1.4f;
        //    DrawParagraph(graphics, textRect, ForumFont, brush, info.Text, y, 0.9f);
        //}
        void MakeSweets(List<Quote> infos, Image img)
        {
            //var DidonaFont = _didonaFamily.CreateFont(45, FontStyle.Regular);
            //var ForumFont = _forumFamily.CreateFont(45, FontStyle.Regular);

            int boxHeight = 930;
            int boxWidth = 1000;
            int x = 180;
            int y = 330;
            int yInterval = 70;
            int xInterval = 60;

            img.Save("t.tif");

            //using (Image image = Image.Load("sweets_inside_A4.tif"))
            //{
            //    //image.Mutate(x => x.DrawText(infos[0].Text, DidonaFont, Color.Black, new PointF(10, 10)));

            //    image.Save("sw.tif");
            //}

            //int authorHeight = 200;


            //Rectangle[] textRects = new Rectangle[] {
            //    new Rectangle(x, y, boxWidth, boxHeight),
            //    new Rectangle(x, y+boxHeight+yInterval, boxWidth, boxHeight),
            //    new Rectangle(x, y+boxHeight*2+yInterval*2, boxWidth, boxHeight),
            //    new Rectangle(x+boxWidth+xInterval*2, y, boxWidth, boxHeight),
            //    new Rectangle(x+boxWidth+xInterval*2, y+boxHeight+yInterval, boxWidth, boxHeight),
            //    new Rectangle(x+boxWidth+xInterval*2, y+boxHeight*2+yInterval*2, boxWidth, boxHeight) };

            //for (int i = 0; i < textRects.Length; i++)
            //{
            //    graphics.DrawString(infos[i].Text, DidonaFont, _purpleBrush, textRects[i], _verticalFormat);
            //    SizeF stringSize = graphics.MeasureString(infos[i].Text, DidonaFont, textRects[i].Width, _verticalFormat);
            //    float interval = (boxHeight - stringSize.Height) / 2;
            //    float authorY = textRects[i].Y + stringSize.Height + interval + DidonaFont.LineHeight;
            //    Rectangle authorRect = new Rectangle(textRects[i].X, (int)authorY, boxWidth, authorHeight);
            //    graphics.DrawString($"{infos[i].Source}\n{infos[i].Author}", ForumFont, _purpleBrush, authorRect, _stringFormat);
            //}
        }

        //void MakeStickers(List<LongText> infos, Graphics graphics)
        //{
        //    var DidonaFont = _didonaFamily.CreateFont(33, FontStyle.Bold);

        //    int boxHeight = 400;
        //    int boxWidth = 670;
        //    int x = 195;
        //    int y = 290;
        //    int yInterval = 415;
        //    int xInterval = 155;

        //    Rectangle[] textRects = DrawRectanglesForStickers(x, y, boxWidth, boxHeight, xInterval, yInterval);

        //    for (int i = 0; i < infos.Count(); i++)
        //    {
        //        //!!
        //        DrawThreeRectangles(i, infos[i].Text, DidonaFont, textRects[i], graphics);
        //    }
        //}
        //Rectangle[] DrawRectanglesForStickers(int x, int y, int boxWidth, int boxHeight, int xInterval, int yInterval)
        //{
        //    var result = new List<Rectangle>();
        //    for (int k = 0; k < 4; k++)
        //    {
        //        for (int i = 0; i < 3; i++)
        //        {
        //            result.Add(
        //                new Rectangle(
        //                    x + k * (boxWidth + xInterval),
        //                    y + i * (boxHeight + yInterval),
        //                    boxWidth,
        //                    boxHeight));
        //        }
        //    }

        //    return result.ToArray();
        //}
        //private void DrawThreeRectangles(int i, string text, Font font, Rectangle rect, Graphics graphics)
        //{
        //    for (int k = 0; k < 3; k++)
        //    {
        //        graphics.DrawString(text, font, _whiteBrush, rect, _stringFormat);
        //    }
        //}
        //private void DrawParagraph(
        //    Graphics gr,
        //    RectangleF rect,
        //    Font font,
        //    SolidBrush brush,
        //    string text,
        //    float y,
        //    float line_spacing)
        //{
        //    float x = rect.Left;

        //    string[] words = text.Split(' ');
        //    int start_word = 0;

        //    for (; ; )
        //    {
        //        string line = words[start_word];
        //        int end_word = start_word + 1;
        //        while (end_word < words.Length)
        //        {
        //            string test_line = line + " " + words[end_word];
        //            SizeF line_size = gr.MeasureString(test_line, font);
        //            if (line_size.Width > rect.Width)
        //            {
        //                end_word--;
        //                break;
        //            }
        //            else
        //            {
        //                line = test_line;
        //            }
        //            end_word++;
        //        }
        //        if (end_word == words.Length)
        //        {
        //            gr.DrawString(line, font, brush, x, y);
        //        }
        //        else
        //        {
        //            DrawJustifiedLine(gr, rect, font, brush, line, y);
        //        }
        //        y += font.LineHeight * line_spacing;
        //        if (font.Size > rect.Height) break;
        //        start_word = end_word + 1;
        //        if (start_word >= words.Length) break;
        //    }
        //}


        //private void DrawJustifiedLine(
        //    Graphics gr,
        //    RectangleF rect,
        //    Font font,
        //    SolidBrush brush,
        //    string text,
        //    float y)
        //{
        //    string[] words = text.Split(' ');
        //    float[] word_width = new float[words.Length];
        //    float total_width = 0;
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        SizeF size = gr.MeasureString(words[i], font);
        //        word_width[i] = size.Width;
        //        total_width += word_width[i];
        //    }

        //    float extra_space = rect.Width - total_width;
        //    int num_spaces = words.Length - 1;
        //    if (words.Length > 1) extra_space /= num_spaces;

        //    float x = rect.Left;
        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        gr.DrawString(words[i], font, brush, x, y);

        //        x += word_width[i] + extra_space;
        //    }
        //}
    }
}
