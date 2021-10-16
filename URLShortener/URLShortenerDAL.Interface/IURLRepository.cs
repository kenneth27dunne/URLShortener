using System;
using System.Threading.Tasks;
using URLShortener.Entities;

namespace URLShortenerDAL.Interface
{
    public interface IURLRepository
    {
        Task<URLLookUp> GetByShortURL(string shortURL);
        Task InsertNewURL(URLLookUp longURL);        
    }
}
