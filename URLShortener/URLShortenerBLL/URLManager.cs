using System;
using System.Threading.Tasks;
using URLShortenerBLL.Interface;
using URLShortenerDAL.Interface;

namespace URLShortenerBLL
{
    public class URLManager : IURLManager
    {
        private IURLRepository _uRLRepository;

        public URLManager(IURLRepository uRLRepository)
        {
            _uRLRepository = uRLRepository;
        }

        public async Task<string> GetByShortURL(string shortUrl)
        {
            var res = await _uRLRepository.GetByShortURL(shortUrl);
            return res.LongURL;
        }
    }
}
