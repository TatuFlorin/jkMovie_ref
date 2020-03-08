using jkMovie.Application.Common.Enums;
using jkMovie.Application.Common.Interfaces;
using jkMovie.Domain.Entities;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Infrastructure.Services
{

    public class LogService<T> : ILogService
    {

        private static readonly ILog _log = LogManager.GetLogger(typeof(T));

        public void Loggin(LogLevels logLevels, object message)
        {
            switch (logLevels)
            {
                case LogLevels.DEBUG:
                    _log.Debug(message);
                    break;
                case LogLevels.INFO:
                    _log.Info(message);
                    break;
                case LogLevels.WARN:
                    _log.Warn(message);
                    break;
                case LogLevels.ERROR:
                    _log.Error(message);
                    break;
                case LogLevels.FATAL:
                    _log.Fatal(message);
                    break;
                default:
                    break;
            }
        }
    }
}