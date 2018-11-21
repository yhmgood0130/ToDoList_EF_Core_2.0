using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using SimpleApp.Domain;

namespace SimpleApp.Data
{
    public class ToDoListContext:DbContext
    {
        readonly LoggerFactory MyConsoleLoggerFactory =
            new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information, true) });
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyConsoleLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(
                "Server = (localdb)\\mssqllocaldb; Database = SimpleAppData; Trusted_Connection = true;" );
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoListSchedule>()
                .HasKey(t => new { t.ToDoListId, t.ScheduleId });
        }

    }
}
