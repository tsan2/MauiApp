using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppProba.ViewModels
{
    class AddFilmsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int id;
        public string title;
        public string description;
        public string authors;
        public int relesed_year;
        public string genre;
        public string icon_file;
        public string state;

        public ICommand SaveCommand { get; private set; }

        public ICommand DoneEditingCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
                }
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

        public string Authors
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

        public int Relesed_year
        {
            get => relesed_year;
            set
            {
                if (relesed_year != value)
                {
                    relesed_year = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Relesed_year)));
                }
            }
        }

        public string Genre
        {
            get => genre;
            set
            {
                if (genre != value)
                {
                    genre = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
                }
            }
        }

        public string path_file;
        public string Path_file
        {
            get => path_file;
            set
            {
                if (path_file != value)
                {
                    path_file = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Path_file)));
                }
            }
        }

        public string Icon_file
        {
            get => icon_file;
            set
            {
                if (icon_file != value)
                {
                    icon_file = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon_file)));
                }
            }
        }

        public string State
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
                }
            }
        }

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

        public AddFilmsViewModel()
        {
            DoneEditingCommand = new Command(async () => await DoneEditing());
            SaveCommand = new Command(async () => await SaveData());
            DeleteCommand = new Command(async () => await DeleteFilm());
            FilmEditCommand = new Command(async () => await FilmEdit());
        }

        private Film _editFilm;
        public Film EditFilm
        {
            get => _editFilm;
            set
            {
                if (_editFilm == value)
                    return;

                _editFilm = value;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(EditFilm)));
            }
        }

        public ICommand FilmEditCommand { get; private set; }

        public async Task FilmEdit()
        {
            if (EditFilm == null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                { "film", EditFilm }
            };

            await Shell.Current.GoToAsync("AddFilmPage", navigationParameter);

            MainThread.BeginInvokeOnMainThread(() => EditFilm = null);

        }

        private async Task SaveData()
        {
            bool a = false;
            List<Film> filmsAll = db2.GetFilms();
            foreach (Film film in filmsAll)
            {
                if (film.Id == Id) {
                    a = true; break;
                }
            }
            if (a == false)
                await InsertFilm();
            else
                await UpdateFilm();
        }

        private async Task InsertFilm()
        {
            Film film = new Film();
            film.Title = Title;
            film.Description = Description;
            film.Authors = Authors;
            try
            {
                film.Relesed_year = Relesed_year;
            }
            catch
            {
                film.Relesed_year = 0;
            }

            if (Genre != null)
            {
                film.Genre = Genre;
            }
            else
            {
                film.Genre = null;
            }


            if (State != null)
            {
                film.State = State;
            }
            else
            {
                film.State = null;
            }

            film.Path_file = path_file;
            Icon_file = path_file.Split("  ")[1];
            Path_file = path_file.Split("  ")[0];

            if (!string.IsNullOrEmpty(Path_file) && !string.IsNullOrEmpty(Icon_file))
            {
                string path = System.IO.Path.GetDirectoryName(System.AppContext.BaseDirectory);
                //string path = Application.StartPath;

                File.Copy(Path_file, path + @"\" + Icon_file, true);

                film.Icon_file = Icon_file;
            }
            else
            {
                film.Icon_file = "default.png";
            }

            int result = db2.AddFilm(film);
            

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }
        
        private async Task UpdateFilm()
        {
            Film film = new Film();
            film.Title = Title;
            film.Id = Id;
            film.Description = Description;
            film.Authors = Authors;
            try
            {
                film.Relesed_year = Relesed_year;
            }
            catch
            {
                film.Relesed_year = 0;
            }

            film.Genre = Genre;

            film.State = State;

                film.Path_file = path_file;
                Icon_file = path_file.Split("  ")[1];
                Path_file = path_file.Split("  ")[0];

            if (!string.IsNullOrEmpty(Path_file) && !string.IsNullOrEmpty(Icon_file))
            {
                string path = System.IO.Path.GetDirectoryName(System.AppContext.BaseDirectory);
                //string path = Application.StartPath;

                if (!File.Exists(path + @"\" + Icon_file)) { 

                File.Copy(Path_file, path + @"\" + Icon_file, true);

                }
    
                film.Icon_file = Icon_file;
            }
            else
            {
                 film.Icon_file = "default.png";
            }



            int result = db2.UpdateFilm(film);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync("..");
        }

        private async Task DeleteFilm()
        {
            if (string.IsNullOrWhiteSpace(Id.ToString()))
                return;

            db2.DeleteFilm(Id);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync("..");
        }

        private async Task DoneEditing()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
