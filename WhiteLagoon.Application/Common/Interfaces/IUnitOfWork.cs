using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        //it is a Unit of work to save time to updating Addscoped in program.cs everytime
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
    }
}
