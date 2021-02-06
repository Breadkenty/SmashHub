using AutoMapper;
using Hellang.Middleware.ProblemDetails;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmashCombos.Core.Services;
using SmashCombos.Persistence;
using SmashCombos.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Security.Authentication;
using System.Text;

namespace SmashCombos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddProblemDetails(configure =>
            {
                configure.Map<ArgumentException>(ex => new StatusCodeProblemDetails(StatusCodes.Status400BadRequest));
                configure.Map<AuthenticationException>(ex => new StatusCodeProblemDetails(StatusCodes.Status401Unauthorized));
                configure.Map<SecurityException>(ex => new StatusCodeProblemDetails(StatusCodes.Status403Forbidden));
                configure.Map<KeyNotFoundException>(ex => new StatusCodeProblemDetails(StatusCodes.Status404NotFound));
                configure.Map<Exception>(ex => new StatusCodeProblemDetails(StatusCodes.Status500InternalServerError));
            });

            services.AddDbContext<IDbContext, PostgreSqlDatabaseContext>();
            services.AddMediatR(Core.AssemblyUtility.GetAssembly());
            services.AddAutoMapper(Core.AssemblyUtility.GetAssembly());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JWT_KEY"]))
                };
            });

            services.AddScoped<IMailSenderService, GridSendMailSenderService>();
            services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin());
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseProblemDetails();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
