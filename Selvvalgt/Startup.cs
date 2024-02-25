using DataAccess;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


namespace Selvvalgt
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            var execDirectory = GetExecDirectory();

            var builder = new ConfigurationBuilder();

            var dic = new Dictionary<string, string>
            {
                {"SELVVALGT_SOLUTION_ROOT", execDirectory},
            };
            builder.AddInMemoryCollection(dic);
            builder.AddConfiguration(configuration);
            Configuration = builder.Build();

            env.WebRootFileProvider = new CompositeFileProvider(
                env.WebRootFileProvider, new PhysicalFileProvider(Path.Combine(execDirectory))
            );

            DBContext.Initialize(this.Configuration, env);
        }

        private static string GetExecDirectory()
        {
            string? entryDir = null;
            string? entryLocation = Assembly.GetEntryAssembly()?.Location;
            if (!string.IsNullOrEmpty(entryLocation))
            {
                entryDir = Path.GetDirectoryName(entryLocation);
            }
            if (!string.IsNullOrEmpty(entryDir))
            {
                return entryDir;
            }
            throw new Exception("Cannot locate entry assembly location!");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddDbContext<DBContext>(options =>
                options.UseSqlite(DBContext.ConnString)
                    .UseLazyLoadingProxies(),
                ServiceLifetime.Scoped);

            services.AddControllersWithViews();
            services.AddScoped<UsersRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            // app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            // app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
