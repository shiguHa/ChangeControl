using ChangeControl.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.Views;

public sealed partial class NodifyPage : Page
{
    public NodifyViewModel ViewModel
    {
        get;
    }

    public NodifyPage()
    {
        ViewModel = App.GetService<NodifyViewModel>();
        InitializeComponent();
    }
}
