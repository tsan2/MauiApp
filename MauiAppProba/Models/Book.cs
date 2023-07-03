using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProba.Models
{
    public class Book1
    {
        public List<Book2> Items { get; set; }
    }

    public class Book2
    {
        public Book VolumeInfo { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }

    public class Book
    {

        public string Title { get; set; }
        public string? Description { get; set; }
        public List<string>? Authors { get; set; }
        public string? PublishedDate { get; set; }
        public List<string>? Categories { get; set; }
        public ImageLinks? ImageLinks { get; set; }
    }
}
