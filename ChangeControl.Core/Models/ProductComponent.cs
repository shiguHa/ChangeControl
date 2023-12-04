using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeControl.Core.Models;
public class ProductComponent
{
    public string ID
    {
    get; set; 
    }

    public string Name
    {
        get; set;
    }

    public Company Supplier
    {
           get; set;
       }


    public ProductComponent? Parent
    {
        get; set;
    }

    public List<ProductComponent>? Children
    {
    get; set; }
}
