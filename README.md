# SQL Database and API

## Goal
My goal was to build out a SQL Database and API in C#. Using Dapper and Aspnet Core MVC.

## Process
I randomly generated User json data from randomuser.me.
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


I built out an API that allows me to GET, POST, PUT, and DELETE. The get function allows me to GET all or GET a user by ID. 
The POST function adds a user object to the database. The PUT function updates a user by based on its UserId. Lastly, the delete function takes in an ID and removes that user from the database.

Notes: 
- I am able to test my API with Swagger in browser.
- My SQL database was built in Azure Data Studio.
