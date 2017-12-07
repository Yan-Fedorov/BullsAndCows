using System;
using BullsAndCows.Oop.GameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.ProSolwer;
using Autofac;
using BullsAndCows.Oop;

namespace BullsAndCows
{
    public class IoCBuilder
    {
        public static IContainer Building()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Builder>()
                .AsSelf()
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<TemporaryStorage>().AsImplementedInterfaces();
            builder.RegisterType<GameDataService>().As<IGameDataService>();
            builder.RegisterType<GamerConsoleInput>().As<IGamerConsoleInput>();
            builder.RegisterType<GamerConsoleOutput>().As<IGamerConsoleOutput>();
            builder.RegisterType<GameLoader>().As<IGameLoader>().InstancePerLifetimeScope();
  
            builder.RegisterType<OopRunner>().As<OopRunner>();
            builder.RegisterType<OopMenu>().As<OopMenu>();
            return builder.Build();
        }
    }
}
////var cb = new ContainerBuilder();
//cb.RegisterType<DependsByProp1>()
//  .InstancePerLifetimeScope()
//  .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
//.SingleInstance()
