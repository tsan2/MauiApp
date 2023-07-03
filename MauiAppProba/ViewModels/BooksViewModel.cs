using MauiAppProba.Models;
using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace MauiAppProba.ViewModels
{
    class BooksViewModel : INotifyPropertyChanged
    {
        static int index = 0;

        private static int GetIndex()
        {
            return index + 30;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string title;
        public string description;
        public List<string> authors;
        public string publishedDate;
        public List<string> categories;
        public ImageLinks imageLinks;

        private ObservableCollection<Book> _books;

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing == value)
                    return;

                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
            }
        }

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

        public List<string> Categories
        {
            get => categories;
            set
            {
                if (categories != value)
                {
                    categories = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Categories)));
                }
            }
        }

        public ImageLinks ImageLinks
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

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook == value)
                    return;

                _selectedBook = value;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedBook)));
            }
        }

        public BooksViewModel()
        {
            _books = new ObservableCollection<Book>();
            LoadDataCommand = new Command(async () => await LoadData());
            BookSelectedCommand = new Command(async () => await BookSelected());
            LoadTwoData = new Command(async () => await LoadDataTwo());
            RefreshCommand = new Command(async () => await RefreshDataAsync());

            //AddNewBookCommand = new Command(async () => await Shell.Current.GoToAsync("AddBookPage"));

            //MessagingCenter.Subscribe<AddBooksViewModel>(this, "refresh", async (sender) => await LoadData());

            Task.Run(LoadData);
        }

        private async Task BookSelected()
        {
            if (SelectedBook == null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                { "book", SelectedBook }
            };

            await Shell.Current.GoToAsync("ViewBooksPage", navigationParameter);

            MainThread.BeginInvokeOnMainThread(() => SelectedBook = null);
        }

        public ObservableCollection<Book> Books
        {
            get => _books;
            set => _books = value;
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand BookSelectedCommand { get; private set; }

        public ICommand LoadTwoData { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        const int RefreshDuration = 2;

        public async Task LoadDataTwo()
        {
            int index1 = GetIndex();
            if (IsBusy)
                return;

            try
            {
                var a = await ApiWorker.GetBookAsync(index1, 30);
                List<Book> booksCollection = new List<Book>();
                foreach (var item in a.Items)
                {
                    booksCollection.Add(item.VolumeInfo);
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Books.Clear();

                    foreach (Book book in booksCollection)
                    {
                        Books.Add(book);
                    }
                });
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }

        }

        async Task RefreshDataAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            await LoadDataTwo();
            IsRefreshing = false;
        }

        public async Task LoadData()
        {
            if (IsBusy)
                return;

            try
            {
                var a = await ApiWorker.GetBookAsync(0, 30);
                List<Book> booksCollection = new List<Book>();
                foreach (var item in a.Items)
                {
                    booksCollection.Add(item.VolumeInfo);
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Books.Clear();

                    foreach (Book book in booksCollection)
                    {
                        Books.Add(book);
                    }
                });
            }
            finally
            {
                IsRefreshing = false;
                IsBusy = false;
            }


        }
    }

}

