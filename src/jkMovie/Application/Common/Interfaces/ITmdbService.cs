using jkMovie.Application.Common.Dtos;
using jkMovie.Application.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jkMovie.Application.Common.Interfaces
{
    public interface ITmdbService
    {
        Task<ApiResponseDto<T>> GetAllAsync<T>(string keyword, int? page)
            where T : class;
        Task<T> GetByIdAsync<T>(int id)
            where T : class;
        Task<SeasonDto> GetSeasonAsync(int id, int season_number);
        Task<TrailerListDto> GetTrailers(MediaType mediaType, int id);
    }
}
