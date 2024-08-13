USE gs313_INTRO_USERS

CREATE TABLE Users (
	UserName varchar(20) NOT NULL PRIMARY KEY,
	FirstName varchar(20) NOT NULL,
	MiddleName varchar(20),
	LastName varchar(20) NOT NULL,
	Password varchar(20) NOT NULL
)

CREATE TABLE SocialMedia (
		SocMediaID varchar(3) NOT NULL PRIMARY KEY,
		SocialMediaName varchar(30) NOT NULL
	)
	
CREATE TABLE UserSession (
	SessionID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	SocMediaID varchar(3),
	UserName varchar(20),
	SessionTime int, --assumed as minutes for simplicity
	FOREIGN KEY(SocMediaID) REFERENCES SocialMedia,
	FOREIGN KEY(UserName) REFERENCES Users
	)


DROP TABLE UserSession
DROP TABLE SocialMedia
DROP TABLE Users


--This inserts data into Users table
INSERT INTO Users VALUES ('jkc1', 'John', 'Middle', 'Carter', 'pass1')
INSERT INTO Users VALUES ('amo1', 'Amos', 'Carter', 'Orange', 'pass2')
INSERT INTO Users VALUES ('wkc1', 'Wong', 'Caleb', 'Cartel', 'pass3')
INSERT INTO Users VALUES ('ddj1', 'Daisy', 'Day', ' Johnson ', 'pass4')
INSERT INTO Users VALUES ('dps1', 'Dayne', 'Pint', ' Shipper ', 'pass5')

--This table links the two tables together
INSERT INTO SocialMedia Values ('FB', 'Facebook')
INSERT INTO SocialMedia Values ('TWT','Twitter')
INSERT INTO SocialMedia Values ('IG', 'Instagram')
INSERT INTO SocialMedia Values ('YT', 'YouTube')

--This stores data into UserSession linking Users and SocialMediaa
INSERT INTO UserSession Values ('FB', 'jkc1', 256)
INSERT INTO UserSession Values ('TWT', 'amo1', 20)
INSERT INTO UserSession Values ('IG', 'wkc1', 60)
INSERT INTO UserSession Values ('YT', 'ddj1', 180)
INSERT INTO UserSession Values ('FB', 'dps1', 25)


--select statement
Select * FROM Users
Select * FROM SocialMedia
Select * FROM UserSession

SELECT UserName FROM Users
union
SELECT SocMediaID FROM SocialMedia WHERE SocialMediaName LIKE 'Facebook'

SELECT * 
FROM UserSession 
WHERE UserName LIKE 'jkc1'
AND SocMediaID LIKE 'FB'

SELECT UserName FROM Users