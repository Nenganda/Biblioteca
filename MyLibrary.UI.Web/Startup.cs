using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyLibrary.Data;
using MyLibrary.Data.Interfaces;
using MyLibrary.Services.Service;

namespace MyLibrary.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            
            //Injeção
            services.AddSingleton(Configuration);
            services.AddScoped<IBibliotecaAtivo, BibliotecaAtivoService>();
            services.AddScoped<ICheckOut, CheckOutService>();

            #region //MySql
            /* //MySql
             
                  "ConnectionStrings": {
                    "StringConnMySql": "server=localhost;port=3307;database=MyLibrary;uid=lsadmin;password=Ls4dm7n;"
                  },

                Packed: Pomelo.EntityFrameworkCore.MySql 3.1.1
             */

            /* //Conexão com MySql
                var connection = Configuration.GetConnectionString("StringConnMySql");
                
                services.AddDbContext<MyLibraryContext>(options =>
                    options.UseMySql(connection));
             
             */
            #endregion

            #region //SQL SERVER
            /* //SQL SERVER
             
                  "ConnectionStrings": {
                    "StringConnSqlServer": "Server=(localdb)\\DESKTOP-VKQ117V\SQLEXPRESS;Database=MyLibrary;Trusted_Connection=True;MultipleActiveResultSets=true"
                  },

                Packed: Microsoft.EntityFrameworkCore.SqlServer 3.1.3
             */

            //Conexão com SQL SERVER
            var connection = Configuration.GetConnectionString("StringConnSqlServer");
                
            services.AddDbContext<MyLibraryContext>(options =>
                options.UseSqlServer(connection));
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Catalogo}/{action=Index}/{id?}");
            });
        }
    }
}
