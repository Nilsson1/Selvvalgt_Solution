using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.Sqlite;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataAccess
{
    public class SelvvalgtDB : IdentityDbContext<IdentityUser>
    {
        public static void Initialize(IConfiguration configuration, IHostEnvironment env)
        {
            var execDirectory = "Selvvalgt_ROOT";
            var builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.Combine(execDirectory, "NORTHWND.sqlite");
            ConnString = builder.ConnectionString;
            if (string.IsNullOrEmpty(ConnString))
            {
            }
        }

        public static string? ConnString;

        #pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public SelvvalgtDB(DbContextOptions<SelvvalgtDB> options)
        #pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
            : base(options)
        {
        }

        public DbSet<UsersDAO> UsersDAO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.None,
            };

            base.OnModelCreating(modelBuilder);

        }
    }
}
