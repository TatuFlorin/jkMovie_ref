using jkMovie.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Entities = jkMovie.Domain.Entities;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace jkMovie.Infrastructure.Data
{
    public class EpisodeRepository : BaseRepository, IEpisodeRepository
    {
        public EpisodeRepository(IDbTransaction transaction)
           : base(transaction){}

        public async Task AddAsync(Entities.Episode entity)
        {
            try
            {
                var command = "episode_save";

                var param = new DynamicParameters();
                param.Add("@tvId", entity.tvId);
                param.Add("@seasonNumber", entity.seasonNumber);
                param.Add("@videoSource", entity.videoSource);
                param.Add("@episodeNumber", entity.episodeNumber);

                await connection.ExecuteAsync(command, param, transaction, commandType: CommandType.StoredProcedure);

                //return new ResponseMessage("Episode was added with success.");
            }
            catch
            {
                //return new ResponseMessage(ex.Message);
                throw;
            }
        }

        public async Task<int> Count(int seasonNumber, int tv_id)
        {
            var query = "episode_getEpisodesBySeason";
            var param = new DynamicParameters();
            param.Add("@Id", tv_id);
            param.Add("@seasonNumber", seasonNumber);

            var episodes = await connection.QueryAsync<Entities.Episode>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return episodes.Count();
        }

        public async Task<bool> Find(int id, int episode_number, int season_number)
        {
            string query = "episode_find";

            var param = new DynamicParameters();
            param.Add("@tvid", id);
            param.Add("@episodeNumber", episode_number);
            param.Add("@seasonNumber", season_number);

            var response = await connection.ExecuteScalarAsync<bool>(query, param, transaction: transaction, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<IEnumerable<Entities.Episode>> GetEpisodesBySeason(int id, int seasonNumer)
        {
            var query = "episode_getEpisodesBySeason";
            var param = new DynamicParameters();
            param.Add("@Id", id);
            param.Add("@seasonNumber", seasonNumer);

            var episodes = await connection.QueryAsync<Entities.Episode>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return episodes;
        }

        public async Task<Entities.Episode> GetLastEpisode(int id)
        {
            var query = "episode_getLastEpisode";
            var param = new DynamicParameters();
            param.Add("@Id", id);

            var episodes = await connection.QueryAsync<Entities.Episode>(query, param, transaction, commandType: CommandType.StoredProcedure);

            return episodes.LastOrDefault();
        }

        public async Task<string> GetVideoSource(int id, int episodeNumber, int seasonNumber)
        {
            var query = "episode_getVideoSource";
            var param = new DynamicParameters();
            param.Add("@Id", id);
            param.Add("@seasonNumber", seasonNumber);
            param.Add("@episodeNumber", episodeNumber);

            var video_source = await connection.QueryAsync<string>(query, param, transaction, commandType: CommandType.StoredProcedure);
            return video_source.FirstOrDefault().ToString();
        }

        public void Remove(Entities.Episode entity)
        {
            string command = "episode_remove";

            var param = new DynamicParameters();
            param.Add("@Id", entity.Id);

            connection.Execute(command, param, transaction, commandType: CommandType.StoredProcedure);
        }

    }
}