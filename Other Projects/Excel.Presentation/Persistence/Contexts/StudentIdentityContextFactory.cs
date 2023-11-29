using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.Presentation.Persistence.Configurations;

namespace Excel.Presentation.Persistence.Contexts
{
    public class StudentIdentityContextFactory: IDesignTimeDbContextFactory<StudentContext>
    {
       
            public StudentContext CreateDbContext(string[] args)
            {
          
                var optionsBuilder = new DbContextOptionsBuilder<StudentContext>();

                var connectionString = ConfigurationsDb.GetString("ConnectionStrings:PostgreSQL");

                optionsBuilder.UseNpgsql(connectionString);

                return new StudentContext(optionsBuilder.Options);
            }
        }
    }
