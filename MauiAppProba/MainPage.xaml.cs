namespace MauiAppProba;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent(); 
    }

    private async void OnBooksClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//BooksPage");
    }

    private void OnFilmsClicked(object sender, EventArgs e)
    {

    }

    private void OnAnimeClicked(object sender, EventArgs e)
    {

    }
}

