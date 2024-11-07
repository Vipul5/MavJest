CREATE TABLE Student (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    SchoolGeneratedId TEXT NOT NULL,
    FatherName TEXT NOT NULL,
    MotherName TEXT NOT NULL,
    Class TEXT NOT NULL,      -- Class can be 'Prep', 'Nursery', etc.
    DOB DATE NOT NULL,
    DateOfAdmission DATE NOT NULL,
    PhoneNumber TEXT NOT NULL,
    Image TEXT
);

INSERT INTO Student (Id, Name, SchoolGeneratedId, FatherName, MotherName, Class, DOB, DateOfAdmission, PhoneNumber, Image) 
VALUES 
(1, 'Aryan Mehta', 'SGID001', 'Rahul Mehta', 'Priya Mehta', 'Prep', '2018-03-15', '2024-07-01', '9876543210', 'istockphoto-941782244-612x612.jpg'),
(2, 'Ria Shah', 'SGID002', 'Arjun Shah', 'Meera Shah', 'Prep', '2018-04-10', '2024-07-05', '9876543211', 'istockphoto-1292020946-612x612.jpg'),
(3, 'Zain Patel', 'SGID003', 'Raj Patel', 'Amrita Patel', 'Prep', '2018-02-12', '2024-07-03', '9876543212', 'istockphoto-1296115846-612x612.jpg'),
(4, 'Anaya Singh', 'SGID004', 'Saurabh Singh', 'Nisha Singh', 'Prep', '2018-01-28', '2024-07-06', '9876543213', '360_F_639144079_EsoeMdS23nHz3LR7ejHfPqrvJpkF7tCy.jpg'),
(5, 'Aarav Gupta', 'SGID005', 'Vikram Gupta', 'Simran Gupta', 'Prep', '2018-05-02', '2024-07-04', '9876543214', '360_F_507086179_Sr5N09sbgQ0qXljoxDwlre5s85YhffMB.jpg'),
(6, 'Kunal Sharma', 'SGID006', 'Sanjay Sharma', 'Kavita Sharma', 'Nursery', '2019-06-15', '2024-07-10', '9876543215', 'istockphoto-1160531500-612x612.jpg'),
(7, 'Mehul Reddy', 'SGID007', 'Kiran Reddy', 'Shruti Reddy', 'Nursery', '2019-08-22', '2024-07-12', '9876543216', '1fc1f868e74f9142be4bf984403e4c888e14e8b6f65f487bc30139d3cde113feece8b458a7ddf5c05cdc7989f43beacdb4b9b44121157482b80512_1280.jpg'),
(8, 'Zara Khan', 'SGID008', 'Amir Khan', 'Alia Khan', 'Nursery', '2019-07-18', '2024-07-09', '9876543217', '1fc1f868e74f9142be4bf984403e4c888e14e8b6f65f487bc30139d3cde113feece8b458a7ddf5c05cdc7989f43beacdb4b9b44121157482b80512_1280.jpg'),
(9, 'Isha Bhatt', 'SGID009', 'Sameer Bhatt', 'Neha Bhatt', 'Nursery', '2019-09-05', '2024-07-11', '9876543218', '1fc1f868e74f9142be4bf984403e4c888e14e8b6f65f487bc30139d3cde113feece8b458a7ddf5c05cdc7989f43beacdb4b9b44121157482b80512_1280.jpg'),
(10, 'Vivan Desai', 'SGID010', 'Rakesh Desai', 'Aarti Desai', 'Nursery', '2019-04-27', '2024-07-13', '9876543219', '1fc1f868e74f9142be4bf984403e4c888e14e8b6f65f487bc30139d3cde113feece8b458a7ddf5c05cdc7989f43beacdb4b9b44121157482b80512_1280.jpg');