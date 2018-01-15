using System;
using BullsAndCows.Oop.OopGameLoader;
using BullsAndCows.Oop.GamerConsol;
using BullsAndCows.Oop.Menu;
using BullsAndCows.Oop.Runner;
using BullsAndCows.Oop.Solwer;
using BullsAndCows.Oop.Thinker;
using BullsAndCows.Oop.GameData;
using BullsAndCows.Oop.ProSolwer;
using BullsAndCows.Oop.ProfessionalSolwer;
using Autofac;
using Autofac.Extras.NLog;
using BullsAndCows.Oop;
using BullsAndCows.Oop.ActiveGame;

namespace BullsAndCows
{
    public class IoCBuilder
    {
        public static IContainer Building()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TemporaryStorage>().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<GameDataService>().As<IGameDataService>()
                .SingleInstance();

            builder.RegisterType<GamerConsoleInput>().AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterType<GamerConsoleOutput>().AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<Builder>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //TODO: подмать в каком он скоупе, можер выделить метод GetGameNames в отдельный сингл инстанс
            builder.RegisterType<GameLoader>().As<IGameLoader>();
                //.InstancePerLifetimeScope();

            builder.RegisterType<OopSolwer>().AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<OopThinker>().AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<OopProSolwer>().AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<SolwerDividesBy3>().AsSelf()
                .InstancePerLifetimeScope();
            // регистрация как самого себяя или интерфейс
            // InstancePerLifetimeScope и какие ещё есть

            builder.RegisterType<ActiveGameService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<OopRunner>()
                .As<OopRunner>()
                .As<IOopRunner>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OopMenu>().AsSelf().AsImplementedInterfaces()
                //.InstancePerLifetimeScope();
                .SingleInstance();
            //builder.RegisterType<OopMenu>().As<OopMenu>();

            builder.RegisterModule<NLogModule>();

            return builder.Build();
        }
    }
}
////var cb = new ContainerBuilder();
//cb.RegisterType<DependsByProp1>()
//  .InstancePerLifetimeScope()
//  .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
//.SingleInstance()
