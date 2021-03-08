using CleanArchitecture.DataAccess;
using CleanArchitecture.DataAccess.Repositories;
using CleanArchitecture.DataAccess.Repositories.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Configuration;
using CleanArchitecture.Service.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CleanArchitecture.API.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigurationHelper(this IServiceCollection serviceCollection, Action<IConfigurationHelper> configuration)
        {
            serviceCollection.AddSingleton<IConfigurationHelper, ConfigurationHelper>(factory =>
            {
                var configurationHelper = new ConfigurationHelper();
                configuration(configurationHelper);
                return configurationHelper;
            });
        }

        public static void ConfigureWebApi(this IServiceCollection services)
        {
            services.ConfigureMediatR();
            services.ConfigureDataAccess();
            services.ConfigureSwagger();
            services.ConfigureStaticFiles();
        }

        public static void ConfigureDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<CleanArchitectureDbContext>();
            services.AddScoped<IRepository<User>, UserRepository>();
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly, typeof(BaseResponse).Assembly);
            services.AddMediatRRequestValidators(typeof(BaseResponse).Assembly);
        }

        public static void AddMediatRRequestValidators(this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(a =>
                a.GetTypes().Where(t =>
                {
                    if (t.IsAbstract)
                    {
                        return false;
                    }

                    var baseType = t.BaseType;
                    if (baseType == null || !baseType.IsGenericType)
                    {
                        return false;
                    }

                    var pipelineType = typeof(IPipelineBehavior<,>).MakeGenericType(baseType.GenericTypeArguments);

                    return pipelineType.IsAssignableFrom(t.BaseType);
                }));

            foreach (var type in types)
            {
                var pipelineType = typeof(IPipelineBehavior<,>).MakeGenericType(type.BaseType.GenericTypeArguments);
                services.AddTransient(pipelineType, type);
            }
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanArchitecture.API", Version = "v1" });
            });
        }

        public static void ConfigureStaticFiles(this IServiceCollection services)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            });
        }

    }
}
