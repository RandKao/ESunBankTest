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

            //��l�� Builder
            var builder = WebApplication.CreateBuilder(args);

            //�[�J SystemDB
            builder.Services.AddDbContext<SystemDBEntities>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }, ServiceLifetime.Transient);

            //�[�J AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            //�[�J GovData �s�u
            builder.Services.AddScoped<conn_DataGov>();

            //�[�J Provider
            builder.Services.AddScoped<DataGovProvider>();

            //��l�� MVC View-Controller
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;

                });

            //App ��l��
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            //Controller �w�]��l��
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //App ����
            app.Run();
        }
    }
}
