using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Migrations.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVillaRepository Villa { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {    
            //this has been made to save time in updating depending injection in program.cs
        
            _db = db;
            Villa = new VillaRepository(_db);
        }
    }
}
