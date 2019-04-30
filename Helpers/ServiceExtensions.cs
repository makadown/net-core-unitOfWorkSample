using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace unitOfWorkSample.Helpers
{
    /// <summary>
    /// Esta es una clase con métodos estáticos para extender los métodos del IApplicationBuilder
    /// Fuente: https://code-maze.com/aspnetcore-webapi-best-practices/
    /// </summary>
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IApplicationBuilder app)
        {
            // TODO: Aqui iria configurado de manera diferente, o se quitaria?.
            app.UseCors(builder =>
                    builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod()
                                   .AllowCredentials());
        }

        public static void UseDatabase(this DbContextOptionsBuilder options, string connectionString, string dataBase) {
            switch (dataBase) {               
                case Providers.MYSQL:
                    options.UseMySql(connectionString,
                                        mySqlOptions =>
                                       {
                                            mySqlOptions.ServerVersion(new Version(8, 0, 15), ServerType.MySql).CommandTimeout(60);
                                            /* Fuente para timeout:
                            https://stackoverflow.com/questions/39058422/how-to-set-command-timeout-in-aspnetcore-entityframeworkcore
                                             */
                                        }); 
                    break;
                    // TODO
               /* case Providers.Oracle:
                    options.UseOracle();
                    break; */
                 case Providers.MSSQL:
                 default:
                    options.UseSqlServer(connectionString, 
                                        sqlServerOptions => sqlServerOptions.CommandTimeout(60) );
                    break;
            }
        }      
    }
}