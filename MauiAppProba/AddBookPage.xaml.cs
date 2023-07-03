//using MauiAppProba.Models;
//using MauiAppProba.ViewModels;
//using System.Diagnostics;

//namespace MauiAppProba;

//[QueryProperty("BookToDisplay", "book")]
//public partial class AddBookPage : ContentPage
//{
//    public static bool IsRefreshingg = false;

//    AddBooksViewModel viewModel;
//    public AddBookPage()
//	{
//		InitializeComponent();

//        viewModel = new AddBooksViewModel();
//        BindingContext = viewModel;
//        DeleteButton.IsEnabled = false;
//    }

//    Book _bookToDisplay;
//    public Book BookToDisplay
//    {
//        get => _bookToDisplay;
//        set
//        {
//            if (_bookToDisplay == value)
//                return;

//            _bookToDisplay = value;

//            viewModel.Id = _bookToDisplay.Id;
//            viewModel.Title = _bookToDisplay.Title;
//            viewModel.Description = _bookToDisplay.Description;
//            viewModel.Authors = _bookToDisplay.Authors;
//            viewModel.Genre = _bookToDisplay.Genre;
//            viewModel.Relesed_year = _bookToDisplay.Relesed_year;
//            viewModel.State = _bookToDisplay.State;
//            viewModel.Icon_file = _bookToDisplay.Icon_file;
//            viewModel.Path_file = _bookToDisplay.Path_file;
//            if (!string.IsNullOrWhiteSpace(viewModel.Id.ToString()))
//            {
//                DeleteButton.IsEnabled = true;
//            }
//            else
//            {
//                DeleteButton.IsEnabled = false;
//            }
//        }
//    }

//    private async void OnClickedCancelButton(object sender, EventArgs e)
//    {
//        await Navigation.PopAsync();
//    }

//    public async void OnClickedSaveButton(object sender, EventArgs e)
//    {
//     //uy
//    }

//    private async void OnClickedIconButton(object sender, EventArgs e)
//    {
//        var FileResult = await FilePicker.PickAsync(new PickOptions
//        {
//            FileTypes = FilePickerFileType.Images
//        });

//        try
//        {
//            PathEntry.Placeholder = FileResult.FileName;
//            PathEntry.Text = FileResult.FullPath + "  " + FileResult.FileName;
//        }
//        catch (NullReferenceException)
//        {
//            PathEntry.Placeholder = null;
//            PathEntry.Text = null;
//        }
//    }

//    private async Task<FileResult> askFile(PickOptions options)
//    {
//        try
//        {
//            var result = await FilePicker.Default.PickAsync(options);
//            if (result != null)
//            {
//                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
//                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
//                {
//                    using var stream = await result.OpenReadAsync();
//                    var image = ImageSource.FromStream(() => stream);
//                }
//            }

//            return result;
//        }
//        catch (Exception ex)
//        {
//            // The user canceled or something went wrong
//        }
//        return null;
//    }
//}

