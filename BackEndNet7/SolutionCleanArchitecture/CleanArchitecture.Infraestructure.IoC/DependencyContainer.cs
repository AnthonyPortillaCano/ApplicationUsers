using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork>(option => new UnitOfWork(new BDCompanyContext(new DbContextOptionsBuilder<BDCompanyContext>().UseSqlServer(configuration.GetConnectionString("ConnectionSqlServer")).Options), configuration.GetConnectionString("ConnectionSqlServer")));
        }
    }
}