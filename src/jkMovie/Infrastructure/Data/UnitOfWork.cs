using jkMovie.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jkMovie.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IMovieRepository _movies;
        private ITvSerieRepository _tv;
        private IEpisodeRepository _episodes;
        private bool _disposed;

        public IMovieRepository Movies
        {
            get { return _movies ?? (this._movies = new MovieRepository(_transaction)); }
        }

        public ITvSerieRepository TvSeries
        {
            get { return _tv ?? (this._tv = new TvRepository(_transaction)); }
        }

        public IEpisodeRepository Episodes
        {
            get { return _episodes ?? (this._episodes = new EpisodeRepository(_transaction)); }
        }


        public UnitOfWork(
            IConnection connectionString
            )
        {
            this._connection = new SqlConnection(connectionString.GetConnectionString());
            _connection.Open();
            this._transaction = _connection.BeginTransaction();
        }

        public void Complete()
        {
            try
            {
                _transaction.Commit();
            }
            catch 
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if(!_disposed)
            {
                if (dispose)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        private void ResetRepositories()
        {
            this._movies = null;
            this._tv = null;
            //this._episodes = null;
        }
    }
}