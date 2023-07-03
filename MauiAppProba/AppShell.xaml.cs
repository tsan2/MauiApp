namespace MauiAppProba;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("AddBookPage", typeof(AddBookPage));
        Routing.RegisterRoute("ViewBooksPage", typeof(ViewBooksPage));
        Routing.RegisterRoute("AddFilmPage", typeof(AddFilmPage));
        Routing.RegisterRoute("ViewFilmsPage", typeof(ViewFilmsPage));
    }
}
