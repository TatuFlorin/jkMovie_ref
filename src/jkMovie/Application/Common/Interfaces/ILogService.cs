using jkMovie.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Interfaces
{
    public interface ILogService
    {
        void Loggin(LogLevels logLevels, string typeOf, object message);
    }
}