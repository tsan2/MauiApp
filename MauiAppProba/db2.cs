using SQLite;
using MauiAppProba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProba
{
    class db2
    {
        private static SQLiteConnection conn;

        public static void InitDb()
        {
            if (conn != null)
                return;

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            conn = new SQLiteConnection(path + @"\tsan.db");
            conn.CreateTable<Book>();
            conn.CreateTable<Film>();
        }

        public static int AddBook(Book book)
        {
            InitDb();
            int result = conn.Insert(book);
            return result;
        }

        public static List<Book> GetBooks()
        {
            InitDb();
            return conn.Table<Book>().ToList();
        }

        public static int UpdateBook(Book book)
        {
            InitDb();
            int result = 0;
            result = conn.Update(book);
            return result;
        }

        public static int DeleteBook(int id)
        {
            InitDb();
            int result = 0;
            result = conn.Delete<Book>(id);
            return result;
        }

        public static List<Book> GetSBooks(string a)
        {
            InitDb();
            return conn.Table<Book>().ToList()
                    .Where(book => book.Title.ToLower().Contains(a))
                    .ToList<Book>();
        }

        public static List<Film> GetSFilms(string a)
        {
            InitDb();
            return conn.Table<Film>().ToList()
                    .Where(film => film.Title.ToLower().Contains(a))
                    .ToList<Film>();
        }

        public static int AddFilm(Film film)
        {
            InitDb();
            int result = conn.Insert(film);
            return result;
        }

        public static List<Film> GetFilms()
        {
            InitDb();
            return conn.Table<Film>().ToList();
        }

        public static int UpdateFilm(Film film)
        {
            InitDb();
            int result = 0;
            result = conn.Update(film);
            return result;
        }

        public static int DeleteFilm(int id)
        {
            InitDb();
            int result = 0;
            result = conn.Delete<Film>(id);
            return result;
        }
    }
}
