using MauiAppProba.Models;
using MauiAppProba.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiAppProba;

[QueryProperty("BookToDisplay", "book")]
public partial class ViewBooksPage : ContentPage
{
    public static bool IsRefreshingg = false;

    BooksViewModel viewModel;

    public ViewBooksPage()
	{
        InitializeComponent();
        viewModel = new BooksViewModel();
        BindingContext = viewModel;
    }

    Book _bookToDisplay;
    public Book BookToDisplay
    {
        get => _bookToDisplay;
        set
        {
            if (_bookToDisplay == value)
                return;

            _bookToDisplay = value;

            viewModel.Title = _bookToDisplay.Title;
            viewModel.Description = _bookToDisplay.Description;
            viewModel.Authors = _bookToDisplay.Authors;
            viewModel.Categories = _bookToDisplay.Categories;
            viewModel.PublishedDate = _bookToDisplay.PublishedDate;
        }
    }
}

