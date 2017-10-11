using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    //first of all we must to say our database how to connect with database
  public  class MongoModule
    {
        //MongoClient must be singleton whera libray mange connection with database
        builder.Register((c,p)=>
            {

            //take settings
            var settings = c.Resolve<MongoSettings>();

            return new MongoClient(settings.ConnectionString)
            }).SingleInstance();



    //add mongodatabase implementation
    builder.Register((c,p)=>
            {
            var client = c.Resolve<MongoClient>();

    //take settings
    var settings = c.Resolve<MongoSettings>();


   var database = client.GetDatabase(settings.Database);

            return  database;
            }).As<IMongoDatabase>();



        var assembly = typeof(MongoModule)
                 .GetTypeInfo()
                 .Assembly;

        builder.RegisterAssemlbyTypes(assembly)
            .Where(x=>x.IsAssignableTo<IMongoRepository>()),
        .AsImplementedInterfaces()
        .InstancePerLifeTimeScope();
    }
}
