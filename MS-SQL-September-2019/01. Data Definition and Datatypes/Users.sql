USE Minions

GO

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Pesho', '1234', NULL, NULL, 0),
('Gosho', '1234', NULL, NULL, 0),
('Ivan', '1234', NULL, NULL, 0),
('TestUser', '1234', NULL, NULL, 1),
('Maria', '1234', NULL, NULL, 1)

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0740ED0B8B

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY(Id, Username)

TRUNCATE TABLE Users

ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLength
CHECK(DATALENGTH([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
ADD CONSTRAINT UC_Username 
UNIQUE (Username)