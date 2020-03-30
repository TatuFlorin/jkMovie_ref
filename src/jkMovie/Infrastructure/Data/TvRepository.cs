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
    public class TvRepository : BaseRepository, ITvSerieRepository
    {
        public TvRepository(IDbTransaction transaction) : base(transaction) { }

        public async Task AddAsync(Entities.TvSerie entity)
        {
            var ex = await FindAsync(entity.Id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }
            else if (!ex)
            {
                var command = "tvserie_save";
                var param = new DynamicParameters();
                param.Add("@Id", entity.Id);
                param.Add("@title", entity.title);
                param.Add("@poster", entity.poster);
                param.Add("@voteAverage", entity.voteAverage);
                param.Add("@isPosted", entity.IsPosted);
                param.Add("@numberOfSeasons", entity.NumberOfSeasons);

                await connection.ExecuteAsync(command, param, transaction, commandType: CommandType.StoredProcedure);
            }
            else
            {
                //return new ResponseMessage("This TvSerie already exist in database.");
            }
        }

        public async Task<bool> FindAsync(int id)
        {
            var query = "tvserie_find";

            var param = new DynamicParameters();
            param.Add("@Id", id);

            var result = await connection.ExecuteScalarAsync<bool>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task<IEnumerable<Entities.TvSerie>> GetAllAsync()
        {
            var query = "tvserie_getAll";

            return await connection.QueryAsync<Entities.TvSerie>(query, null, transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<Entities.TvSerie> GetByIdAsync(int id)
        {
            var query = "tvserie_getById";

            var param = new DynamicParameters();
            param.Add("@Id", id);

            var  result = await connection.QueryAsync<Entities.TvSerie>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Entities.TvSerie>> GetByTitleAsync(string title)
        {
            string query = "tvserie_getByTitle";

            var param = new DynamicParameters();
            param.Add("@title", title);

            var result = await connection.QueryAsync<Entities.TvSerie>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        public void Remove(Entities.TvSerie entity)
        {
            string command = "tvserie_remove";
            var param = new DynamicParameters();
            param.Add("@Id", entity.Id);

            connection.Execute(command, param, transaction, commandType: CommandType.StoredProcedure);
        }

    }
}