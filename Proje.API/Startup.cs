using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Proje.Data;
using Microsoft.EntityFrameworkCore;
using Proje.Data.UnitOfWorks;
using Proje.Core.UnitOfWorks;
using Proje.Core.Services;
using Proje.Core.Repositories;
using Proje.Data.Repositories;
using Proje.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Proje.Core.Auth;
using Proje.API.Settings;
using Proje.API.Extensions;
using Proje.Core.Models;
using Microsoft.OpenApi.Models;


namespace Proje.API
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
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));

            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();

            services.AddControllers();

            // //dbContextdeki option u belirteceğimiz yer burası
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:DefaultConnection"].ToString(), o =>
                {
                    //AppDbContexti data class libraryden almak için
                    o.MigrationsAssembly("Proje.Data");
                });
            });

            services.AddIdentity<Kullanici, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;


                
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //DEPENDENCY İNJECTİON AYARI
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
             services.AddScoped(typeof(IGuidRepository<>), typeof(GuidRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped(typeof(IGuidService<>), typeof(Service.Services.GuidService<>));
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IStokService, StokService>();
            services.AddScoped<ICariService, CariService>();

            //AddScoped => bir request esnasında bir class'ın constructorunda IUnitOfWork ile karşılaşırsa UnitOfWork den bir nesne örneği alacak eğer bir request içerisinde birden fazla IUnitOfWork ile karşılaşırsa aynınesne örneği üzerinden devam edecek

            //Bir request esnasında birden fazla ihtiyaç olursa ilk oluşturduğu nesne örneğini kullanır
            services.AddScoped<IUnitOfWork, UnitOfWork>();


         services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Music", Version = "v1" });
                
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                var security =
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                },
                                UnresolvedReference = true
                            },
                            new List<string>()
                        }
                    };
                options.AddSecurityRequirement(security);
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddAuth(jwtSettings);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseAuthorization();
            app.UseAuth();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
            });
        }
    }
}
