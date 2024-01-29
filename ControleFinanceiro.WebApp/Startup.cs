using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;
using ControleFinanceiro.Repository.Repositories;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web.UI;

namespace SouDizimista.WebApp
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

            services.AddControllersWithViews();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<Context>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddAutoMapper(typeof(Startup));
                // Repositorios
                services.AddRazorPages().AddMicrosoftIdentityUI();
                services.AddScoped(typeof(IDespesaRepository), typeof(DespesaRepository));
                services.AddScoped(typeof(IReceitaRepository), typeof(ReceitaRepository));
                services.AddScoped(typeof(IDemonstrativoFinanceiroRepository), typeof(DemonstrativoFinanceiroRepository));


            // Servicos
            services.AddScoped(typeof(IServiceDespesa), typeof(ServiceDespesa));
                services.AddScoped(typeof(IServiceReceita), typeof(ServiceReceita));
            services.AddScoped(typeof(IServiceDemonstrativoFinanceiro), typeof(ServiceDemonstrativoFinanceiro));
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
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Home",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Menu",
                    pattern: "{controller=Menu}/{action=GetMenuItems}/{id?}");
            });
        }
    }
}
