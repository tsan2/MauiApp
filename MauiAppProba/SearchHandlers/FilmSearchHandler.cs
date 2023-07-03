using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppProba
{
    internal class FilmSearchHandler : SearchHandler
    {
        public IList<Film> Films { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = db2.GetSFilms(newValue.ToLower());              
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
                { "film", item }
            };

            await Shell.Current.GoToAsync("ViewFilmsPage", navigationParameter);
        }

    }
}
