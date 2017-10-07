using Autofac;
using Passengers.Core.Repositories;
using Passengers.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.IoC.Modules
{
  public  class ServiceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //scanning whole assembly ot find  proper type s
            var assembly = typeof(ServiceModule)
               .GetTypeInfo()
               .Assembly();


            //Register types form assembly
            //Life time per HTTP request
            //Automatic way to register class which implement IRepositroy
            builder.RegisterAssemblyTypes(assembly)
                 .Where(x => x.IsAssignableTo<IService>())
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();



            builder.RegisterType<Encrypter>()
                .As<IEncrypt>()
                .SingleInstance();

            builder.RegisterType<JwtHandler>()
                .As<IjwtHandler>()
                .SingleInstance();
        }
    }
}
