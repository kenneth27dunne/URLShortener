# URLShortener API

**Created with**
C# .Net Core 3.1 Web API
DB SQLITE

**Introduction**
The idea is to create an API which can be implemented by any front end technology. The API is quite simple with just two endpoints. /GetByShortURL and /Generate/ShortURL.
The default page when the project is run will be the Swagger UI. There you can call each endpoint without the need of postman etc.

**GetByShortURL**
This endpoint wil allow the user to pass in our previously generated short URL and will return the full original URL. 

**Generate/ShortURL**
This endpoint will store the URL passed in and return the newly generated short URL.
