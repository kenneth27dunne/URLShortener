# URLShortener API

**Created with**

C# .Net Core 3.1 Web API
DB SQLITE
Visual Studio 2019

**Introduction**

The idea is to create an API which can be implemented by any front end technology. The API is quite simple with just two endpoints. /GetByShortURL and /Generate/ShortURL.
The default page when the project is run will be the Swagger UI. There you can call each endpoint without the need of postman etc.

**GetByShortURL**

This endpoint wil allow the user to pass in our previously generated short URL and will return the full original URL. 

**Generate/ShortURL**

This endpoint will store the URL passed in and return the newly generated short URL.

**Getting Started**

open the fileURLShortener.sln in visual studio. Run the project URLShortener.API by clicking The IIS Express button on the top of the window. To test the endpoints first test the **Generate/ShortURL** endpoint but passing in a web url. You can then use the small URL response from that endpoint to pass into **GetByShortURL**. This will return the original long URL.
