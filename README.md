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

open the file URLShortener.sln in visual studio. 
You will need to ensure the project is run with SSL enabled. You can do so by right clicking the project **URLShortener** and go to properties. In properties go to debug and tick the enable ssl checkbox. If the ssl app URL is not https://localhost:44391 then you will need to update the "DomainName" value in the appsettings.json located in the **URLShortener** project. Run the project URLShortener by clicking The IIS Express button on the top of the window. 

Once the application is up and running you will see a form with one field. Simply paste in the Long URL into the field and submit. You will then find your newly generated short url. 
