using eCom.DataContext.Context;
using Lib.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.DataContext.UnitOfWork
{
    public interface IUnitOfWork : Lib.Repository.IUnitOfWork, IDisposable
    {
    }

    public class UnitOfWork : Lib.Repository.UnitOfWork, IUnitOfWork
    {
        EComDbContext _eComDbContext;
        public UnitOfWork(EComDbContext eComDbContext) : base(eComDbContext)
        {
            _eComDbContext = eComDbContext;
        }
    }
}
