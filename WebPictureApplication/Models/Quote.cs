using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing;
using System.Net.Http;

namespace WebPictureApplication.Models
{
    public class Quote
    {
        public string ShortAuthor { get; set; }
        public string Author { get; set; }
        public string Source { get; set; }
        public string Text { get; set; }
    }

}
