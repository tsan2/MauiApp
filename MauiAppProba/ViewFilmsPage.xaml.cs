using MauiAppProba.Models;
using MauiAppProba.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiAppProba;

[QueryProperty("FilmToDisplay", "film")]
public partial class ViewFilmsPage : ContentPage
{
    public static bool IsRefreshingg = false;

    AddFilmsViewModel viewModel;

    public ViewFilmsPage()
	{
        InitializeComponent();
        viewModel = new AddFilmsViewModel();
        BindingContext = viewModel;
    }

    Film _filmToDisplay;
    public Film FilmToDisplay
    {
        get => _filmToDisplay;
        set
        {
            if (_filmToDisplay == value)
                return;

            _filmToDisplay = value;

            viewModel.Id = _filmToDisplay.Id;
            viewModel.EditFilm = _filmToDisplay;
            viewModel.Title = _filmToDisplay.Title;
            viewModel.Description = _filmToDisplay.Description;
            viewModel.Authors = _filmToDisplay.Authors;
            viewModel.Genre = _filmToDisplay.Genre;
            viewModel.Relesed_year = _filmToDisplay.Relesed_year;
            viewModel.State = _filmToDisplay.State;
            viewModel.Icon_file = _filmToDisplay.Icon_file;
            viewModel.Path_file = _filmToDisplay.Path_file;
        }
    }
}

