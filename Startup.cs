using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using unitOfWorkSample.Core;
using unitOfWorkSample.Helpers;
using unitOfWorkSample.Persistence;

namespace unitOfWorkSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             string connectionString = Configuration.GetConnectionString("MYSQLContext");
            /* Obtengo del archivo de configuracion qué tipo de BD se usará.
                El string obtenido debe coincidir con alguna de las constantes que están en
                Helpers.Providers */
            string proveedor = Configuration.GetSection("AppSettings:BaseDeDatos").Value;

            services.AddDbContext<MySqlContext>(options =>
                                    options.UseDatabase(connectionString, proveedor));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddJsonOptions(opt =>
                   opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddCors();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // services.AddScoped<IAuthLogic, AuthLogic>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:TokenSecretKey").Value)
                            ),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.ConfigureCors();
        }
    }
}
