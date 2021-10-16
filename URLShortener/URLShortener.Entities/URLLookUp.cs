using System;

namespace URLShortener.Entities
{
    public class URLLookUp
    {
        public int Id { get; set; }
        public string ShortURL { get; set; }
        public string LongURL { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
