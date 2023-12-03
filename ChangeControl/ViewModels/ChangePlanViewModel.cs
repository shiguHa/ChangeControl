using System;
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
        TreeViewDataSource.Add(new TreeViewItemSource { Name = "Root", IsSelected=true });

        var rootItem = new TreeViewItemSource { Name = "Rxxxx" };
        TreeViewDataSource.Add(rootItem);

        var child1 = new TreeViewItemSource { Name = "Rxxxx-1", Parent = rootItem };
        rootItem.Children.Add(child1);

        var grandChild1 = new TreeViewItemSource { Name = "Rxxxx-1", Parent = child1 };
        child1.Children.Add(grandChild1);

        var grandChild2 = new TreeViewItemSource { Name = "Rxxxx-2", Parent = child1 };
        child1.Children.Add(grandChild2);

        var child2 = new TreeViewItemSource { Name = "Rxxxx-1", Parent = rootItem };
        rootItem.Children.Add(child2);

        var grandChild3 = new TreeViewItemSource { Name = "Rxxxx-1", Parent = child2 };
        child2.Children.Add(grandChild3);

        var grandChild4 = new TreeViewItemSource { Name = "Rxxxx-2", Parent = child2 };
        child2.Children.Add(grandChild4);

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
        //e.AddedItems.OfType<TreeViewItemSource>().ToList().ForEach(item => item.IsSelected = true);
        //e.RemovedItems.OfType<TreeViewItemSource>().ToList().ForEach(item => item.IsSelected = false);


        //// Clear the selected items list
        //TreeViewSelectedDataSource.Clear();

        //var rootItems = new List<TreeViewItemSource>();
        //foreach (var item in TreeViewDataSource)
        //{
        //    var rootItem = GetRootItem(item);
        //    if (!rootItems.Contains(rootItem))
        //    {
        //        rootItems.Add(rootItem);
        //    }
        //}

        //foreach(var item in rootItems)
        //{
        //    TreeViewSelectedDataSource.Add(item);
        // }

    }
    private TreeViewItemSource GetRootItem(TreeViewItemSource item)
    {
        var currentItem = item;
        while (currentItem.Parent != null)
        {
            currentItem = currentItem.Parent;
        }
        return currentItem;
    }


    #endregion


    #region SelectedItems取得する場合
    //https://threeshark3.com/selecteditems-proxy-behavior/
    private IEnumerable<object>? _selectedItems;
    // Binding用のプロパティ
    public IEnumerable<object> SelectedItems
    {
        get => _selectedItems;
        set
        {
        if (_selectedItems != value)
            {   
                _selectedItems = value;
                OnPropertyChanged();
            }
        }
    }

    // 実際に取得する際はこちらのプロパティを用いる
    public IEnumerable<TreeViewItemSource> TreeViewSelectedItems
        => SelectedItems?.
            OfType<TreeViewItemSource>();

    
    #endregion
}

public class TreeViewItemSource
{
    public string Name
    {
        get; set;
    }
    public bool IsSelected
    {
        get; set;
    }
    public ObservableCollection<TreeViewItemSource> Children { get; set; } = new ObservableCollection<TreeViewItemSource>();
    public TreeViewItemSource Parent
    {
        get; set;
    }
    public override string ToString()
    {
        return Name;
    }
}
