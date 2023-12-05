using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.ViewModels;

namespace ChangeControl.Models;
public class Product
{
    public string ProductTypeName
    {
    
           get; set;
       }

    public string Category
    {
    
           get; set;
       }

    public string ExpenseCode
    {
           get; set;
          }

    private void Example()
    {
       List<Product> products = new List<Product>()
       {
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-10" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-100" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-101" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-1" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-20" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-20-1" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-20-50" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-20-10" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X1111-10" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X2121" },
           new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X2121-211-123" },
            new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X2121-211-124" },
             new Product() { Category = "Food", ExpenseCode = "123", ProductTypeName = "X2121-211-125" },
           // more items...
       };


        ObservableCollection<TreeViewItemSource> container = new ObservableCollection<TreeViewItemSource>();

        var rootItem = new TreeViewItemSource { Name = "X1111" };
        container.Add(rootItem);

        rootItem.Children.Add(new TreeViewItemSource { Name = "X1111-1", Parent = rootItem });
        rootItem.Children.Add(new TreeViewItemSource { Name = "X1111-10", Parent = rootItem });
        rootItem.Children.Add(new TreeViewItemSource { Name = "X1111-100", Parent = rootItem });
        rootItem.Children.Add(new TreeViewItemSource { Name = "X1111-101", Parent = rootItem });

        var child1 = new TreeViewItemSource { Name = "X1111-20", Parent = rootItem };
        child1.Children.Add(new TreeViewItemSource { Name = "X1111-20-1", Parent = child1 });
        child1.Children.Add(new TreeViewItemSource { Name = "X1111-20-10", Parent = child1 });
        child1.Children.Add(new TreeViewItemSource { Name = "X1111-20-50", Parent = child1 });
    }

}

