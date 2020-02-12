using Library.DAL;
using Microsoft.EntityFrameworkCore;

namespace Library.Test
{
    public class TestContext : LibContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // define some test database
           
            optionBuilder.UseNpgsql("User ID=postgres; Password=B19e08r1997.; Server=localhost; Port=5432; Database=libraryTest; Integrated Security=true; Pooling=true;");
        }

        // just use database in memory - comment above and uncomment below
        //optionBuilder.UseInMemoryDatabase(databaseName: "libero");
    }
    }

