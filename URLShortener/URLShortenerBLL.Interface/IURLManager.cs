using System;
using System.Threading.Tasks;

namespace URLShortenerBLL.Interface
{
    public interface IURLManager
    {
        Task<string> GetByShortURL(string shortUrl);
        Task<string> AddNewURL(string longUrl);
    }
}
