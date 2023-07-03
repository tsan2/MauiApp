using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProba.Models
{
    public class Film
    {
        public string title;
        public List<string> authors;
        public string publishedDate;
        public string description;
        public List<Dictionary<string, string>> imageLinks;
        public List<string> categories;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
                }
            }
        }

        public string PublishedDate
        {
            get => publishedDate;
            set
            {
                if (publishedDate != value)
                {
                    publishedDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PublishedDate)));
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
            }
        }

        public List<Dictionary<string, string>> ImageLinks
        {
            get => imageLinks;
            set
            {
                if (imageLinks != value)
                {
                    imageLinks = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageLinks)));
                }
            }
        }

        public List<string> Authors
        {
            get => authors;
            set
            {
                if (authors != value)
                {
                    authors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Authors)));
                }
            }
        }

        public List<string> Genre
        {
            get => categories;
            set
            {
                if (categories != value)
                {
                    categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
                }
            }
        }

    }
}
