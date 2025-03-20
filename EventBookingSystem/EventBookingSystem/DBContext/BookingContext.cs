using EventBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.DBContext
{
    public class BookingContext:DbContext
    {
        public BookingContext(DbContextOptions<BookingContext>options):base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
       public DbSet<Event> Events { get; set; }
       public DbSet<TicketBooking> TicketBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketBooking>()
                .HasOne(tb => tb.User)
                .WithMany(u => u.TicketBookings)
                .HasForeignKey(tb=>tb.UserId);

            modelBuilder.Entity<TicketBooking>()
                .HasOne(tb => tb.Event)
                .WithMany(e => e.TicketBookings)
                .HasForeignKey(tb => tb.EventId);

            modelBuilder.Entity<TicketBooking>()
                .Property(e => e.BookingDate)
                .HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);

            //builder.BookingDate(x => x.EntityCreated).HasDefaultValueSql("getdate()");
        }

        
    }
}
