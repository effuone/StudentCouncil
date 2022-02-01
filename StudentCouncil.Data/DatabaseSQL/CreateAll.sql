CREATE TABLE Documents
(
    FileId INT IDENTITY(1,1) NOT NULL,
    FileName VARCHAR(250) NOT NULL,
    Data VARBINARY(max) NOT NULL,
    Extension CHAR(4) NOT NULL,
    CONSTRAINT PK_Documents PRIMARY KEY (FileId)
)
GO
CREATE TABLE Countries
(
    CountryId INT IDENTITY(1,1) NOT NULL,
    CountryName VARCHAR(20) NOT NULL,
    CONSTRAINT PK_Countries PRIMARY KEY (CountryId),
    CONSTRAINT QK_Countries_CountryName UNIQUE (CountryName)
)
GO
CREATE TABLE Cities
(
    CityId INT IDENTITY(1,1) NOT NULL,
    CountryID INT NOT NULL,
    CityName VARCHAR(30) NOT NULL,
    CONSTRAINT PK_Cities PRIMARY KEY(CityId),
    CONSTRAINT FK_Cities_To_Countries FOREIGN KEY(CountryId) REFERENCES Countries(CountryId),
    CONSTRAINT QK_Cities_CityName UNIQUE (CityName)
)
GO
CREATE TABLE Locations
(
    LocationId INT IDENTITY(1,1) NOT NULL,
    CountryId INT NOT NULL,
    CityId INT NOT NULL,
    CONSTRAINT PK_Locations PRIMARY KEY (LocationId),
    CONSTRAINT FK_Locations_To_Countries FOREIGN KEY (CountryId) REFERENCES Countries(CountryId),
    CONSTRAINT FK_Locations_To_Cities FOREIGN KEY (CityId) REFERENCES Cities(CityId)
)
GO
CREATE TABLE Groups
(
    GroupId INT IDENTITY(1,1) NOT NULL,
    Grade INT NOT NULL,
    GroupChar char NOT NULL,
    CONSTRAINT PK_Groups PRIMARY KEY (GroupId)
)
CREATE TABLE CouncilUsers
(
    CouncilUserId INT IDENTITY(1,1) NOT NULL,
    UserId NVARCHAR(450) NOT NULL,
    FirstName VARCHAR(25) NOT NULL,
    LastName VARCHAR(25) NOT NULL,
    FileId INT NOT NULL,
    CONSTRAINT PK_CouncilUsers PRIMARY KEY(CouncilUserId),
    CONSTRAINT FK_CouncilUsers_To_Documents FOREIGN KEY (FileId) REFERENCES Documents(FileId)
)
GO
CREATE TABLE Schools
(
    SchoolId INT IDENTITY(1,1) NOT NULL,
    SchoolName VARCHAR(100) NOT NULL,
    OpeningDate DATE NOT NULL,
    LocationId INT NOT NULL,
    CONSTRAINT QK_Schools_SchoolName UNIQUE (SchoolName),
    CONSTRAINT PK_Schools PRIMARY KEY (SchoolId),
    CONSTRAINT FK_Schools_To_Locations FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
)
GO
CREATE TABLE Students
(
    StudentId INT IDENTITY(1,1) NOT NULL,
    CouncilUserId INT NOT NULL,
    SchoolId INT NOT NULL,
    GroupId INT NOT NULL,
    CONSTRAINT PK_Students PRIMARY KEY(StudentId),
    CONSTRAINT FK_Students_To_Schools FOREIGN KEY (SchoolId) REFERENCES Schools(SchoolId),
    CONSTRAINT FK_Students_To_Groups FOREIGN KEY(GroupId) REFERENCES Groups(GroupId)
)
GO
CREATE TABLE Members(
    MemberId INT IDENTITY(1,1) NOT NULL,
    StudentId INT NOT NULL,
    CONSTRAINT PK_Members PRIMARY KEY(MemberId),
    CONSTRAINT FK_Members_To_Students FOREIGN KEY(StudentId) REFERENCES Students(StudentId)
)
GO
CREATE TABLE Departments(
    DepartmentId INT IDENTITY(1,1) NOT NULL,
    DepartmentName VARCHAR(30) NOT NULL,
    Description VARCHAR(max) NOT NULL,
    CONSTRAINT PK_Departments PRIMARY KEY(DepartmentId),
    CONSTRAINT QK_Departments_DepartmentName UNIQUE(DepartmentName)
)
GO
CREATE TABLE DepartmentDocuments(
    DepartmentId INT NOT NULL,
    FileID INT NOT NULL,
    CONSTRAINT FK_DepartmentDocuments_To_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId),
    CONSTRAINT FK_DepartmentDocuments_To_Documents FOREIGN KEY(FileId) REFERENCES Documents(FileId),
)
GO
CREATE TABLE Curators(
    CuratorId INT IDENTITY(1,1) NOT NULL,
    DepartmentId INT NOT NULL,
    MemberId INT NOT NULL,
    BecameReason VARCHAR(250) NOT NULL,
    BecameDate DATE NOT NULL,
    CONSTRAINT PK_Curators PRIMARY KEY(CuratorId),
    CONSTRAINT FK_Curators_To_Members FOREIGN KEY(MemberId) REFERENCES Members(MemberId),
    CONSTRAINT FK_Curators_To_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
)
GO
CREATE TABLE DepartmentMembers(
    DepartmentId INT NOT NULL,
    MemberId INT NOT NULL,
    EntryDate DATE NOT NULL,
    CONSTRAINT FK_DepartmentMembers_To_Members FOREIGN KEY(MemberId) REFERENCES Members(MemberId),
    CONSTRAINT FK_DepartmentMembers_To_Departments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
)
GO
CREATE TABLE Plans(
    PlanId INT IDENTITY(1,1) NOT NULL,
    PlanShort VARCHAR(20) NOT NULL,
    PlanDescription VARCHAR(max) NOT NULL,
    Investments money,
    MemberId INT NOT NULL,
    CONSTRAINT PK_Plans PRIMARY KEY(PlanId),
    CONSTRAINT FK_Plans_To_Members FOREIGN KEY(MemberId) REFERENCES Members(MemberId)
)
GO
CREATE TABLE PlanDocuments(
    PlanId INT NOT NULL,
    FileId INT NOT NULL,
    LastChangedTime DATETIME NOT NULL,
    CONSTRAINT FK_PlanDocuments_To_Plans FOREIGN KEY(PlanId) REFERENCES Plans(PlanId),
    CONSTRAINT FK_PlanDocuments_To_Documents FOREIGN KEY(FileId) REFERENCES Documents(FileId)
)
GO
CREATE TABLE Reports(
    ReportId INT IDENTITY(1,1) NOT NULL,
    CuratorId INT NOT NULL,
    ReportName VARCHAR(20) NOT NULL,
    Description VARCHAR(max) NOT NULL,
    CONSTRAINT PK_Reports PRIMARY KEY(ReportId),
    CONSTRAINT FK_Reports_To_Curators FOREIGN KEY(CuratorId) REFERENCES Curators(CuratorId)
)
GO
CREATE TABLE ReportDocuments(
    ReportId INT NOT NULL,
    FileId INT NOT NULL,
    LastChangedTime DATETIME NOT NULL,
    CONSTRAINT FK_ReportDocuments_To_Reports FOREIGN KEY(ReportId) REFERENCES Reports(ReportId),
    CONSTRAINT FK_ReportDocuments_To_Documents FOREIGN KEY(FileId) REFERENCES Documents(FileId)
)