using ChangeControl.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.ViewModels;

public partial class ChangePlanViewModel : ObservableRecipient
{

    [ObservableProperty]
    private string? _testText;


    public List<EnumForCheckBox<ChangeComponentEnum>> EnumCollection
    {
        get; set;
    }

    public ChangePlanViewModel()
    {
        TestText = "Hello World";
        EnumCollection = Enum.GetValues(typeof(ChangeComponentEnum))
                .Cast<ChangeComponentEnum>()
                .Select(x => new EnumForCheckBox<ChangeComponentEnum> { Value = x, }).ToList();
    }
}
