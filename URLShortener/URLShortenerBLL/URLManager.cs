using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;
using URLShortener.BLL.Helper;
using URLShortener.Entities;
using URLShortenerBLL.Interface;
using URLShortenerDAL.Interface;

namespace URLShortenerBLL
{
    public class URLManager : IURLManager
    {
        private IURLRepository _uRLRepository;
        private readonly string _domainName;
        public URLManager(IURLRepository uRLRepository, IConfiguration configuration)
        {
            _uRLRepository = uRLRepository;
            _domainName = configuration["DomainName"];
        }

        public async Task<string> GetByShortURL(string shortUrl)
        {
            var res = await _uRLRepository.GetByShortURL(shortUrl);
            return res.LongURL;
        }

        public async Task<string> AddNewURL(string longUrl)
        {
            var newEntry = new URLLookUp() {
                CreatedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddYears(10),
                LongURL = WebUtility.UrlDecode(longUrl),
                ShortURL = Helper.RandomString(7)                
            };

            var newCode = await TryAddURL(newEntry);
            return $"{_domainName}/{newCode}";
        }

        private async Task<string> TryAddURL(URLLookUp newEntry)
        {
            var notInserted = true;
            while (notInserted)
            {
                try
                {
                    await _uRLRepository.InsertNewURL(newEntry);
                }
                catch (Exception ex)
                {
                    if (!ex.Message.ToLower().Contains("constraint failed"))
                        throw ex;

                    newEntry.ShortURL = Helper.RandomString(7);
                    continue;
                }
                notInserted = false;
            }
            return newEntry.ShortURL;
        }
    }
}
