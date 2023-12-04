using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeControl.Core.Models;

namespace ChangeControl.Core.Contracts.Services;
internal interface IDataService<T>
{
    Task<IEnumerable<T>> GetListDetailsDataAsync();
}
