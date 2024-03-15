using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.DBContext;
using Tickets.DAL.Repositories.Interfaces;
using Tickets.DAL.Repositories.Repositories;

namespace Tickets.IOC
{
    public static class Dependency
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketsDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("string"));
            });


            services.AddScoped<IRepositoryEquipo, RepositoryEquipo>();
        }
    }
}
