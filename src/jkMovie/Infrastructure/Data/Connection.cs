using jkMovie.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace jkMovie.Infrastructure.Data
{
    public class Connection : IConnection
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MovieDB"].ConnectionString;
        }
    }
}