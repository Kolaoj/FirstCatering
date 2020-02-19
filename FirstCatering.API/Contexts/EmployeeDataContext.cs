using FirstCatering.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstCatering.API.Contexts
{
    public class EmployeeDataContext : DbContext
    {
        public DbSet<EmployeeData> Employees { get; set; }

        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options)
          : base(options)
        {
              Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeData>()
                  .HasData(
                 new EmployeeData()
                 {
                     CardId = "r7jTG7dqBy5wGO4L",
                     EmployeeId = "HarveyP123",
                     FirstName = "Harvey",
                     LastName = "Pinewood",
                     Email = "harveypinewood@bowsf1.com",
                     Pin = "1234",
                     Balance = 21.00M,
                     MobileNumber = "+447123456760"
                 },
                 new EmployeeData()
                 {
                     CardId = "r7jTG7dqBy5wGO3L",
                     EmployeeId = "GeorgiaY123",
                     FirstName = "Georgia",
                     LastName = "Yale",
                     Email = "georgiayale@bowsf1.com",
                     Pin = "1234",
                     Balance = 22.00M,
                     MobileNumber = "+447123456769"
                 },
                  new EmployeeData()
                  {
                      CardId = "r7jTG7dqBy5wGO2L",
                      EmployeeId = "PaulF123",
                      FirstName = "Paul",
                      LastName = "Forest",
                      Email = "paulforest@bowsf1.com",
                      Pin = "1234",
                      Balance = -1.00M,
                      MobileNumber = "+447123456789"
                  });

            base.OnModelCreating(modelBuilder);
        }
    }
}
