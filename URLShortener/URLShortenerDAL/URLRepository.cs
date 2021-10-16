using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLShortener.Entities;
using URLShortenerDAL.Interface;

namespace URLShortenerDAL
{
    public class URLRepository : BaseRepository, IURLRepository
    {
        public URLRepository(IConfiguration configuration) : base($"{ configuration["ConnectionStrings:DefaultConnection"] }")
        {

        }

        public async Task<URLLookUp> GetByShortURL(string shortURL)
        {
            try
            {
                var result = await QueryAsync<URLLookUp>("SELECT * FROM UrlLookUp WHERE ShortURL = @shortUrl", new { shortURL });

                if (result.Count() == 1)
                    return result.FirstOrDefault();

                throw new Exception($"Short code resulted in {result.Count()} URLs");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task InsertNewURL(URLLookUp longURL)
        {
            await ExecuteAsync("Insert into UrlLookUp ", new { longURL });
        }
    }
}
