using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Passengers.Infrastructure.Commands.User;
using Passengers.Infrastructure.Commands;
using System.Reflection;

namespace Passengers.Infrastructure.IoC.Modules
{
    //To let know applicatin for commant <T> type use CommandHandler <T> type 


    //Aufotfac is library which scanning whole project and automaticly  registering class like implementation of interface  

   public  class CommandModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //set what we want to register ( like in startup.cs )
            //register CommandDispatcher class like implementaion ICommandDisparcher interface 
            builder.RegisterType<CommandDispatcher>().As<ICommandDispatcher>()
                .InstancePerLifetimeScope();  //life cycle per HTTP request for  single user

            //owing to this application knows how suits command for commandHandler
            //we're taking assembly (.dll file with source code ) 
            //we want to have assembly only for Passengers.Infrastructure 
            // so we must take type any class which is inside of .dll file in Passengers.Infrastructure   
               var assembly = typeof(CommandModule)
                .GetTypeInfo()//take infomration about type
                .Assembly;//take assembly

            //this taking and scanning assembly (wgole Passengers.Infrastructure ) in order to find types which we are interested
            //take whole clasess ane interafaces in this project and then register it like closed types so implementation ICommandHandler interafce
            //Autofac will do thic method automaticaly otherwise i would must write code for each registration manually , owing to Autofac i can save unlimited numerous of code 
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();
           
                
             
        }
    }
}
