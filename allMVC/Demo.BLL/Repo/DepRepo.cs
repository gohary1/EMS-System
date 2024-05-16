using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data;
using Microsoft.EntityFrameworkCore;
namespace Demo.BLL.Repo
{
     public class DepRepo :GenaricRepo<Department>, IDepRepo
    {
        public DepRepo(AppDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
