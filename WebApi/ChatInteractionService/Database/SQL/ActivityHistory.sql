CREATE TABLE ActivityHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    ActivityDetailsId INTEGER NOT NULL,
    TaskCompletion TEXT NOT NULL,               -- Task completion status (e.g., Fully Completed, Incomplete)
    Efforts TEXT NOT NULL,                      -- Efforts put by student (e.g., High, Average)
    Enthusiasm TEXT NOT NULL,                   -- Enthusiasm level (e.g., Enthusiastic, Neutral)
    ParticipationLevel TEXT NOT NULL,           -- Participation level (e.g., Fully Engaged, Not Engaged)
    Mood TEXT NOT NULL,                         -- Mood of the student during activity
    Feedback TEXT,                              -- Teacher's feedback for the student
    Score INTEGER NOT NULL,                     -- Score for the activity
    Date DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id),
    FOREIGN KEY (ActivityDetailsId) REFERENCES ActivityDetails(Id)
);
INSERT INTO ActivityHistory 
    (Id, StudentId, ActivityDetailsId, TaskCompletion, Efforts, Enthusiasm, ParticipationLevel, Mood, Feedback, Score, Date)
VALUES
    (1, 1, 1, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Excellent creativity', 90, '2024-08-02'),
    (2, 2, 2, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Excited', 'Needs to focus on details', 75, '2024-08-04'),
    (3, 3, 3, 'Incomplete', 'Minimal', 'Disinterested', 'Not Engaged', 'Anxious', 'Struggled with activity', 50, '2024-08-06'),
    (4, 4, 4, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Solved puzzle easily', 85, '2024-08-08'),
    (5, 5, 5, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Calm', 'Enjoyed singing', 70, '2024-08-10'),
    (6, 6, 1, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Excited', 'Very creative artwork', 92, '2024-08-12'),
    (7, 7, 2, 'Partially Completed', 'Minimal', 'Disinterested', 'Somewhat Engaged', 'Tired', 'Needs more focus', 65, '2024-08-14'),
    (8, 8, 3, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Energetic', 'Great team player', 88, '2024-08-16'),
    (9, 9, 4, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Calm', 'Good effort but slow', 72, '2024-08-18'),
    (10, 10, 5, 'Incomplete', 'Reluctant', 'Disinterested', 'Not Engaged', 'Bored', 'Did not enjoy activity', 40, '2024-08-20'),
    (11, 1, 2, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Great participation', 92, '2024-08-10'),
    (12, 1, 3, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Calm', 'Could improve focus', 75, '2024-08-12'),
    (13, 2, 4, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Excited', 'Solved quickly', 95, '2024-08-15'),
    (14, 2, 5, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Happy', 'Showed some effort', 80, '2024-08-18'),
    (15, 3, 1, 'Incomplete', 'Minimal', 'Disinterested', 'Not Engaged', 'Tired', 'Needed more enthusiasm', 60, '2024-08-20'),
    (16, 3, 2, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Excited', 'Good improvement', 85, '2024-08-23'),
    (17, 4, 3, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Calm', 'Good progress', 78, '2024-08-26'),
    (18, 4, 4, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Solved puzzle efficiently', 88, '2024-08-29'),
    (19, 5, 5, 'Incomplete', 'Minimal', 'Disinterested', 'Not Engaged', 'Bored', 'Lacked enthusiasm', 55, '2024-08-30'),
    (20, 5, 1, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Excited', 'Great creativity', 90, '2024-08-31'),
    (21, 6, 2, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Calm', 'Showed good effort', 80, '2024-08-25'),
    (22, 6, 3, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Great teamwork', 88, '2024-08-27'),
    (23, 7, 4, 'Partially Completed', 'Average', 'Neutral', 'Somewhat Engaged', 'Tired', 'Could improve engagement', 72, '2024-08-29'),
    (24, 7, 5, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Happy', 'Enjoyed singing activity', 85, '2024-08-31'),
    (25, 8, 1, 'Fully Completed', 'High', 'Enthusiastic', 'Fully Engaged', 'Excited', 'Very creative artwork', 92, '2024-08-30');
