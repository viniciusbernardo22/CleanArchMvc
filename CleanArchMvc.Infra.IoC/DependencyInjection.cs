﻿using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                        )
                    );
            

            services.AddScoped<ICategoryRepository, ICategoryRepository>();
            services.AddScoped<IProductRepository, IProductRepository>();

            return services;
        }
    }
}