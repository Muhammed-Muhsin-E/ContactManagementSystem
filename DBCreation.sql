CREATE DATABASE ContactManagementSystem

USE ContactManagementSystem
CREATE TABLE Contact (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    EmailId VARCHAR(50),
    PhoneNumber BIGINT,
    Address VARCHAR(255)
)
INSERT INTO Contact (Name, EmailId, PhoneNumber, Address) VALUES ('John', 'john@gmail.com', '9876543210', 'Bangalore')
INSERT INTO Contact (Name, EmailId, PhoneNumber, Address) VALUES ('Son', 'son@gmail.com', '9885043210', 'Totenham')
INSERT INTO Contact (Name, EmailId, PhoneNumber, Address) VALUES ('Messi', 'messi@gmail.com', '7896543210', 'Miami')

SELECT * FROM Contact