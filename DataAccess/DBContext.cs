using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace DataAccess
{
    public class DBContext : IdentityDbContext<IdentityUser>
    {


        public static void Initialize(IConfiguration configuration, IHostEnvironment env)
        {
            //var execDirectory = configuration.GetValue("SELVVALGT_SOLUTION_ROOT", env.ContentRootPath);
            var builder = new SqliteConnectionStringBuilder();
            if (env.IsDevelopment())
            {
                builder.DataSource = "..\\DataAccess\\SelvvalgtDB.sqlite";
            }
            else
            {
                builder.DataSource = "D:\\home\\site\\wwwroot\\DataAccess\\SelvvalgtDB.sqlite";
            }

            ConnString = builder.ConnectionString;
            if (string.IsNullOrEmpty(ConnString))
            {
                throw new Exception("Cannot compute connection string to connect database!");
            }
        }

        public DbSet<Users> Users { get; set; }

        public static string? ConnString;

        public DBContext(DbContextOptions<DBContext> options)
        #pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
            : base(options)
                {
                }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
