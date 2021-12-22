using Eccomerce.Domain.Entities;
using Eccomerce.Domain.Repositories;
using Eccomerce.Domain.UnitOfWork;
using Eccomerce.Domain.Validations;
using Ecommerce.Api.Builders;
using Ecommerce.Infrastructure.Contexts;
using Ecommerce.Infrastructure.Repositories;
using Ecommerce.Infrastructure.UnitOfWork;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Ecommerce.Api
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


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<AppDataContext>(options =>
            {

                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly(typeof(AppDataContext).Assembly.GetName().ToString()));
                options.UseLowerCaseNamingConvention();
                
            });


           


            services.AddIdentity<User, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<AppDataContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();

            services.AddScoped<IValidator<Category>, CategoryValidation>();
            services.AddScoped<IValidator<Product>, ProductValidation>();
            services.AddScoped<IValidator<PaymentMethod>, PaymentMethodValidation>();

            services.AddScoped<ITokenBuilder, TokenBuilder>();

            services.AddCors();

            var key = Encoding.ASCII.GetBytes(Configuration["JWT:key"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecommerce.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce.Api v1"));
            }

            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
