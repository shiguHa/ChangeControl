using ChangeControl.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.Views;

public sealed partial class ChangeEvaluatePage : Page
{
    public ChangeEvaluateViewModel ViewModel
    {
        get;
    }

    public ChangeEvaluatePage()
    {
        ViewModel = App.GetService<ChangeEvaluateViewModel>();
        InitializeComponent();
    }
}
