using ESunBankTest.Connections;
using ESunBankTest.Models.SystemDB;
using ESunBankTest.Providers;
using Microsoft.EntityFrameworkCore;

namespace ESunBankTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //初始化 Builder
            var builder = WebApplication.CreateBuilder(args);

            //加入 SystemDB
            builder.Services.AddDbContext<SystemDBEntities>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            //加入 AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            //加入 GovData 連線
            builder.Services.AddScoped<conn_DataGov>();

            //加入 Provider
            builder.Services.AddScoped<DataGovProvider>();

            //初始化 MVC View-Controller
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;

                });

            //App 初始化
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            //Controller 預設初始化
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //App 執行
            app.Run();
        }
    }
}
