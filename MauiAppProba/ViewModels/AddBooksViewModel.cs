using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using MauiAppProba.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//namespace MauiAppProba.ViewModels
//{
//    class AddBooksViewModel
//    {
    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    public int id;
    //    public string title;
    //    public string description;
    //    public string authors;
    //    public int relesed_year;
    //    public string genre;
    //    public string icon_file;
    //    public string state;

    //    public ICommand SaveCommand { get; private set; }

    //    public ICommand DoneEditingCommand { get; private set; }

    //    public ICommand DeleteCommand { get; private set; }

    //    [PrimaryKey, AutoIncrement]
    //    public int Id
    //    {
    //        get => id;
    //        set
    //        {
    //            if (id != value)
    //            {
    //                id = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
    //            }
    //        }
    //    }

    //    public string Title
    //    {
    //        get => title;
    //        set
    //        {
    //            if (title != value)
    //            {
    //                title = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
    //            }
    //        }
    //    }

    //    public string Description
    //    {
    //        get => description;
    //        set
    //        {
    //            if (description != value)
    //            {
    //                description = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
    //            }
    //        }
    //    }

    //    public string Authors
    //    {
    //        get => authors;
    //        set
    //        {
    //            if (authors != value)
    //            {
    //                authors = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Authors)));
    //            }
    //        }
    //    }

    //    public int Relesed_year
    //    {
    //        get => relesed_year;
    //        set
    //        {
    //            if (relesed_year != value)
    //            {
    //                relesed_year = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Relesed_year)));
    //            }
    //        }
    //    }

    //    public string Genre
    //    {
    //        get => genre;
    //        set
    //        {
    //            if (genre != value)
    //            {
    //                genre = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Genre)));
    //            }
    //        }
    //    }

    //    public string path_file;
    //    public string Path_file
    //    {
    //        get => path_file;
    //        set
    //        {
    //            if (path_file != value)
    //            {
    //                path_file = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Path_file)));
    //            }
    //        }
    //    }

    //    public string Icon_file
    //    {
    //        get => icon_file;
    //        set
    //        {
    //            if (icon_file != value)
    //            {
    //                icon_file = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Icon_file)));
    //            }
    //        }
    //    }

    //    public string State
    //    {
    //        get => state;
    //        set
    //        {
    //            if (state != value)
    //            {
    //                state = value;
    //                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
    //            }
    //        }
    //    }

    //    private bool _isRefreshing = false;
    //    public bool IsRefreshing
    //    {
    //        get => _isRefreshing;
    //        set
    //        {
    //            if (_isRefreshing == value)
    //                return;

    //            _isRefreshing = value;
    //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
    //        }
    //    }

    //    public AddBooksViewModel()
    //    {
    //        DoneEditingCommand = new Command(async () => await DoneEditing());
    //        SaveCommand = new Command(async () => await SaveData());
    //        DeleteCommand = new Command(async () => await DeleteBook());
    //        BookEditCommand = new Command(async () => await BookEdit());
    //    }

    //    private Book _editBook;
    //    public Book EditBook
    //    {
    //        get => _editBook;
    //        set
    //        {
    //            if (_editBook == value)
    //                return;

    //            _editBook = value;

    //            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(EditBook)));
    //        }
    //    }

    //    public ICommand BookEditCommand { get; private set; }

    //    public async Task BookEdit()
    //    {
    //        if (EditBook == null)
    //            return;

    //        var navigationParameter = new Dictionary<string, object>()
    //        {
    //            { "book", EditBook }
    //        };

    //        await Shell.Current.GoToAsync("AddBookPage", navigationParameter);

    //        MainThread.BeginInvokeOnMainThread(() => EditBook = null);

    //    }

    //    private async Task SaveData()
    //    {
    //        bool a = false;
    //        List<Book> booksAll = db2.GetBooks();
    //        foreach (Book book in booksAll)
    //        {
    //            if (book.Id == Id) {
    //                a = true; break;
    //            }
    //        }
    //        if (a == false)
    //            await InsertBook();
    //        else
    //            await UpdateBook();
    //    }

    //    private async Task InsertBook()
    //    {
    //        Book book = new Book();
    //        book.Title = Title;
    //        book.Description = Description;
    //        book.Authors = Authors;
    //        try
    //        {
    //            book.Relesed_year = Relesed_year;
    //        }
    //        catch
    //        {
    //            book.Relesed_year = 0;
    //        }

    //        if (Genre != null)
    //        {
    //            book.Genre = Genre;
    //        }
    //        else
    //        {
    //            book.Genre = null;
    //        }


    //        if (State != null)
    //        {
    //            book.State = State;
    //        }
    //        else
    //        {
    //            book.State = null;
    //        }

    //        book.Path_file = path_file;
    //        Icon_file = path_file.Split("  ")[1];
    //        Path_file = path_file.Split("  ")[0];

    //        if (!string.IsNullOrEmpty(Path_file) && !string.IsNullOrEmpty(Icon_file))
    //        {
    //            string path = System.IO.Path.GetDirectoryName(System.AppContext.BaseDirectory);
    //            //string path = Application.StartPath;

    //            File.Copy(Path_file, path + @"\" + Icon_file, true);

    //            book.Icon_file = Icon_file;
    //        }
    //        else
    //        {
    //            book.Icon_file = "default.png";
    //        }

    //        int result = db2.AddBook(book);
            

    //        MessagingCenter.Send(this, "refresh");

    //        await Shell.Current.GoToAsync("..");
    //    }

    //    private async Task UpdateBook()
    //    {
    //        Book book = new Book();
    //        book.Title = Title;
    //        book.Id = Id;
    //        book.Description = Description;
    //        book.Authors = Authors;
    //        try
    //        {
    //            book.Relesed_year = Relesed_year;
    //        }
    //        catch
    //        {
    //            book.Relesed_year = 0;
    //        }

    //        book.Genre = Genre;

    //        book.State = State;

    //            book.Path_file = path_file;
    //            Icon_file = path_file.Split("  ")[1];
    //            Path_file = path_file.Split("  ")[0];

    //        if (!string.IsNullOrEmpty(Path_file) && !string.IsNullOrEmpty(Icon_file))
    //        {
    //            string path = System.IO.Path.GetDirectoryName(System.AppContext.BaseDirectory);
    //            //string path = Application.StartPath;

    //            if (!File.Exists(path + @"\" + Icon_file)) { 

    //            File.Copy(Path_file, path + @"\" + Icon_file, true);

    //            }
    
    //            book.Icon_file = Icon_file;
    //        }
    //        else
    //        {
    //             book.Icon_file = "default.png";
    //        }
            
           

    //        int result = db2.UpdateBook(book);

    //        MessagingCenter.Send(this, "refresh");

    //        await Shell.Current.GoToAsync("..");
    //        await Shell.Current.GoToAsync("..");
    //    }

    //    private async Task DeleteBook()
    //    {
    //        if (string.IsNullOrWhiteSpace(Id.ToString()))
    //            return;

    //        db2.DeleteBook(Id);

    //        MessagingCenter.Send(this, "refresh");

    //        await Shell.Current.GoToAsync("..");
    //        await Shell.Current.GoToAsync("..");
    //    }

    //    private async Task DoneEditing()
    //    {
    //        await Shell.Current.GoToAsync("..");
    //    }
    //}
//}
