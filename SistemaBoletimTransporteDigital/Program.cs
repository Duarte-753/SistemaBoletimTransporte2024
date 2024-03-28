
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using SistemaBoletimTransporteDigital.Data;
using SistemaBoletimTransporteDigital.Helper;
using SistemaBoletimTransporteDigital.Repositorio;

namespace SistemaBoletimTransporteDigital
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // serviço do PWA
            builder.Services.AddProgressiveWebApp();



            builder.Services.AddDbContext<BancoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            // Para usar as interface temos que listar ela aqui em baixo em services (instanciamos as interface)

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Helper httpcontext da classe sessão
            //builder.Services.AddFastReport();            
            builder.Services.AddScoped<IRelatorioUsuarioRepositorio, RelatorioUsuarioRepositorio>();          
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IVeiculoRepositorio, VeiculoRepositorio>();
            builder.Services.AddScoped<ISessao, Sessao>(); // quando chamar a interface vai chamar a classe referente a ela
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddScoped<ICorridaRepositorio, CorridaRepositorio>();
            builder.Services.AddScoped<IManutencaoRepositorio, ManutencaoRepositorio>();
            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseFastReport(); // usando fastReport

            app.UseSession(); //usar a sessão
                     
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            string wwwroot = app.Environment.WebRootPath;
            RotativaConfiguration.Setup(wwwroot, "Rotativa");//usar o caminho pasta Rotativa do wwwroot

            app.Run();

            

        }
    }
}