using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Regpro.Core.CustomEntities;
using Regpro.Core.Interfaces;
using Regpro.Core.Services;
using Regpro.Infrastructure.Data;
using Regpro.Infrastructure.Interfaces;
using Regpro.Infrastructure.Options;
using Regpro.Infrastructure.Repositories;
using Regpro.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Regpro.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<regproContext>(options =>
               options.UseMySQL(configuration.GetConnectionString("regpro"))
           );
            services.AddDbContext<IdentidadContext>(options =>
               options.UseMySQL(configuration.GetConnectionString("regproIdentity"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));
            //services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProvinciaService, ProvinciaService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IDistritoService, DistritoService>();
            services.AddTransient<ITblRegproProgramaService, TblRegproProgramaService>();
            services.AddTransient<ITblRegproMaestroService, TblRegproMaestroService>();
            services.AddTransient<ITblRegproSolicitudService, TblRegproSolicitudService>();
            services.AddTransient<ITblRegproDocumentoService, TblRegproDocumentoService>();
            services.AddTransient<ITblRegproArchivoService, TblRegproArchivoService>();
            services.AddTransient<ICentroPobladoService, CentroPobladoService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IDetRegproSolDocService, DetRegproSolDocService>();
            services.AddTransient<IDreGeoService, DreGeoService>();


            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<IUriService>(provider =>
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            return services;
        }

        //public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        //{
        //    services.AddSwaggerGen(doc =>
        //    {
        //        doc.SwaggerDoc("v1", new OpenApiInfo { Title = "REGPRO API", Version = "v1" });

        //        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
        //        doc.IncludeXmlComments(xmlPath);
        //    });

        //    return services;
        //}
    }
}
