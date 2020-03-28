using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using jkMovie.Application;
using jkMovie.Application.Common.AutoMapperExtension;
using jkMovie.Application.Common.Interfaces;
using jkMovie.Controllers;
using jkMovie.Infrastructure.Data;
using jkMovie.Infrastructure.Services;

namespace jkMovie.App_Start
{
    public static class Autofac
    {
        public static void Config()
        {
            var container = new ContainerBuilder();

            container.RegisterType<LogService>().As<ILogService>();
            container.RegisterType<TMDBService>().As<ITmdbService>();
            container.RegisterType<HomeController>().InstancePerRequest();
            container.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            container.RegisterType<MovieRepository>().As<IMovieRepository>();
            container.RegisterType<TvRepository>().As<ITvSerieRepository>();
            container.RegisterType<Connection>().As<IConnection>();
            //container.RegisterType<Facade>().As<IFacade>();

            container.Register(x => new MapperConfiguration(Y => Y.AddProfile(new MyProfile())));
            container.Register(x => x.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            var builder = container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder));
        }
    }
}