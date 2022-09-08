using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

namespace WebApplication6.Models
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }
        public DbSet<thenews> thenews { get; set; }
        public DbSet<thecatogry> Thecatogry { get; set; }
        public DbSet<theteam> Theteam { get; set; }
        public DbSet<tocontactus> tocontactus { get; set; }
        public DbSet<yourdata> yourdata { get; set; }

    }
}
