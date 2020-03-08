using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using jkMovie.Application.Common.Interfaces;
using jkMovie.Infrastructure.Services;

namespace jkMovie.App_Start
{
    public static class Autofac
    {
        public static void Config()
        {
            var container = new ContainerBuilder();

            container.RegisterType<LogService>().As<ILogService>();


            var builder = container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder));
        }
    }
}