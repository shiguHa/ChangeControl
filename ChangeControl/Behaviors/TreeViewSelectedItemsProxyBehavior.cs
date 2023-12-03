using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactivity;

namespace ChangeControl.Behaviors;
internal class TreeViewSelectedItemsProxyBehavior : Behavior<TreeView>
{
    #region SelectedItemsProxy
    public IEnumerable<object> SelectedItemsProxy
    {
        get
        {
            return (IEnumerable<object>)GetValue(SelectedItemsProxyProperty);
        }
        set
        {
            SetValue(SelectedItemsProxyProperty, value);
        }
    }

    public static readonly DependencyProperty SelectedItemsProxyProperty =
        DependencyProperty.Register(
            nameof(SelectedItemsProxy), 
            typeof(IEnumerable<object>), 
            typeof(TreeViewSelectedItemsProxyBehavior),
            new PropertyMetadata(Enumerable.Empty<object>()));

#endregion
    protected override void OnAttached()
    {
    
           base.OnAttached();
           AssociatedObject.SelectionChanged += OnSelectionChanged;
       }

    protected override void OnDetaching()
    {
    
           base.OnDetaching();
           AssociatedObject.SelectionChanged -= OnSelectionChanged;
       }

    private void OnSelectionChanged(TreeView sender, TreeViewSelectionChangedEventArgs args)
    {
        this.SetValue(SelectedItemsProxyProperty, sender.SelectedItems);
    
        
    }
}
