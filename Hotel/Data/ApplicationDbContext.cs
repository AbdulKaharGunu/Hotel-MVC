using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Models here

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<StaffLogin> StaffLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RoomType - Room Relationship
            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);

            // Room - Reservation Relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany(rm => rm.Reservations)
                .HasForeignKey(r => r.RoomId);

            // Staff - Reservation Relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Staff)
                .WithMany()
                .HasForeignKey(r => r.StaffId);

            // Customer - Reservation Relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID);

            // Reservation - Payment Relationship
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Reservation)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.ReservationId);

            base.OnModelCreating(modelBuilder);

        }
}
