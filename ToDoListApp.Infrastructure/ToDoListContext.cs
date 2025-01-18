using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ToDoListApp.Domain;

namespace ToDoListApp.Infrastructure
{
    public class ToDoListContext : DbContext
    {

        public DbSet<ToDoList> ToDoLists { get; set; }


        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<ToDoItem>().HasData();

        }


    }
}
