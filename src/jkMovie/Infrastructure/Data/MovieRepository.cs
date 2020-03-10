using jkMovie.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Entities = jkMovie.Domain.Entities;
using System.Threading.Tasks;

namespace jkMovie.Infrastructure.Data
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(IDbTransaction transaction) : base(transaction){}

        public async Task AddAsync(Entities.Movie entity)
        {
            var ex = await FindAsync(entity.Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            else if (!ex)
            {
                var query = "movie_save";
                var param = new DynamicParameters();
                param.Add("@Id", entity.Id);
                param.Add("@title", entity.title);
                param.Add("@poster", entity.poster);
                param.Add("@voteAverage", entity.voteAverage);
                param.Add("@videoSource", entity.videoSource);
                param.Add("@isPosted", entity.IsPosted);

                await connection.ExecuteScalarAsync(query, param, commandType: System.Data.CommandType.StoredProcedure, transaction: transaction);
            }
            else
            {
                
            }
        }

        public async Task<bool> FindAsync(int id)
        {
            var query = "movie_find";

            var param = new DynamicParameters();
            param.Add("@Id", id);

            var result = await connection.ExecuteScalarAsync<bool>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<Entities.Movie>> GetAllAsync()
        {
            string query = "movie_getAll";

            return await connection.QueryAsync<Entities.Movie>(query, null, transaction, commandType: CommandType.StoredProcedure);

        }

        public async Task<Entities.Movie> GetByIdAsync(int id)
        {
            string query = "movie_getById";
            var param = new DynamicParameters();
            param.Add("@Id", id);

            var result = await connection.QueryAsync<Entities.Movie>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Entities.Movie>> GetByTitleAsync(string title)
        {
            var query = "movie_getByTitle";
            var param = new DynamicParameters();

            param.Add("@title", title);

            var result = await connection.QueryAsync<Entities.Movie>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public void Remove(Entities.Movie entity)
        {
            string command = "movie_remove";
            var param = new DynamicParameters();
            param.Add("@Id", entity.Id);

            connection.Execute(command, param, transaction, commandType: CommandType.StoredProcedure);
        }

    }
}