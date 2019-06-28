using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RobotApp.Database;
using RobotApp.Models;
using RobotApp.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Types;

namespace RobotApp
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
            services.AddHttpContextAccessor();
            services.AddSingleton<ContextServiceLocator>();
            services.AddTransient<IRobotRepository, RobotRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<RobotQuery>();
            services.AddSingleton<RobotMutation>();
            services.AddSingleton<RobotType>();
            services.AddSingleton<RobotInputType>();
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new RobotSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            services.AddDbContext<RobotContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RobotContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            db.Database.EnsureCreated();
            if (!db.Robots.Any())
            {
                StreamReader r = new StreamReader("bots.json");
                string json = r.ReadToEnd();
                List<Robot> bots = JsonConvert.DeserializeObject<List<Robot>>(json);
                db.AddRange(bots);
                db.SaveChanges();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
