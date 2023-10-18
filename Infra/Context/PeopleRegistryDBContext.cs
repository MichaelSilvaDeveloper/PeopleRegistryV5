using Domain.Models;
using Infra.Map;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class PeopleRegistryDBContext : DbContext
    {
        public PeopleRegistryDBContext(DbContextOptions<PeopleRegistryDBContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}   