using ChangeControl.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    private void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        // DataContextの中に入ってる。
        ViewModel.ClickCommand.Execute(null);
    }
}
