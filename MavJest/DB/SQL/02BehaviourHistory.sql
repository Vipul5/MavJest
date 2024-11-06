CREATE TABLE BehaviourHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    SeatingLocation TEXT NOT NULL,               -- Seating location in the classroom
    SeatedWithStudentId INTEGER,                 -- Student Id with whom the student is seated
    ClassroomBehaviour TEXT NOT NULL,            -- Description of classroom behavior
    EngagementLevel TEXT NOT NULL,               -- Engagement level (e.g., Highly Engaged, Motivated)
    Attitude TEXT NOT NULL,                      -- Attitude of the student (e.g., Curious, Positive)
    Mood TEXT NOT NULL,                          -- Mood of the student (e.g., Happy, Calm, Anxious)
    SocialBehaviour TEXT NOT NULL,               -- Social behavior (e.g., Cooperative, Disruptive)
    Date DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id),
    FOREIGN KEY (SeatedWithStudentId) REFERENCES Student(Id)
);

INSERT INTO BehaviourHistory 
(Id, StudentId, SeatingLocation, SeatedWithStudentId, ClassroomBehaviour, EngagementLevel, Attitude, Mood, SocialBehaviour, Date) 
VALUES
(1, 1, 'Front Left', 2, 'Good', 'Motivated', 'Positive and Open', 'Happy', 'Cooperative', '2024-08-01'),
(2, 2, 'Front Right', 1, 'Attentive', 'Highly Engaged', 'Curious and Eager', 'Calm', 'Friendly', '2024-08-02'),
(3, 3, 'Middle', 4, 'Disruptive', 'Neutral', 'Resistant', 'Anxious', 'Disruptive', '2024-08-03'),
(4, 4, 'Back Left', 5, 'Quiet', 'Neutral', 'Calm and Receptive', 'Happy', 'Shy', '2024-08-05'),
(5, 5, 'Back Right', 6, 'Active', 'Motivated', 'Curious and Eager', 'Excited', 'Engaged', '2024-08-06'),
(6, 6, 'Middle Left', 7, 'Attentive', 'Highly Engaged', 'Positive and Open', 'Happy', 'Cooperative', '2024-08-07'),
(7, 7, 'Middle Right', 8, 'Reserved', 'Uninterested', 'Reluctant', 'Sad', 'Reserved', '2024-08-08'),
(8, 8, 'Back Middle', 9, 'Playful', 'Neutral', 'Curious and Eager', 'Excited', 'Friendly', '2024-08-10'),
(9, 9, 'Front Left', 10, 'Disruptive', 'Disengaged', 'Resistant', 'Angry', 'Aggressive', '2024-08-12'),
(10, 10, 'Back Middle', 1, 'Quiet', 'Motivated', 'Calm and Receptive', 'Calm', 'Cooperative', '2024-08-13'),
(11, 1, 'Front Left', 3, 'Attentive', 'Motivated', 'Positive and Open', 'Calm', 'Cooperative', '2024-08-15'),
(12, 1, 'Middle', 5, 'Distracted', 'Neutral', 'Calm and Receptive', 'Anxious', 'Shy', '2024-08-18'),
(13, 2, 'Back Left', 4, 'Attentive', 'Highly Engaged', 'Curious and Eager', 'Excited', 'Engaged', '2024-08-20'),
(14, 2, 'Back Right', 6, 'Playful', 'Motivated', 'Positive and Open', 'Happy', 'Friendly', '2024-08-22'),
(15, 3, 'Middle Left', 7, 'Disruptive', 'Neutral', 'Resistant', 'Angry', 'Disruptive', '2024-08-23'),
(16, 3, 'Front Right', 8, 'Reserved', 'Neutral', 'Calm and Receptive', 'Calm', 'Reserved', '2024-08-25'),
(17, 4, 'Front Left', 1, 'Playful', 'Motivated', 'Curious and Eager', 'Happy', 'Cooperative', '2024-08-26'),
(18, 4, 'Middle Right', 9, 'Attentive', 'Highly Engaged', 'Positive and Open', 'Calm', 'Engaged', '2024-08-27'),
(19, 5, 'Front Right', 10, 'Disruptive', 'Neutral', 'Reluctant', 'Angry', 'Disruptive', '2024-08-28'),
(20, 5, 'Back Left', 2, 'Quiet', 'Motivated', 'Calm and Receptive', 'Calm', 'Shy', '2024-08-30'),
(21, 6, 'Middle Right', 8, 'Attentive', 'Highly Engaged', 'Curious and Eager', 'Happy', 'Cooperative', '2024-08-17'),
(22, 6, 'Back Middle', 9, 'Reserved', 'Neutral', 'Reluctant', 'Tired', 'Reserved', '2024-08-19'),
(23, 7, 'Middle Left', 1, 'Disruptive', 'Disengaged', 'Resistant', 'Sad', 'Disruptive', '2024-08-21'),
(24, 7, 'Front Left', 4, 'Quiet', 'Neutral', 'Calm and Receptive', 'Calm', 'Cooperative', '2024-08-23'),
(25, 8, 'Back Right', 3, 'Attentive', 'Motivated', 'Curious and Eager', 'Excited', 'Friendly', '2024-08-25'),
(26, 8, 'Middle Right', 7, 'Playful', 'Highly Engaged', 'Positive and Open', 'Happy', 'Engaged', '2024-08-28'),
(27, 9, 'Back Left', 10, 'Distracted', 'Neutral', 'Reluctant', 'Anxious', 'Shy', '2024-08-29'),
(28, 9, 'Front Right', 2, 'Attentive', 'Motivated', 'Positive and Open', 'Happy', 'Cooperative', '2024-08-30'),
(29, 10, 'Back Middle', 1, 'Quiet', 'Highly Engaged', 'Curious and Eager', 'Calm', 'Friendly', '2024-08-31');
