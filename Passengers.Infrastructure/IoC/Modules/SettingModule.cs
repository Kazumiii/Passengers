using Autofac;
using AutoMapper.Configuration;
using Passengers.Core.Mongo;
using Passengers.Core.Services;
using Passengers.Infrastructure.Commands;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Extensions;
using Passengers.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passengers.Infrastructure.IoC.Modules
{
    public class SettingModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //register instance like singleton and use GetSettings methoda from SettingsExtenisons class
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<jwtSettings>()).SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()).SingleInstance();

        }
    }
}
