using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeControl.Core.Models;
public class BillOfMaterials
{
    public string ID
    {
    get; set; }

    public string ProductionTypeName
    {
        get; set;
    }

    public string Department
    {
    
           get; set;
       }

    public string Description
    {
    
           get; set;
       }

    public  List<ProductComponent> ProductComponents
    { get; set; }

}
