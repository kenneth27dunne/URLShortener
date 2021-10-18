# URLShortener API

**Created with**

C# .Net Core 3.1 
DB SQLITE
Visual Studio 2019

**Getting Started**

open the file URLShortener.sln in visual studio. 
You will need to ensure the project is run with SSL enabled. You can do so by right clicking the project **URLShortener** and go to properties. In properties go to debug and tick the enable ssl checkbox. If the ssl app URL is not https://localhost:44391 then you will need to update the "DomainName" value in the appsettings.json located in the **URLShortener** project. Run the project URLShortener by clicking The IIS Express button on the top of the window. 

Once the application is up and running you will see a form with one field. Simply paste in the Long URL into the field and submit. You will then find your newly generated short url. 
