using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BLL.Services.Implements;
using Tickets.BLL.Services.Interfaces;
using Tickets.DAL.DBContext;
using Tickets.DAL.Repositories.Interfaces;
using Tickets.DAL.Repositories.Repositories;
using Tickets.Utility;

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


            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEquipoService, EquipoService>();
        }
    }
}
