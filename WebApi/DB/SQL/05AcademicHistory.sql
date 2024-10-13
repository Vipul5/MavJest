CREATE TABLE AcademicHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    Maths INTEGER  NULL,                 -- Integer score for Maths
    English INTEGER  NULL,               -- Integer score for English
    Hindi INTEGER  NULL,                 -- Integer score for Hindi
    MathsAssignment BOOLEAN  NULL,       -- Whether Maths assignment is done or not
    EnglishAssignment BOOLEAN  NULL,     -- Whether English assignment is done or not
    HindiAssignment BOOLEAN  NULL,       -- Whether Hindi assignment is done or not
    Date DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id)
);

INSERT INTO AcademicHistory (Id, StudentId, Maths, English, Hindi, MathsAssignment, EnglishAssignment, HindiAssignment, Date) VALUES
(1, 1, 75, 82, 68, TRUE, FALSE, TRUE, '2024-08-01'),
(2, 1, 78, 80, 70, TRUE, TRUE, FALSE, '2024-08-05'),
(3, 2, 85, 90, 88, TRUE, TRUE, TRUE, '2024-08-03'),
(4, 3, 60, 55, 65, FALSE, FALSE, FALSE, '2024-08-08'),
(5, 4, 72, 78, 80, TRUE, FALSE, TRUE, '2024-08-10'),
(6, 5, 90, 85, 92, TRUE, TRUE, TRUE, '2024-08-14'),
(7, 6, 66, 75, 60, FALSE, TRUE, TRUE, '2024-08-11'),
(8, 7, 78, 70, 72, TRUE, TRUE, FALSE, '2024-08-13'),
(9, 8, 82, 80, 78, TRUE, FALSE, TRUE, '2024-08-16'),
(10, 9, 68, 65, 60, TRUE, TRUE, FALSE, '2024-08-18'),
(11, 10, 74, 80, 72, FALSE, TRUE, TRUE, '2024-08-20'),
(12, 1, 80, 84, 72, TRUE, TRUE, TRUE, '2024-08-08'),
(13, 1, 82, 86, 74, TRUE, TRUE, FALSE, '2024-08-12'),
(14, 2, 88, 85, 87, TRUE, TRUE, TRUE, '2024-08-06'),
(15, 2, 90, 87, 89, TRUE, TRUE, TRUE, '2024-08-10'),
(16, 3, 65, 60, 67, TRUE, FALSE, TRUE, '2024-08-12'),
(17, 3, 70, 62, 65, TRUE, FALSE, FALSE, '2024-08-16'),
(18, 4, 75, 80, 82, TRUE, TRUE, TRUE, '2024-08-15'),
(19, 4, 78, 82, 85, FALSE, TRUE, TRUE, '2024-08-18'),
(20, 5, 85, 88, 91, TRUE, TRUE, TRUE, '2024-08-20'),
(21, 5, 88, 90, 93, TRUE, TRUE, TRUE, '2024-08-22'),
(22, 6, 72, 77, 70, TRUE, TRUE, FALSE, '2024-08-14'),
(23, 6, 75, 80, 73, TRUE, TRUE, TRUE, '2024-08-17'),
(24, 7, 82, 85, 84, TRUE, TRUE, TRUE, '2024-08-19'),
(25, 7, 80, 83, 82, TRUE, TRUE, TRUE, '2024-08-22'),
(26, 8, 88, 86, 85, TRUE, TRUE, TRUE, '2024-08-25'),
(27, 8, 85, 88, 87, TRUE, TRUE, TRUE, '2024-08-28'),
(28, 9, 72, 70, 75, TRUE, TRUE, FALSE, '2024-08-21'),
(29, 9, 75, 72, 78, TRUE, TRUE, TRUE, '2024-08-24'),
(30, 10, 80, 82, 85, TRUE, TRUE, TRUE, '2024-08-26'),
(31, 10, 82, 85, 87, TRUE, TRUE, TRUE, '2024-08-29');
