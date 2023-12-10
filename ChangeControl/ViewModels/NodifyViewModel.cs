using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ChangeControl.ViewModels;

public partial class NodifyViewModel : ObservableRecipient
{

    public ObservableCollection<NodeModel> Nodes { get; } = new ObservableCollection<NodeModel>();
    public NodifyViewModel()
    {
        Nodes.Add(new NodeModel { Title = "Welcome" });
    }
}

public class NodeModel
{
    public string Title
    {
        get; set;
    }
}

