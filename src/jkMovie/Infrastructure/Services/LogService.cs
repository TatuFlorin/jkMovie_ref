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

    public class LogService : ILogService
    {

        private static ILog _log;

        public void Loggin(LogLevels logLevels, string typeOf, object message)
        {

            _log = LogManager.GetLogger(typeOf);

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