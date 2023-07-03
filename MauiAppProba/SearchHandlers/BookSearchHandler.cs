using System;
using MauiAppProba.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProba
{
    internal class BookSearchHandler : SearchHandler
    {
        public IList<Book> Books { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = db2.GetSBooks(newValue.ToLower());              
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // Let the animation complete
            await Task.Delay(1000);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
            // The following route works because route names are unique in this app.
            var navigationParameter = new Dictionary<string, object>()
            {
                { "book", item }
            };

            await Shell.Current.GoToAsync("ViewBooksPage", navigationParameter);
        }

    }
}
