using jkMovie.Application.Common.Dtos;
using jkMovie.Application.Common.Enums;
using jkMovie.Application.Common.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace jkMovie.Infrastructure.Services
{
    public class TMDBService : ITmdbService
    {

        protected readonly HttpClient _client; 
        protected string apiKey = "eae87eb82946d10df6c0af5bc517d061";

        public TMDBService()
        {
            this._client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(System.Net.Http.Headers
                .MediaTypeWithQualityHeaderValue.Parse("application/json"));
        }

        public async Task<ApiResponseDto<T>> GetAllAsync<T>(string keyword, int? page) where T : class
        {
            var urn = string.Empty;
            var mediaType = string.Empty;
            var typeOfT = typeof(T).Name;

            if (typeOfT.ToLower().Contains("movie"))
            {
                urn = $"search/movie?api_key={apiKey}" +
                          $"&language=en-US&query={ keyword }" +
                          $"&page={ page ?? 1 }&include_adult=false";
                mediaType = "movie";
            }
            else if (typeOfT.ToLower().Contains("tvserie"))
            {
                urn = $"search/tv?api_key={apiKey}" +
                          $"&language=en-US&query={ keyword }" +
                          $"&page={ page ?? 1 }&include_adult=false";
                mediaType = "tv";
            }
            else
            {
                throw new Exception();
            }

            using (HttpResponseMessage response = await _client.GetAsync(urn))
            {
                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<ApiResponseDto<T>>(results);

                    return new ApiResponseDto<T>(
                        mediaType
                        , keyword
                        , res.Page
                        , res.Results
                        , res.Total_pages
                        , res.Total_results);
                }
                else { throw new Exception(); }
            }
        }

        public async Task<T> GetByIdAsync<T>(int id) 
            where T : class
        {
            var typeOfT = typeof(T).Name;
            var urn = string.Empty;

            if (typeOfT.ToLower().Contains("movie"))
            {
                urn = $"movie/{ id }?api_key={ apiKey }&language=en-US";
            }
            else if(typeOfT.ToLower().Contains("tvserie"))
            {
                urn = $"tv/{ id }?api_key={ apiKey }&language=en-US";
            }
            else
            {
                throw new Exception();
            }

            using (HttpResponseMessage response = await _client.GetAsync(urn))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<T>(result);

                    return res;
                }
                else { throw new Exception(); }
            }
        }

        public async Task<SeasonDto> GetSeasonAsync(int id, int season_number)
        {
            var urn = $"tv/{ id }/season/{ season_number }?api_key={ apiKey }&language=en-US)";

            using (HttpResponseMessage response = await _client.GetAsync(urn))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<SeasonDto>(result);

                    return res;
                }
                else { throw new Exception(); }
            }
        }

        public async Task<TrailerListDto> GetTrailers( MediaType mediaType, int id)
        {
            var urn = string.Empty;

            switch (mediaType)
            {
                case MediaType.Movie:
                    urn = $"movie/{ id }/videos?api_key={ apiKey }&language=en-US";
                    break;
                case MediaType.TvSerie:
                    urn = $"tv/{ id }/videos?api_key={ apiKey }&language=en-US";
                    break;
                default:
                    throw new Exception();
            }

            using (HttpResponseMessage response = await _client.GetAsync(urn))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var res = JsonConvert.DeserializeObject<TrailerListDto>(result);

                    return res;
                }
                else { throw new Exception(); }
            }
        }
    }
}