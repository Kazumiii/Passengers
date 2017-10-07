using Autofac;
using AutoMapper.Configuration;
using Passengers.Infrastructure.Extensions;
using Passengers.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.IoC.Modules
{

    //keep configuration which was was in startup.cd project
 public   class ContainerModule:Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule(new SettingModule(_configuration));
        }
    }

}
