using Backend_Login_Register_Task.Data;
using Backend_Login_Register_Task.DTOMapping;
using Backend_Login_Register_Task.Repository;
using Backend_Login_Register_Task.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Login_Register_Task
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
            string cs = Configuration.GetConnectionString("consr");
            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>
             (option => option.UseSqlServer(cs));
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOption>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IEncryptionRepository, EncryptionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //JWt Authentication
            var AppSettingSection = Configuration.GetSection("Appsetting");
            services.Configure<AppSetting>(AppSettingSection);
            var AppSetting = AppSettingSection.Get<AppSetting>();
            var Key = Encoding.ASCII.GetBytes(AppSetting.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers();
         


            //services.AddAuthentication().AddGoogle(option =>
            //{
            //    option.ClientId = "751737151287-paofm1bd14rkk7mopijg991keil4ssb1.apps.googleusercontent.com";
            //    option.ClientSecret = "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";
            //});

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend_Login_Register_Task", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "My Police",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend_Login_Register_Task v1"));
            }
            app.UseAuthentication();

            app.UseCors("My Police");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
