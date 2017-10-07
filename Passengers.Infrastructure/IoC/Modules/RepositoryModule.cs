using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.IoC.Modules
{
 public   class RepositoryModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //scanning whole assembly ot find  proper type s
            var assembly = typeof(RepositoryModule)
               .GetTypeInfo()
               .Assembly();


            //Register types form assembly
            //Life time per HTTP request
            builder.RegisterAssemblyTypes(assembly)
                 .Where(x => x.IsAssignableTo<IRepository>())
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

        }
    }
}
