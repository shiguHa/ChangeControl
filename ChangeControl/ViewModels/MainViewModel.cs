using System.Diagnostics;
using System.Runtime.InteropServices;
using ChangeControl.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WinUIEx.Messaging;

namespace ChangeControl.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    public MainViewModel()
    {
    }

    [RelayCommand]
    private async void Click()
    {
        WeakReferenceMessenger.Default.Register<string>(this, (r, m) => {
            Debug.WriteLine($"Message received: {m}");
        });
        var window = new LeanSubWindowEx();
        var monitor = new WindowMessageMonitor(window);
        window.Activate();

     }

}
