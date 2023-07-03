using MauiAppProba.Models;
using MauiAppProba.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiAppProba;

public partial class FilmsPage : ContentPage
{
    public FilmsPage()
	{
        InitializeComponent();
        BindingContext = new FilmsViewModel();
        //Shell.SetSearchHandler(this, new BookSearchHandler
        //{
        //    Placeholder = "Enter search term",
        //    ShowsResults = true,
        //    DisplayMemberName = "Title"
        //});
    }

    private async void OnAddFilmClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddFilmPage());
    }
    
    private void OnTextFind(object sender, EventArgs e)
    {

    }

    private void OnStatePick(object sender, EventArgs e)
    {
        Picker picker = (Picker)sender;
        Film a = (Film)((Picker)sender).BindingContext;
        a.State = picker.SelectedItem.ToString();
        db2.UpdateFilm(a);
    }
}

