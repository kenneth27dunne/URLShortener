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
        public URLRepository(IConfiguration configuration) : base(configuration["ConnectionStrings:DefaultConnection"])
        {

        }

        const string getByShortURL = "SELECT * FROM UrlLookUp WHERE ShortURL = @shortUrl and ExpiresOn > @now";
        const string insertNewURL = @" INSERT INTO UrlLookUp (ShortURL, LongURL, CreatedOn, ExpiresOn) 
                                    VALUES (@ShortURL, @LongURL, @CreatedOn, @ExpiresOn)";

        public async Task<URLLookUp> GetByShortURL(string shortURL)
        {
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");

            var result = await QueryAsync<URLLookUp>(getByShortURL, new { shortURL, now });

            if (result.Count() == 1)
                return result.FirstOrDefault();

            throw new Exception($"Short code resulted in {result.Count()} URLs");
        }

        public async Task InsertNewURL(URLLookUp newEntry)
        {
            await ExecuteAsync(insertNewURL, new { 
                newEntry.LongURL,
                newEntry.ShortURL,
                CreatedOn = newEntry.CreatedOn.ToString("yyyy-MM-dd HH:MM:ss"),
                ExpiresOn = newEntry.ExpiresOn.ToString("yyyy-MM-dd HH:MM:ss")
            });
        }
    }
}
