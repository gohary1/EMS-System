using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repo
{
    public class EmployeeRepo : GenaricRepo<Employee>, Iunitofwork
    {
        public EmployeeRepo(AppDbContext dbContext):base(dbContext)
        {
            
        }
        public IQueryable<Employee> GetEmpByAddress(string address)
        {
            return dbContext.Employees.Where(i => i.Address.ToLower().Contains(address.ToLower()));
        }

         IEnumerable<Employee> Iunitofwork.GetEmpByName(string name)
        {
            return dbContext.Employees.Where(e => e.Name.ToLower()==name).ToList();
        }
    }
}
