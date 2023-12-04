using ChangeControl.ViewModels;

using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.Views;

public sealed partial class ChangeBySupplierPage : Page
{
    public ChangeBySupplierViewModel ViewModel
    {
        get;
    }

    public ChangeBySupplierPage()
    {
        ViewModel = App.GetService<ChangeBySupplierViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
