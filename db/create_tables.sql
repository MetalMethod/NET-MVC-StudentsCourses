DROP DATABASE StudentsCoursesRegistrations;

CREATE DATABASE StudentsCoursesRegistrations;

CREATE TABLE Students (
    ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(255) NOT NULL,
    LastName varchar(255) NOT NULL,
    IsRegistered bit NOT NULL DEFAULT 0
);

CREATE TABLE Courses (
    ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) NOT NULL,
);

CREATE TABLE Registrations(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Student_ID int FOREIGN KEY REFERENCES Students(ID) NOT NULL, 
	Course_ID int FOREIGN KEY REFERENCES Courses(ID) NOT NULL,
	RegistrationKey varchar(255) NOT NULL
);

