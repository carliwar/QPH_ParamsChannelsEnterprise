using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using QPH_ParamsChannelsEnterprise.Core.Services;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using QPH_ParamsChannelsEnterprise.Infrastructure.Repositories;
using System;
using System.IO;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));
            return services;
        }
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdministrationSwitchContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdministrationSwitch"))
            );

            services.AddDbContext<SwitchAtiscodeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SwitchAtiscode"))
            );

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordService, PasswordService>();

            // Repository Injection
            services.AddScoped(typeof(IRepository<>), typeof(AdministrationSwitchBaseRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(SwitchAtiscodeBaseRepository<>));

            services.AddTransient<IContext, AdministrationSwitchContext>();
            services.AddTransient<IContext, SwitchAtiscodeContext>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();          

            // Services Injection
            services.AddTransient<ICredentialsServerService, CredentialsServerService>();
            services.AddTransient<ICredentialsUserService, CredentialsUserService>();
            services.AddTransient<INonBillableProductsService, NonBillableProductsService>();
            services.AddTransient<IQueryManagerService, QueryManagerService>();
            services.AddTransient<IBusinessLineService, BusinessLineService>();
            services.AddTransient<ISubBusinessLineService, SubBusinessLineService>();
            services.AddTransient<IFinancialDimensionService, FinancialDimensionService>();
            services.AddTransient<IEnterpriseService, EnterpriseService>();
            services.AddTransient<IEnterpriseCredentialsService, EnterpriseCredentialsService>();
            services.AddTransient<IChannelService, ChannelService>();
            services.AddTransient<IFinancialSizingService, FinancialSizingService>();
            services.AddTransient<IChannelEnterpriseService, ChannelEnterpriseService>();
            
            services.AddTransient<IParametersService, ParametersService>();
            services.AddTransient<ISwitchAtiscodeProceduresService, SwitchAtiscodeProceduresService>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v2", new OpenApiInfo { Title = "QPH Params Channels Enterprise", Version = "v1" });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            });
            return services;
        }
    }
}
