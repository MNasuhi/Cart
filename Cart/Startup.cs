using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Interfaces;
using Business.Services;
using Data.Helpers;
using DataAccess.Helper;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cart
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
            services.AddDbContext<MyDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductsInCartRepository, ProductsInCartRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IProductsInCartService, ProductsInCartService>();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddMvc().AddControllersAsServices().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpContextAccessor();
        }
        public IContainer ApplicationContainer { get; private set; }    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
