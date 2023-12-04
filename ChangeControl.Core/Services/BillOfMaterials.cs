using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Core.Models;

namespace ChangeControl.Core.Services;
public class BillOfMaterialsDataService
{
    public List<BillOfMaterials> GenerateSampleData()
    {
        var companies = CompanyDataService.GenerateCompanyData();

        var components = ProductComponentDataService.GenerateSampleData();

        var billOfMaterialsList = new List<BillOfMaterials>
        {
            new BillOfMaterials
            {
                ID = "BOM0001",
                ProductionTypeName = "製品タイプ1",
                Department = "製造部門A",
                Description = "製品タイプ1の部品表",
                ProductComponents = new List<ProductComponent>
                {
                    components[0],
                    components[1],
                    components[2]
                }
            },
            new BillOfMaterials
            {
                ID = "BOM0002",
                ProductionTypeName = "製品タイプ2",
                Department = "製造部門B",
                Description = "製品タイプ2の部品表",
                ProductComponents = new List<ProductComponent>
                {
                    components[3],
                    components[4],
                    components[5]
                }
            },
            new BillOfMaterials
            {
                ID = "BOM0003",
                ProductionTypeName = "製品タイプ3",
                Department = "製造部門C",
                Description = "製品タイプ3の部品表",
                ProductComponents = new List<ProductComponent>
                {
                    components[6],
                    components[7],
                    components[8]
                }
            },
            // ... (add data for other BillOfMaterials, up to 20)
            new BillOfMaterials
            {
                ID = "BOM0020",
                ProductionTypeName = "製品タイプ20",
                Department = "製造部門T",
                Description = "製品タイプ20の部品表",
                ProductComponents = new List<ProductComponent>
                {
                    components[57],
                    components[58],
                    components[59]
                }
            }
        };

        return billOfMaterialsList;
    }
}
