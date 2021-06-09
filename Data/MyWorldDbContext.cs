using Dotnet5.MVC.CRUD.EF.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dotnet5.MVC.CRUD.EF.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Gadgets> Gadgets { get; set; }
    }
}