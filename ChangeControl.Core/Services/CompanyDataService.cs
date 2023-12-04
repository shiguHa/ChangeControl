using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Core.Models;

namespace ChangeControl.Core.Services;
public class CompanyDataService
{


    public static List<Company> GenerateCompanyData()
    {
        List<Company> companies = new List<Company>
        {
           new Company { CompanyID = "FIC0001", CompanyName = "テクコンポーネント株式会社" },
            new Company { CompanyID = "FIC0002", CompanyName = "イノパーツ株式会社" },
            new Company { CompanyID = "FIC0003", CompanyName = "マイクロギア株式会社" },
            new Company { CompanyID = "FIC0004", CompanyName = "エレベートテック株式会社" },
            new Company { CompanyID = "FIC0005", CompanyName = "ネクストジェンコンポーネント株式会社" },
            new Company { CompanyID = "FIC0006", CompanyName = "スウィフトパーツソリューションズ" },
            new Company { CompanyID = "FIC0007", CompanyName = "マックステックイノベーションズ" },
            new Company { CompanyID = "FIC0008", CompanyName = "オプティマルパーツ株式会社" },
            new Company { CompanyID = "FIC0009", CompanyName = "エーペックスギア株式会社" },
            new Company { CompanyID = "FIC0010", CompanyName = "エコパーツ製造株式会社" },
            new Company { CompanyID = "FIC0011", CompanyName = "プレシジョンテックシステムズ" },
            new Company { CompanyID = "FIC0012", CompanyName = "ヴィタテックソリューションズ" },
            new Company { CompanyID = "FIC0013", CompanyName = "メガパーツ株式会社" },
            new Company { CompanyID = "FIC0014", CompanyName = "プロトンコンポーネント株式会社" },
            new Company { CompanyID = "FIC0015", CompanyName = "ギガギアイノベーションズ" },
            new Company { CompanyID = "FIC0016", CompanyName = "ウルトラテックパーツ" },
            new Company { CompanyID = "FIC0017", CompanyName = "テックワイズコンポーネンツ" },
            new Company { CompanyID = "FIC0018", CompanyName = "オムニパーツ株式会社" },
            new Company { CompanyID = "FIC0019", CompanyName = "クオリギアシステムズ" },
            new Company { CompanyID = "FIC0020", CompanyName = "ネクストレベルパーツ株式会社" }
        };

        return companies;
    }
}
