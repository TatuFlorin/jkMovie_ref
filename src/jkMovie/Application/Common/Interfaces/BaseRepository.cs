using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.Interfaces
{
    public abstract class BaseRepository
    {

        protected IDbTransaction transaction { get; }
        protected IDbConnection connection { get { return transaction.Connection; } }

        public BaseRepository(IDbTransaction _transaction)
        {
            this.transaction = _transaction;
        }

    }
}