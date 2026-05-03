USE HospitalSystem;
GO

-- 1. CLEANUP: Kill all existing constraints and tables

DECLARE @sql NVARCHAR(MAX) = N'';
SELECT @sql += 'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id))
    + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) 
    + ' DROP CONSTRAINT ' + QUOTENAME(name) + ';'
FROM sys.foreign_keys;

EXEC sp_executesql @sql;

DROP TABLE IF EXISTS NurseHisServices;
DROP TABLE IF EXISTS NurseServices;
DROP TABLE IF EXISTS DoctorHisServices;
DROP TABLE IF EXISTS DoctorServices;
DROP TABLE IF EXISTS Services;
DROP TABLE IF EXISTS Insurance;
DROP TABLE IF EXISTS PersonPhone;
DROP TABLE IF EXISTS Patient;
DROP TABLE IF EXISTS Nurse;
DROP TABLE IF EXISTS Doctor;
DROP TABLE IF EXISTS Department;
DROP TABLE IF EXISTS Person;
GO


-- 2. CREATE TABLES (With Automatic IDs)

CREATE TABLE Person (
    PersonID INT PRIMARY KEY IDENTITY(1,1), 
    Fname VARCHAR(50),
    Lname VARCHAR(50),
    Email VARCHAR(100),
    BirthDate DATE
);

CREATE TABLE Patient (
    PatientID INT PRIMARY KEY,
    FOREIGN KEY (PatientID) REFERENCES Person(PersonID) ON DELETE CASCADE
);

CREATE TABLE PersonPhone (
    PersonID INT,
    PhoneNumber VARCHAR(20),
    PRIMARY KEY (PersonID, PhoneNumber),
    FOREIGN KEY (PersonID) REFERENCES Person(PersonID) ON DELETE CASCADE
);

CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    [Name] VARCHAR(100),
    [Location] VARCHAR(100),
    SupervisorID INT
);

CREATE TABLE Doctor (
    DoctorID INT PRIMARY KEY,
    Shift VARCHAR(50),
    Salary DECIMAL(10,2),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
    FOREIGN KEY (DoctorID) REFERENCES Person(PersonID) ON DELETE CASCADE
);

ALTER TABLE Department 
ADD CONSTRAINT FK_Dept_Supervisor FOREIGN KEY (SupervisorID) REFERENCES Doctor(DoctorID);

CREATE TABLE Nurse (
    NurseID INT PRIMARY KEY,
    Shift VARCHAR(50),
    Salary DECIMAL(10,2),
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
    FOREIGN KEY (NurseID) REFERENCES Person(PersonID) ON DELETE CASCADE
);

CREATE TABLE Insurance (
    InsuranceID INT PRIMARY KEY IDENTITY(1,1),
    PatientID INT,
    CompanyName VARCHAR(100),
    CompanyType VARCHAR(50),
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID) ON DELETE CASCADE
);

CREATE TABLE Services (
    ServiceID INT PRIMARY KEY IDENTITY(1,1),
    ServiceDate DATE,
    Notes VARCHAR(255),
    PatientID INT,
    FOREIGN KEY (PatientID) REFERENCES Patient(PatientID) ON DELETE CASCADE
);

CREATE TABLE DoctorServices (
    DS_ID INT PRIMARY KEY IDENTITY(1,1),
    ServiceID INT,
    ServiceType nvarchar(100),
    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE DoctorHisServices (
    DS_ID INT,
    DoctorID INT,
    PRIMARY KEY (DS_ID, DoctorID),
    FOREIGN KEY (DS_ID) REFERENCES DoctorServices(DS_ID) ON DELETE CASCADE,
    FOREIGN KEY (DoctorID) REFERENCES Doctor(DoctorID) ON DELETE CASCADE
);

CREATE TABLE NurseServices (
    NS_ID INT PRIMARY KEY IDENTITY(1,1),
    ServiceID INT,
    ServiceType nvarchar(100),
    FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE NurseHisServices (
    NS_ID INT,
    NurseID INT,
    PRIMARY KEY (NS_ID, NurseID),
    FOREIGN KEY (NS_ID) REFERENCES NurseServices(NS_ID) ON DELETE CASCADE,
    FOREIGN KEY (NurseID) REFERENCES Nurse(NurseID) ON DELETE CASCADE
);
GO


-- 3. INSERT SAMPLE DATA

SET IDENTITY_INSERT Person ON;
INSERT INTO Person (PersonID, Fname, Lname, Email, BirthDate) VALUES
(1, 'Ahmed', 'Ali', 'ahmed@gmail.com', '1990-05-10'),
(2, 'Sara', 'Hassan', 'sara@gmail.com', '1995-03-15'),
(3, 'Omar', 'Khaled', 'omar@gmail.com', '1988-07-20'),
(4, 'Mona', 'Adel', 'mona@gmail.com', '1992-01-25'),
(5, 'Youssef', 'Samy', 'youssef@gmail.com', '1985-11-30'),
(6, 'Nour', 'Magdy', 'nour@gmail.com', '1998-06-18'),
(7, 'Hany', 'Fouad', 'hany@gmail.com', '1979-09-12'),
(8, 'Laila', 'Nabil', 'laila@gmail.com', '1983-04-08'),
(9, 'Tarek', 'Zaki', 'tarek@gmail.com', '1991-12-22');
SET IDENTITY_INSERT Person OFF;

INSERT INTO Patient VALUES(1),(2),(3);

INSERT INTO PersonPhone VALUES (1, '01000000001'),(2, '01000000002'),(3, '01000000003'),(4, '01000000004'),(5, '01000000005');

INSERT INTO Department ([Name], [Location], SupervisorID) VALUES
('Cardiology', 'Floor 1', NULL),
('Neurology', 'Floor 2', NULL),
('Emergency', 'Ground Floor', NULL);

INSERT INTO Doctor VALUES (4, 'Morning', 15000, 1),(5, 'Night', 18000, 2),(6, 'Morning', 20000, 3);

UPDATE Department SET SupervisorID = 4 WHERE DepartmentID = 1;
UPDATE Department SET SupervisorID = 5 WHERE DepartmentID = 2;
UPDATE Department SET SupervisorID = 6 WHERE DepartmentID = 3;

INSERT INTO Nurse VALUES (7, 'Morning', 8000, 1),(8, 'Night', 8500, 2),(9, 'Morning', 9000, 3);

INSERT INTO Insurance (PatientID, CompanyName, CompanyType) VALUES (1, 'AXA', 'Private'),(2, 'Misr Insurance', 'Government'),(3, 'Allianz', 'Private');

INSERT INTO Services (ServiceDate, Notes, PatientID) VALUES ('2026-04-01', 'Checkup', 1),('2026-04-02', 'MRI Scan', 2),('2026-04-03', 'Emergency Case', 3);

INSERT INTO DoctorServices (ServiceID, ServiceType) VALUES (1, 'Consultation'),(2, 'Radiology'),(3, 'Surgery');
INSERT INTO DoctorHisServices (DS_ID, DoctorID) VALUES (1, 4),(2, 5),(3, 6);

INSERT INTO NurseServices (ServiceID, ServiceType) VALUES (1, 'Assistance'),(2, 'Monitoring'),(3, 'Emergency Support');
INSERT INTO NurseHisServices (NS_ID, NurseID) VALUES (1, 7),(2, 8),(3, 9);