USE [Address_Book]
GO

CREATE Procedure [dbo].[SPAddressBook]
(
@FirstName varchar,
@LastName varchar,
@_address varchar,
@City varchar,
@_State varchar,
@Zip int ,
@PhoneNumber varchar,
@email varchar,
@RelationType varchar
)
As
	
