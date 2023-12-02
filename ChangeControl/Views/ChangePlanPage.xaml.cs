using ChangeControl.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.Views;

public sealed partial class ChangePlanPage : Page
{
    public ChangePlanViewModel ViewModel
    {
        get;
    }

    public ChangePlanPage()
    {
        ViewModel = App.GetService<ChangePlanViewModel>();
        InitializeComponent();
    }
}
