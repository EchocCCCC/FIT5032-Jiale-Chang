namespace FIT5032_ASS_32747829.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_booking : DbContext
    {
        public Model_booking()
            : base("name=Model_booking")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Units> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasMany(e => e.Units)
                .WithRequired(e => e.Booking)
                .HasForeignKey(e => e.UsersID)
                .WillCascadeOnDelete(false);
        }
    }
}
