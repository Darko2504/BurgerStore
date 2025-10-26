using BurgerStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgerStore.DataAcess.DbContext
{
    public class BurgerAppDbContext  : IdentityDbContext<User>
    {
        public BurgerAppDbContext(DbContextOptions<BurgerAppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Burger> Burger {  get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=127.0.0.1:2504;Database=BurgerApp;Username=postgres;Password=imainvayne123");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Burger>()
                .HasOne(u => u.User)
                .WithMany(p => p.Burgers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Order>()
                .HasMany(p => p.Burgers)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId);

            builder.Entity<Order>()
                .HasKey(k => k.Id);

            builder.Entity<Order>()
                .Property(a => a.AdressTo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Order>()
                .Property(a => a.Description)
                .HasMaxLength(50);

            builder.Entity<Order>()
                .Property(a => a.OrderPrice)
                .IsRequired();



            builder.Entity<Burger>()
                .HasKey(k => k.Id);

            builder.Entity<Burger>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Burger>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            builder.Entity<Burger>()
                .Property(p => p.Price)
                .IsRequired();
        }
    }
}
