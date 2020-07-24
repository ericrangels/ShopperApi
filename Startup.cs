﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ShopperApi.Data;
using ShopperApi.Services;

namespace ShopperApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Versioning
            services.AddApiVersioning();
            // Media Type - Header > [{"key":"Accept","value":"application/json;v=1.0"}]
            //services.AddApiVersioning(v=>v.ApiVersionReader=new MediaTypeApiVersionReader());

            // Repository
            services.AddDbContext<ShopDbContext>(option => option.UseSqlServer(@"Data Source=ERICRANGEL6DE7\SQLEXPRESS;Initial Catalog=SHOP;Integrated Security=true;"));
            services.AddScoped<IAccount, AccountRepository>();
            services.AddScoped<ICustomer, CustomerRepository>();

            //Documentation - Swagger
            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Shopper Api", Version = "v1" }));
            
            // To return XML content - Header > [{"key":"Accept","value":"application/xml"}]
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlDataContractSerializerFormatters();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ShopDbContext shopDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Repository - Create Database
            shopDbContext.Database.EnsureCreated();

            //Documentation - Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s=>s.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopper - Api operations"));
        }
    }
}
