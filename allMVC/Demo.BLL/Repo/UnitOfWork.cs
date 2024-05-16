using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public Iunitofwork EmployeeRepo { get; set; }
        public IDepRepo DepRepo { get; set; }
        public UnitOfWork(AppDbContext dbContext)
        {
            EmployeeRepo = new EmployeeRepo(dbContext);
            DepRepo = new DepRepo(dbContext);
            _dbContext = dbContext;
        }

        public int complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
