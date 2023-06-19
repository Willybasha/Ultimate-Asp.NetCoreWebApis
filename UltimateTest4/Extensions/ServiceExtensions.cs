using Contracts;
using DomainLayer4.Context;
using LoggerLayer4;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer4;
using Service.Contracts;
using ServiceLayer4;

namespace UltimateTest4.Extensions
{
    public static class ServiceExtensions
    {
        #region Coniguring the CORSPolicy to our application 
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
        #endregion

        #region Configuring IIS to our application
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
        });
        #endregion

        #region Configuring LoggerService Layer
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        #endregion

        #region Configuring RepositoryManager 
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        #endregion

        #region Configuring ServiceManager
        public static void ConfigureServiceManager(this IServiceCollection services)
            => services.AddScoped<IServiceManager, ServiceManager>();
        #endregion

        #region Configuring context
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration Configuration)
            => services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

        #endregion




    }
}
