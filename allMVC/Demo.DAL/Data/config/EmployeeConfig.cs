using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e=>e.Salary)
                .HasColumnType("decimal(18,2)");
            builder.HasOne(d => d.Department)
                .WithMany(e => e.employees)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
