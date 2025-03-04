# SQL Database and API

## Description
My goal was to build out a SQL Database and API in C#. Using Dapper and Aspnet Core MVC.

First I randomly generated User json data from randomuser.me.
* https://randomuser.me/api?nat=US&results=100&seed=vitelli&format=JSON

Then I ingested the data through my program and converted it to a User object which I designed. This data was entered into my SQL database with Dapper.

Every user has these properties:
- UserId
- FirstName
- LastName
- StreetNumber
- StreetName
- City
- State
- Country
- PostCode
- Email
- DateOfBirth
- Age
- PhoneNumber
- SSN
- PictureThumbnail


Then I built out an API that allows me to GET, POST, PUT, and DELETE.The get function allows me to GET all or GET a user by ID. 
The POST function adds a user. The PUT function updated a user by first getting its ID.Lastly, the delete function takes in an ID and removes it.

I am able to test my API with Swagger in browser.
