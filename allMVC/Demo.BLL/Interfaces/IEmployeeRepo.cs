using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface Iunitofwork:IGenaricRepo<Employee>
    {
        IQueryable<Employee> GetEmpByAddress(string address);
        IEnumerable<Employee> GetEmpByName(string name);
    }
}
