using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.ViewModels;

namespace ChangeControl.Models;

public interface ITreeViewDataItem
{

    string Name
    {
    get; set; }
    bool IsSelected
    {
    get; set; }
    ObservableCollection<ITreeViewDataItem> Children
    {
    get; set; }
    ITreeViewDataItem Parent
    {
    get; set; }
}


public class TreeViewDataItem : ITreeViewDataItem
{

    public string Name
    {
        get; set;
    }
    public bool IsSelected
    {
        get; set;
    }
    public ObservableCollection<ITreeViewDataItem> Children { get; set; } = new ObservableCollection<ITreeViewDataItem>();
    public ITreeViewDataItem Parent
    {
        get; set;
    }

}
