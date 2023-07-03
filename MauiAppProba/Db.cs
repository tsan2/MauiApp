using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MauiAppProba
{
    [SQLite.Table("Book")]
    public class Book33
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public string Path_file { get; set; }

        public int Relesed_year { get; set; }

        public string Genre { get; set; }

        public string Icon_file { get; set; }

        public string State { get; set; }
    }

    [SQLite.Table("Film")]
    public class Film
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public string Path_file { get; set; }

        public int Relesed_year { get; set; }

        public string Genre { get; set; }

        public string Icon_file { get; set; }

        public string State { get; set; }
    }
}
