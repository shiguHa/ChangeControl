using ChangeControl.ViewModels;
using Microsoft.UI.Xaml;
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

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // ここにクリックイベントの処理を書く
        RawTreeVIew.SelectedItems.ToList();
    }
}
