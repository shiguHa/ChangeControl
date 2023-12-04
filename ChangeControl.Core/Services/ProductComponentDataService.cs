using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Core.Models;

namespace ChangeControl.Core.Services;
public class ProductComponentDataService
{

    public static List<ProductComponent> GenerateSampleData()
    {
        var companies = CompanyDataService.GenerateCompanyData();

        var components = new List<ProductComponent>
        {
            new ProductComponent { ID = "PC0001", Name = "マイクロプロセッサ", Supplier = companies[0] },
            new ProductComponent { ID = "PC0002", Name = "コンデンサ", Supplier = companies[1] },
            new ProductComponent { ID = "PC0003", Name = "トランジスタ", Supplier = companies[2] },
            new ProductComponent { ID = "PC0004", Name = "ダイオード", Supplier = companies[3] },
            new ProductComponent { ID = "PC0005", Name = "抵抗器", Supplier = companies[4] },
            new ProductComponent { ID = "PC0006", Name = "ICチップ", Supplier = companies[5] },
            new ProductComponent { ID = "PC0007", Name = "インダクタ", Supplier = companies[6] },
            new ProductComponent { ID = "PC0008", Name = "センサー", Supplier = companies[7] },
            new ProductComponent { ID = "PC0009", Name = "コネクタ", Supplier = companies[8] },
            new ProductComponent { ID = "PC0010", Name = "スイッチ", Supplier = companies[9] },
            new ProductComponent { ID = "PC0011", Name = "LED", Supplier = companies[10] },
            new ProductComponent { ID = "PC0012", Name = "ヒューズ", Supplier = companies[11] },
            new ProductComponent { ID = "PC0013", Name = "リレー", Supplier = companies[12] },
            new ProductComponent { ID = "PC0014", Name = "バッテリー", Supplier = companies[13] },
            new ProductComponent { ID = "PC0015", Name = "エンコーダ", Supplier = companies[14] },
            new ProductComponent { ID = "PC0016", Name = "アクチュエータ", Supplier = companies[15] },
            new ProductComponent { ID = "PC0017", Name = "バルブ", Supplier = companies[16] },
            new ProductComponent { ID = "PC0018", Name = "ポテンショメータ", Supplier = companies[17] },
            new ProductComponent { ID = "PC0019", Name = "ヒューズホルダ", Supplier = companies[18] },
            new ProductComponent { ID = "PC0020", Name = "エネルギー", Supplier = companies[19] }
        };

        // 階層構造を設定（3層まで）
        if (components.Count >= 3)
        {
            components[0].Children = new List<ProductComponent> { components[1] };
            components[1].Children = new List<ProductComponent> { components[2] };
        }

        return components;
    }
}
