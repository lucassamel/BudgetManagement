using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Mappings;
using BudgetManagement.Application.Services;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Infra.Data.Context;
using BudgetManagement.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAutoMapper(typeof(EntitiesToDtoMappingProfile));

            //Repositories
            services.AddScoped<IProfileRepository, ProfileRepository>();

            //Services
            services.AddScoped<IProfileService,ProfileService>();

            return services;
        }
    }
}
