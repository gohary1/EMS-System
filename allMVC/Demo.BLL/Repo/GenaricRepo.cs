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
    public class GenaricRepo<T> : IGenaricRepo<T> where T : ModelBase
    {
        private protected readonly AppDbContext dbContext;
        public GenaricRepo(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);

        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);

        }

        public T Get(int id)
        {
            var dep = dbContext.Set<T>().Local.Where(d => d.Id == id).FirstOrDefault();
            if (dep == null)
            {
                dep = dbContext.Set<T>().Where(d => d.Id == id).FirstOrDefault();
            }
            return dep;
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)dbContext.Employees.Include(e=>e.Department).AsNoTracking().ToList();
            }
            else
                 return dbContext.Set<T>().AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);

        }
    }
}
