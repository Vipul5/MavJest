CREATE TABLE ActivityDetails (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ActivityName TEXT NOT NULL,
    Description TEXT
);

INSERT INTO ActivityDetails (Id, ActivityName, Description)
VALUES 
(1, 'Drawing', 'Drawing shapes, animals, etc.'),
(2, 'Story Telling', 'Telling a story from a picture'),
(3, 'Outdoor Play', 'Group games in playground'),
(4, 'Puzzle Solving', 'Solving jigsaw puzzles'),
(5, 'Singing Rhymes', 'Singing popular rhymes together');