using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskato.Models;

namespace Taskato.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }


        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Seed Data

            #region Seed Data Priority
            modelBuilder.Entity<Priority>().HasData(

                new Priority()
                {
                    Id = 1,
                    Name = "Priority 1",
                  

                },
                new Priority()
                {
                    Id = 2,
                    Name = "Priority 2",



                },
                new Priority()
                {
                    Id = 3,
                    Name = "Priority 3",



                },
                new Priority()
                {
                    Id = 4,
                    Name = "Priority 4",



                }


            );

            #endregion
            #region SeedDataTaskTable

            modelBuilder.Entity<Tasks>().HasData(

                new Tasks()
                {
                    Id = 1,
                    Name = "Learning",
                    PriorityId = 4,
                    CreatedDate = DateTime.Now,
                    TaskDate = DateTime.Now,


                },
                new Tasks()
                {
                    Id = 2,
                    Name = "Work",
                    PriorityId = 3,
                    CreatedDate = DateTime.Now,
                    TaskDate = DateTime.Now,


                }


            );


            #endregion



            #endregion
        }
    }
}
