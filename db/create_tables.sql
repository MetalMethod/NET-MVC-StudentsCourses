DROP DATABASE StudentsCoursesDBfirst;

CREATE DATABASE StudentsCoursesDBfirst;

USE StudentsCoursesDBfirst;

CREATE TABLE Student (
    ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(30) NOT NULL,
    LastName varchar(30) NOT NULL
);

CREATE TABLE Course (
    ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Vacancies int NOT NULL
);

CREATE TABLE Registration(
	ID int IDENTITY(1,1) PRIMARY KEY,
	Student_ID int FOREIGN KEY REFERENCES Student(ID) NOT NULL, 
	Course_ID int FOREIGN KEY REFERENCES Course(ID) NOT NULL,
	RegistrationKey char(8) NOT NULL
);

