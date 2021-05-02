using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
                        
        }

        public DbSet<DDD> DDD { get; set; }
        public DbSet<PhonePlan> PhonePlan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
            base.OnConfiguring(optionsBuilder);


        }

        internal Task<PhonePlan> where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=localhost;Initial Catalog=DDD_EXAMPLE;Integrated Security=True";
            return strCon;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DDD>()
                .Property(b => b.Id)
                .IsRequired();

            modelBuilder.Entity<DDD>()
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<DDD>()
                .Property(b => b.Origin)
                .HasMaxLength(2)
                .IsRequired();

            modelBuilder.Entity<DDD>()
                .Property(b => b.Destiny)
                .HasMaxLength(2)
                .IsRequired();

            modelBuilder.Entity<DDD>()
                .Property(b => b.PricePerMinute)
                .IsRequired();

            modelBuilder.Entity<PhonePlan>()
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();


            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 1, Name = "Config 1", Origin = 11, Destiny = 16, PricePerMinute = 1.9m });
            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 2, Name = "Config 2", Origin = 16, Destiny = 11, PricePerMinute = 2.9m });
            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 3, Name = "Config 3", Origin = 11, Destiny = 17, PricePerMinute = 1.7m });
            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 4, Name = "Config 4", Origin = 17, Destiny = 11, PricePerMinute = 2.7m });
            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 5, Name = "Config 5", Origin = 11, Destiny = 18, PricePerMinute = 0.9m });
            modelBuilder.Entity<DDD>().HasData(new DDD {Id = 6, Name = "Config 6", Origin = 18, Destiny = 11, PricePerMinute = 1.9m });

            modelBuilder.Entity<PhonePlan>().HasData(new PhonePlan { Id = 1, Name = "FaleMais 30", Minute = 30, Addition = 10  });
            modelBuilder.Entity<PhonePlan>().HasData(new PhonePlan { Id = 2, Name = "FaleMais 60", Minute = 60, Addition = 10 });
            modelBuilder.Entity<PhonePlan>().HasData(new PhonePlan { Id = 3, Name = "FaleMais 120", Minute = 120, Addition = 10 });

        }

    }
}
