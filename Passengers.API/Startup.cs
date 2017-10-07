using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Passengers.Core.Services;
using Passengers.Core.Repositories;
using Passengers.Infrastructure.Mapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Passengers.Infrastructure.IoC.Modules;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using Passengers.Infrastructure.Settings;
using System.Text;
using Newtonsoft.Json;
using Passengers.API.Freamwork;
using Microsoft.AspNetCore.Builder;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Passengers.API
{
    public class Startup
    {
        public AutoMapper.Configuration.IConfiguration Configuration { get; }


        //it's keeping configuration for my new IoC contianer, to know what  class implementaion injecting to what interface 
        public IContainer ApplicationContainer { get; private set; }

      //using Dependency injection
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration =builder.Build();

          
        }

         

        // This method gets called by the runtime. Use this method to add services to the container.

            //IServiceProvider allows  replace default IoC contianer on my own
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {//I use singleton that's why i want to have only one configuration in whole application

            //add authorization by user's role or other requirements
            services.AddAuthorization(x=>x.AddPolicy("Admin",p=>p.RequireRole("admin")));


            services.AddSingleton(AutoMapperConfig.Initialize());


            // Add framework services.
            //by added AddJsonOptione out API will be showing in better format  (more user friendly)
            services.AddMvc().AddJsonOptions(x=>x.SerializerSettings.Formatting=Formatting.Indented);

            //to let freamwrok know how inject IMemoryCache instance
            services.AddMemoryCache();

            //I create new object per HTTP request 
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,InMemoryUserRepository>();

            var builder2 = new ContainerBuilder();

            //owing to Populate method my new IoC container will be right with  other configuration 
            builder2.Populate(services);

            //I'm saying application to use CommandModule( where is being used Autofac ) 
            builder2.RegisterModule( new ContainerModule(Configuration));
            //here container is built 
            ApplicationContainer = builder2.Build();

            

            //at the end  I return implementation of this interafce to Autofac library would agree with Net.Core
            return new AutofacServiceProvider(ApplicationContainer);
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IApplicationLifetime lifeTime)
        {


            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("nlog.config");

            //I can evoke each services which i registered 
            var jwtSettings2 = app.ApplicationServices.GetService<jwtSettings>();


            //we use jwtSettings to get our key 


            app.UseJwtBearerAuthentication(new Microsoft.AspNetCore.Builder.JwtBearerOptions
            {

                // it uses name/password to properly set ID
                AutomaticAuthenticate = true,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    //who can issue token
                    //only localhost 5000 can generate token
                    ValidIssuer = jwtSettings2.Issuer,

                    //token can be generated only for specifices domen
                    //here is set-for all
                    ValidateAudience = false,

                    //how key is created/signed
                    //in this case key is from settings of our application
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings2.Key)),

                },

            });
            //Remove  unnecessary dependencies  
            lifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());


            //place where we want to initialzie data
            var genearlSettings = app.ApplicationServices.GetService<GeneralSettings>();
            //checking SeatData flag( true or not)
            if (genearlSettings.SeatData)
            {
                //download IDateInitiazlie from IoC container and evoke Seat method
                var dataInitialzie = app.ApplicationServices.GetService<IDataInitialize>();
                dataInitialzie.Sead();
            }

            app.UseExceptionHandlera();
            NewMethod(app);
        }

        private static void NewMethod(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
