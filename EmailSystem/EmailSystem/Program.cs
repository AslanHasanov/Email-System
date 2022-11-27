using EmailSystem.DataBase;
using EmailSystem.Services.EmailService;
using Microsoft.EntityFrameworkCore;

namespace EmailSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddDbContext<DataContext>(o =>
                {
                    o.UseSqlServer(builder.Configuration.GetConnectionString("ROG"));
                })
                .AddMvc()
                .AddRazorRuntimeCompilation();

            builder.Services.AddControllers();

            var emailConfig = builder.Configuration
            .GetSection("EmailConfiguration")
            .Get<EmailConfiguration>();

            builder.Services.AddSingleton(emailConfig);

            builder.Services.AddScoped<IEmailSender, EmailSender>();


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}");

            app.Run();
        }
    }
}

