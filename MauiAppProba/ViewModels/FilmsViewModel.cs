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
    class FilmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films;

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

        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                if (_selectedFilm == value)
                    return;

                _selectedFilm = value;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFilm)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FilmsViewModel()
        {
            _films = new ObservableCollection<Film>();
            LoadDataCommand = new Command(async () => await LoadData());
            FilmSelectedCommand = new Command(async () => await FilmSelected());
            
            AddNewFilmCommand = new Command(async () => await Shell.Current.GoToAsync("AddFilmPage"));

            MessagingCenter.Subscribe<AddFilmsViewModel>(this, "refresh", async (sender) => await LoadData());

            Task.Run(LoadData);
        }

        private async Task FilmSelected()
        {
            if (SelectedFilm == null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                { "film", SelectedFilm }
            };

            await Shell.Current.GoToAsync("ViewFilmsPage", navigationParameter);

            MainThread.BeginInvokeOnMainThread(() => SelectedFilm = null);
        }

        public ObservableCollection<Film> Films
        {
            get => _films;
            set => _films = value;
        }

        public ICommand LoadDataCommand { get; private set; }

        public ICommand FilmSelectedCommand { get; private set; }

        public ICommand AddNewFilmCommand { get; private set; }


        public async Task LoadData()
        {
            if (IsBusy)
                return;

            try
            {
                IsRefreshing = true;
                IsBusy = true;

                var filmsCollection = db2.GetFilms();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    Films.Clear();

                    foreach (Film film in filmsCollection)
                    {
                        Films.Add(film);
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

