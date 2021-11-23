using System;
using Legiz.Back_End.LawServiceBC.Domain.Repositories;
using Legiz.Back_End.LawServiceBC.Domain.Services;
using Legiz.Back_End.LawServiceBC.Persistence.Repositories;
using Legiz.Back_End.LawServiceBC.Services;
using Legiz.Back_End.SecurityBC.Authorization.Handlers.Implementations;
using Legiz.Back_End.SecurityBC.Authorization.Handlers.Interfaces;
using Legiz.Back_End.SecurityBC.Authorization.Middleware;
using Legiz.Back_End.SecurityBC.Authorization.Settings;
using Legiz.Back_End.SecurityBC.Domain.Repositories;
using Legiz.Back_End.SecurityBC.Domain.Services;
using Legiz.Back_End.SecurityBC.Persistence.Repositories;
using Legiz.Back_End.SecurityBC.Services;
using Legiz.Back_End.Shared.Domain.Repositories;
using Legiz.Back_End.Shared.Persistence;
using Legiz.Back_End.Shared.Persistence.Contexts;
using Legiz.Back_End.Shared.Persistence.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Repositories;
using Legiz.Back_End.UserProfileBC.Domain.Services;
using Legiz.Back_End.UserProfileBC.Persistence.Repositories;
using Legiz.Back_End.UserProfileBC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Legiz.Back_End
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
            services.AddCors();
            
            services.AddControllers();
            
            services.AddRouting(options => options.LowercaseUrls = true);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Legiz.Back_End", Version = "v1"});
                c.EnableAnnotations();
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<AppDbContext>();

            // Dependency Injection Rules 
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILawyerRepository, LawyerRepository>();
            services.AddScoped<ILawyerService, LawyerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomLegalCaseRepository, CustomLegalCaseRepository>();
            services.AddScoped<ICustomLegalCaseService, CustomLegalCaseService>();
            services.AddScoped<ILegalAdviceRepository, LegalAdviceRepository>();
            services.AddScoped<ILegalAdviceService, LegalAdviceService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ILegalDocumentRepository, LegalDocumentRepository>();
            services.AddScoped<ILegalDocumentService, LegalDocumentService>();

            // AutoMapper Dependency Injection
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Legiz.Back_End v1"));
            }
            
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}