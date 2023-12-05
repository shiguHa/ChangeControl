using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Models;
using ChangeControl.ViewModels;

namespace ChangeControl.Helpers;
internal class BuildTreeViewHelper
{
    // このメソッドは、製品のリストからツリービューを作成します。
    public static ObservableCollection<TreeViewItemSource> BuildTreeView(List<Product> products)
    {
        var container = new ObservableCollection<TreeViewItemSource>();

        // 製品を製品タイプ名の最初の部分でグループ化します。
        var productGroups = products.GroupBy(p => p.ProductTypeName.Split('-')[0]);

        // 各グループに対して、ルートツリービューアイテムを作成し、それをコンテナに追加します。
        foreach (var group in productGroups)
        {
            var rootItem = new TreeViewItemSource { Name = group.Key };
            container.Add(rootItem);

            // グループ内の各製品に対して、ルートアイテムに子ノードを追加します。
            foreach (var product in group)
            {
                AddChildNodes(rootItem, product.ProductTypeName);
            }
        }

        return container;
    }

    // このメソッドは、製品タイプ名に基づいて親ノードに子ノードを追加します。
    private static void AddChildNodes(TreeViewItemSource parent, string productTypeName)
    {
        // 製品タイプ名を部分に分割します。
        var parts = productTypeName.Split('-');
        var currentName = parent.Name;

        // 各部分に対して、それを親ノードの子ノードとして追加します。
        for (int i = 1; i < parts.Length; i++)
        {
            // 現在の名前を新しい部分で更新します。
            currentName += "-" + parts[i];

            // 現在の名前の子がすでに存在するかどうかを確認します。
            var child = parent.Children.FirstOrDefault(c => c.Name == currentName);

            // 子が存在しない場合、新しい子ノードを作成し、それを親に追加します。
            if (child == null)
            {
                child = new TreeViewItemSource { Name = currentName, Parent = parent };
                parent.Children.Add(child);
            }

            // 次の反復のために親を子に設定します。
            parent = child;
        }
    }

}







//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ChangeControl.Models;
//using ChangeControl.ViewModels;

//namespace ChangeControl.Helpers;
//internal class BuildTreeViewHelper
//{
//    // このメソッドは、任意の型のリストからツリービューを作成します。
//    public static ObservableCollection<TreeViewItemSource> BuildTreeView<T>(List<T> items, Func<T, string> getTypeName)
//    {
//        // ツリービューアイテムの新しいコンテナを作成します。
//        var container = new ObservableCollection<TreeViewItemSource>();

//        // アイテムをタイプ名の最初の部分でグループ化します。
//        var itemGroups = items.GroupBy(getTypeName).GroupBy(name => name.Split('-')[0]);

//        // 各グループに対して、ルートツリービューアイテムを作成し、それをコンテナに追加します。
//        foreach (var group in itemGroups)
//        {
//            var rootItem = new TreeViewItemSource { Name = group.Key };
//            container.Add(rootItem);

//            // グループ内の各アイテムに対して、ルートアイテムに子ノードを追加します。
//            foreach (var item in group)
//            {
//                AddChildNodes(rootItem, getTypeName(item));
//            }
//        }

//        // ビルドされたツリービューを含むコンテナを返します。
//        return container;
//    }

//    // このメソッドは、タイプ名に基づいて親ノードに子ノードを追加します。
//    private static void AddChildNodes(TreeViewItemSource parent, string typeName)
//    {
//        // タイプ名を部分に分割します。
//        var parts = typeName.Split('-');
//        var currentName = parent.Name;

//        // 各部分に対して、それを親ノードの子ノードとして追加します。
//        for (int i = 1; i < parts.Length; i++)
//        {
//            // 現在の名前を新しい部分で更新します。
//            currentName += "-" + parts[i];

//            // 現在の名前の子がすでに存在するかどうかを確認します。
//            var child = parent.Children.FirstOrDefault(c => c.Name == currentName);

//            // 子が存在しない場合、新しい子ノードを作成し、それを親に追加します。
//            if (child == null)
//            {
//                child = new TreeViewItemSource { Name = currentName, Parent = parent };
//                parent.Children.Add(child);
//            }

//            // 次の反復のために親を子に設定します。
//            parent = child;
//        }
//    }

//}
