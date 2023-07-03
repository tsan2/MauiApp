using MauiAppProba.Models;
using MauiAppProba.ViewModels;
using System.Diagnostics;

namespace MauiAppProba;

[QueryProperty("FilmToDisplay", "film")]
public partial class AddFilmPage : ContentPage
{
    public static bool IsRefreshingg = false;

    AddFilmsViewModel viewModel;
    public AddFilmPage()
	{
		InitializeComponent();

        viewModel = new AddFilmsViewModel();
        BindingContext = viewModel;
        DeleteButton.IsEnabled = false;
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
            viewModel.Title = _filmToDisplay.Title;
            viewModel.Description = _filmToDisplay.Description;
            viewModel.Authors = _filmToDisplay.Authors;
            viewModel.Genre = _filmToDisplay.Genre;
            viewModel.Relesed_year = _filmToDisplay.Relesed_year;
            viewModel.State = _filmToDisplay.State;
            viewModel.Icon_file = _filmToDisplay.Icon_file;
            viewModel.Path_file = _filmToDisplay.Path_file;
            if (!string.IsNullOrWhiteSpace(viewModel.Id.ToString()))
            {
                DeleteButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
            }
        }
    }

    private async void OnClickedCancelButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    public async void OnClickedSaveButton(object sender, EventArgs e)
    {
        //Book book = new Book();
        //book.Title = EntryTitle.Text;
        //book.Description = EditorDescription.Text;
        //book.Authors = EntryAuthors.Text;
        //try
        //{
        //    book.Relesed_year = int.Parse(EntryRelesed.Text);
        //}
        //catch
        //{
        //    book.Relesed_year = 0;
        //}
        //if (pickerGenre.SelectedIndex != -1)
        //{
        //    book.Genre = (string)pickerGenre.ItemsSource[pickerGenre.SelectedIndex];
        //}
        //else
        //{
        //    book.Genre = null;
        //}

        //if (pickerState.SelectedIndex != -1)
        //{
        //    book.State = (string)pickerState.ItemsSource[pickerState.SelectedIndex];
        //}
        //else
        //{
        //    book.State = null;
        //}

        //if (!string.IsNullOrEmpty(PathEntry.Text) && !string.IsNullOrEmpty(PathEntry.Placeholder))
        //{
        //    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        //    //string path = Application.StartPath;

        //    File.Copy(PathEntry.Text, path + @"\" + PathEntry.Placeholder, true);

        //    book.Icon_file = PathEntry.Placeholder;
        //}
        //else
        //{
        //    book.Icon_file = "default.png";
        //}


        //int result = db2.AddBook(book);
        //if (result == 0)
        //{
        //    await DisplayAlert("Error", "Some Error", "OK");
        //    await Navigation.PopAsync();
        //}
        //else
        //{
        //    IsRefreshingg = true;
        //}
    }

    private async void OnClickedIconButton(object sender, EventArgs e)
    {
        var FileResult = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images
        });

        try
        {
            PathEntry.Placeholder = FileResult.FileName;
            PathEntry.Text = FileResult.FullPath + "  " + FileResult.FileName;
        }
        catch (NullReferenceException)
        {
            PathEntry.Placeholder = null;
            PathEntry.Text = null;
        }
    }

    private async Task<FileResult> askFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }
        return null;
    }
}

