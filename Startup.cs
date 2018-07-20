using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formatters;
using Lamar;
using LamarDI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LamarDI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ServiceRegistry services)
        {
            services
                .AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // ASP.Net services api is still available
            // make a concrete implementation available for any general usages
            services.AddTransient<IFormatter, BasicFormatter>();

            // specify the implementations passed to the controller's constructor explictily
            services
                .ForConcreteType<StudentsController>().Configure
                .Scoped()
                    .Ctor<IFormatter>("formatter").Is<BasicFormatter>()
                    .Transient()
                    .Ctor<IFormatter>("fancyFormatter").Is<FancyFormatter>()
                    .Transient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
        }
    }
}
