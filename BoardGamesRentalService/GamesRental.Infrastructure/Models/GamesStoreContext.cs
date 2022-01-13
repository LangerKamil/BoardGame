using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GamesRental.Infrastructure.Models
{
    public class GamesStoreContext : DbContext
    {

        public GamesStoreContext(DbContextOptions<GamesStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<RentalStatus> RentalStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)r
            //{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=host.docker.internal;Initial Catalog=GamesStore;MultipleActiveResultSets=true;Integrated Security=False;Trusted_Connection=False;User Id=dbo;Password=dbo");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
