
 using System;
 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
 using Microsoft.EntityFrameworkCore;
using Global.DataAccess.Data;
 using Global.DataAccess.Data.Table;
 using Global.Domain.Helper;
 using Global.Domain.Repository;
 using Global.Domain.Repository.Interface;
 using Microsoft.AspNetCore.Identity;

 namespace Global.Api
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
            //DB related service registration
            services.AddDbContext<FunBooksAndVideosStoreDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("BookstoreDB")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<FunBooksAndVideosStoreDbContext>()
                .AddDefaultTokenProviders();
           // services.AddScoped<DbInitializer>();

            //web Api controller service registration
            services.AddControllers();
          
            //Mapper service registration 
            services.AddAutoMapper(typeof(ApplicationMapper));

            services.AddTransient<IMembershipRepository,MembershipRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<IPurchaseRepository, PurchaseRepository>();

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval =TimeSpan.Zero;
            });

            //swagger registration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Global.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Global.Api v1"));
            }

            app.UseHttpsRedirection();

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
