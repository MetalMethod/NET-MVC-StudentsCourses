CREATE DATABASE StudentsCoursesTESTS

USE StudentsCoursesTESTS;


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

ALTER TABLE Registration
ADD CONSTRAINT std
	FOREIGN KEY (Student_ID)
	REFERENCES Student (ID)
	ON DELETE CASCADE

ALTER TABLE Registration
ADD CONSTRAINT crs
	FOREIGN KEY (Course_ID)
	REFERENCES Course (ID)
	ON DELETE CASCADE


INSERT INTO Student(FirstName, LastName)
VALUES('StudentTest1', 'StudentTest1')

INSERT INTO Student(FirstName, LastName)
VALUES('StudentTest2', 'StudentTest2')

INSERT INTO Course(Name, Vacancies)
VALUES ('CourseTest1', 10)

INSERT INTO Course(Name, Vacancies)
VALUES ('CourseTest2', 15)
