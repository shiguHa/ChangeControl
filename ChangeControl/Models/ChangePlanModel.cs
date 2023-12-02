using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Contracts.Models;

namespace ChangeControl.Models;
internal class ChangePlanModel
{
    public string?  ID{ get; set;}
    public string?  Reason{ get; set;}
     public string?  Category{ get; set;}

    public string? FundmentalID{get; set;}

    public List<IEvaluationItem> evaluationItems
    {
    get; set;
    }

}
