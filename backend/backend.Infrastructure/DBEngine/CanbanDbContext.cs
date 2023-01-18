using backend.Domain.Model;
using Microsoft.EntityFrameworkCore;
using TaskModel = backend.Domain.Model.Task;

namespace backend.DBEngine
{
    public class CanbanDbContext : DbContext
    {
        private DbSet<Board> Board { get; set; }
        private DbSet<Column> Column { get; set; }
        private DbSet<Credential> Credential { get; set; }
        private DbSet<Participant> Participant { get; set; }
        private DbSet<TaskModel> Task { get; set; }
        private DbSet<User> User { get; set; }

        public CanbanDbContext(DbContextOptions<CanbanDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=sql-server-db,1433;Database=CANBAN_DB;User Id=sa;Password=pass$;");
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<TaskModel>(buildAction =>
            {
                buildAction.HasOne<Participant>()
                    .WithMany()
                    .HasConstraintName("FK_Participant_Tasks")
                    .HasForeignKey("OwnerId")
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
