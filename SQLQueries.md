CREATE DATABASE UserDatabase
GO

USE UserDatabase
GO

CREATE SCHEMA DatabaseSchema
GO

CREATE TABLE DatabaseSchema.UserData
(
    UserId INT IDENTITY(1,1)
    , FirstName VARCHAR(30)
    , LastName VARCHAR(30)
    , StreetNumber INT
    , StreetName VARCHAR(255)
    , City VARCHAR(50)
    , State VARCHAR(30)
    , Country VARCHAR(30)
    , PostCode VARCHAR(10)
    , Email VARCHAR(255)
    , DateOfBirth DATETIME
    , Age INT
    , Phone VARCHAR(32)
    , SSN VARCHAR(11)
    , PictureThumbnail VARCHAR(255)

)
GO

SELECT * FROM DatabaseSchema.UserData WHERE EXISTS (SELECT * FROM DatabaseSchema.UserData WHERE UserId = 1)
GO

SELECT COUNT(*) FROM DatabaseSchema.UserData
GO

SELECT * FROM DatabaseSchema.UserData
