using MauiAppProba.Models;
using MauiAppProba.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiAppProba;

public partial class BooksPage : ContentPage
{
    public BooksPage()
	{
        InitializeComponent();
        BindingContext = new BooksViewModel();
        //Shell.SetSearchHandler(this, new BookSearchHandler
        //{
        //    Placeholder = "Enter search term",
        //    ShowsResults = true,
        //    DisplayMemberName = "Title"
        //});
    }

    private async void OnAddBookClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBookPage());
    }
    
    private void OnTextFind(object sender, EventArgs e)
    {

    }

}

