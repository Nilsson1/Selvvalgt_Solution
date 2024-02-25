using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Selvvalgt
{
    public class WebAppDBContext : DbContext
    {
        public static void Initialize(IConfiguration configuration, IHostEnvironment env)
        {/*
            //var execDirectory = configuration.GetValue("SELVVALGT_SOLUTION_ROOT", env.ContentRootPath);
            var builder = new SqliteConnectionStringBuilder();
            if (env.IsDevelopment())
            {
                builder.DataSource = "..\\.db";
            }
            else
            {
                builder.DataSource = "D:\\home\\site\\wwwroot\\DataAccess\\SelvvalgtDB.db";
            }

            ConnString = builder.ConnectionString;
            if (string.IsNullOrEmpty(ConnString))
            {
                throw new Exception("Cannot compute connection string to connect database!");
            }*/
        }

        public DbSet<Users> Users { get; set; }

        public static string? ConnString;

        public WebAppDBContext(DbContextOptions<WebAppDBContext> options) : base(options){ }

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
