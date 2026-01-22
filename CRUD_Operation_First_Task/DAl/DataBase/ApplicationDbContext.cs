using CRUD_Operation_First_Task.DAl.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CRUD_Operation_First_Task.DAl.DataBase
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0RC8I7F\\SQLEXPRESS;Database=MVC_Course;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }

        public DbSet<Employee> employees { get; set; }

    }
}
