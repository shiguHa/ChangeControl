using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ChangeControl.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace ChangeControl.ViewModels;

//https://stackoverflow.com/questions/64654260/bind-checkbox-to-enum-value
public partial class ChangePlanViewModel : ObservableRecipient
{

    [ObservableProperty]
    private string? _testText;


    public ObservableCollection<EnumForCheckBox<ChangeComponentEnum>> EnumCollection{get;}

    public ObservableCollection<TreeViewItemSource> TreeViewDataSource{ get; }
    public ObservableCollection<TreeViewItemSource> TreeViewSelectedDataSource{get;}




    private DispatcherTimer _timer = new();

    public ChangePlanViewModel()
    {
        TestText = "Hello World";

        EnumCollection = new ObservableCollection<EnumForCheckBox<ChangeComponentEnum>>(Enum.GetValues(typeof(ChangeComponentEnum))
                .Cast<ChangeComponentEnum>()
                .Select(x => new EnumForCheckBox<ChangeComponentEnum> { Value = x, }));


        TreeViewDataSource = new ObservableCollection<TreeViewItemSource>();
        TreeViewSelectedDataSource = new ObservableCollection<TreeViewItemSource>();
        TreeViewDataSource.Add(new TreeViewItemSource { Name = "Root" });

        TreeViewDataSource.Add(new TreeViewItemSource 
        { 
            Name = "Rxxxx" ,
            Children =
            {
                new TreeViewItemSource { Name = "Rxxxx-1" },
                new TreeViewItemSource { Name = "Rxxxx-2" },
                new TreeViewItemSource { Name = "Rxxxx-3" },
            }
        });

        TreeViewDataSource.Add(new TreeViewItemSource
        {
            Name = "Rxxxx",
            Children =
            {
                new TreeViewItemSource { Name = "Rxxxx-1", 
                    Children=
                    {
                        new TreeViewItemSource { Name = "Rxxxx-1" },
                        new TreeViewItemSource { Name = "Rxxxx-2" },
                    } 
                },
                new TreeViewItemSource { Name = "Rxxxx-1",
                    Children=
                    {
                        new TreeViewItemSource { Name = "Rxxxx-1" },
                        new TreeViewItemSource { Name = "Rxxxx-2" },
                    }
                }
            }
        });

        #region Debug用
        _timer.Interval = TimeSpan.FromSeconds(5);
        _timer.Tick += (s, e) =>
        {
                   TestText = "Hello World " + DateTime.Now.ToString();
               };
        _timer.Start();
        #endregion
    }


    #region TreeViewSelectionChangedCommand
    private ICommand _treeViewSelectionChangedCommand;
    public ICommand TreeViewSelectionChangedCommand => this._treeViewSelectionChangedCommand ?? (this._treeViewSelectionChangedCommand =
            new RelayCommand<TreeViewSelectionChangedEventArgs>(OnTreeViewSelectionChanged));

    public void OnTreeViewSelectionChanged(TreeViewSelectionChangedEventArgs e)
    {
        // SelectionChangedイベントが発生したときの処理をここに書く
        Debug.WriteLine("TreeView_SelectionChanged!!!!!!!!!");

        foreach (var item in e.AddedItems)
        {
            if (item is TreeViewItemSource treeViewItem)
            {
                TreeViewSelectedDataSource.Add(treeViewItem);
            }
        }
    }

    #endregion



}

public class TreeViewItemSource
{
    public string Name
    {
        get; set;
    }
    public ObservableCollection<TreeViewItemSource> Children { get; set; } = new ObservableCollection<TreeViewItemSource>();

    public override string ToString()
    {
        return Name;
    }
}
