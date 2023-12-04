using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeControl.Core.Models;
public class ChangesBySupplierModel
{
    public Company Supplier
    {
        get; set;
    }

    public string TargetComponent
    {
        get; set;
       }

    public string BeforeChange
    {
        get; set;
    }

    public string AfterChange
    {
        get; set;
    }



}
