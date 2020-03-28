using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"{ name } with id { key } wasn't found!")
        {
        }
    }
}