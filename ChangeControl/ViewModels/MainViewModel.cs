using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ChangeControl.Models;
using ChangeControl.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WinUIEx.Messaging;

namespace ChangeControl.ViewModels;

public partial class MainViewModel : ObservableRecipient
{

    public ObservableCollection<Approval> Approvals
    {
    
           get; set;
       }

    public MainViewModel()
    {
        Approvals = new ObservableCollection<Approval>()
        {
            new Approval()
            {
                Status = "Pending",
                DepartmentName = "IT",
                Name = "John Doe",
                Comment = "Please review this change request"
            },
            new Approval()
            {
                Status = "Pending",
                DepartmentName = "営業",
                Name = "hahaha",
                Comment = "Please review this change request"
            },
        };

    }

    [RelayCommand]
    private void Click()
    {
        Debug.WriteLine("Click");
     }

}
