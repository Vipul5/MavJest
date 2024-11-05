CREATE TABLE AcademicHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    Maths INTEGER  NULL,                 -- Integer score for Maths
    English INTEGER  NULL,               -- Integer score for English
    Hindi INTEGER  NULL,                 -- Integer score for Hindi
    MathsAssignment BOOLEAN  NULL,       -- Whether Maths assignment is done or not
    EnglishAssignment BOOLEAN  NULL,     -- Whether English assignment is done or not
    HindiAssignment BOOLEAN  NULL,       -- Whether Hindi assignment is done or not
	Feedback Text  NULL,       -- Whether Hindi assignment is done or not
    Date DATE NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Student(Id)
);
INSERT INTO AcademicHistory (StudentId, Maths, English, Hindi, MathsAssignment, EnglishAssignment, HindiAssignment, Feedback, Date) VALUES
(1, 85, 90, 88, 1, 1, 0, 'Maths: Good understanding of basics. Needs practice in addition. English: Excellent comprehension skills. Needs to improve pronunciation. Hindi: Doing well, but needs help in sentence formation.', '2024-08-01'),
(1, 78, 92, 81, 0, 1, 1, 'Maths: Struggles with number patterns. English: Excellent with story recall. Pronunciation improved. Hindi: Learning vocabulary quickly, but needs practice in reading.', '2024-08-05'),
(1, 82, 89, 85, 1, 0, 1, 'Maths: Confident with shapes. English: Good grasp on new words. Should focus on pronunciation. Hindi: Showing interest, needs guidance in forming sentences.', '2024-08-10'),

(2, 92, 85, 80, 1, 1, 1, 'Maths: Excellent in problem-solving skills. English: Loves reading stories. Needs better word recognition. Hindi: Can write simple words. Struggles in sentence formation.', '2024-08-03'),
(2, 88, 86, 79, 1, 0, 0, 'Maths: Understands counting well. English: Good reader. Needs vocabulary practice. Hindi: Slow improvement, but more confident now.', '2024-08-12'),
(2, 90, 89, 83, 0, 1, 1, 'Maths: Improved counting skills. English: Can recognize most letters. Needs more practice. Hindi: Improved understanding of basics, learning words.', '2024-08-18'),

(3, 79, 78, 82, 1, 0, 0, 'Maths: Needs more practice with addition. English: Engaged in class discussions. Struggles with new words. Hindi: Shows interest but needs regular practice.', '2024-08-07'),
(3, 81, 84, 78, 0, 1, 1, 'Maths: Recognizes numbers well. English: Beginning to read on own. Pronunciation improving. Hindi: Familiar with basic words, but needs help with grammar.', '2024-08-13'),
(3, 80, 86, 84, 1, 1, 1, 'Maths: Basic counting understood. English: Pronunciation and reading improving steadily. Hindi: Recognizes words, but needs assistance with sentences.', '2024-08-21'),

(4, 87, 90, 75, 1, 0, 1, 'Maths: Shows interest in learning shapes. English: Enjoys reading. Needs pronunciation improvement. Hindi: Getting better with vocabulary but needs regular practice.', '2024-08-02'),
(4, 82, 85, 78, 0, 1, 1, 'Maths: Strong in patterns. English: Improving in reading fluency. Hindi: Trying to read simple words independently.', '2024-08-09'),
(4, 88, 88, 80, 1, 1, 1, 'Maths: Enjoys problem-solving. English: Engages with new words confidently. Hindi: Vocabulary expanding, showing enthusiasm.', '2024-08-20'),

(5, 90, 82, 79, 1, 1, 0, 'Maths: Excellent counting and number skills. English: Struggles with pronunciation. Hindi: Starting to write words.', '2024-08-04'),
(5, 85, 83, 82, 1, 0, 1, 'Maths: Improving in addition. English: Loves storytime, vocabulary growing. Hindi: Confident with words, but needs grammar help.', '2024-08-14'),
(5, 87, 84, 81, 0, 1, 0, 'Maths: Needs more practice in patterns. English: Reading fluency improving. Hindi: Vocabulary expanding steadily.', '2024-08-25'),

(6, 82, 87, 83, 1, 0, 1, 'Maths: Developing good counting skills. English: Vocabulary growing with daily practice. Hindi: Beginning to read with confidence.', '2024-08-06'),
(6, 78, 85, 79, 0, 1, 0, 'Maths: Struggles with simple addition. English: Enjoys reading, needs fluency practice. Hindi: Recognizes words well.', '2024-08-15'),
(6, 80, 90, 85, 1, 1, 1, 'Maths: Improved confidence in counting. English: Can read simple sentences. Hindi: Understanding sentence structure.', '2024-08-28'),

(7, 76, 80, 85, 0, 1, 1, 'Maths: Needs more practice with shapes. English: Shows improvement in reading. Hindi: Enjoys class, building vocabulary.', '2024-08-08'),
(7, 78, 84, 87, 1, 0, 1, 'Maths: Starting to recognize patterns. English: Good understanding of basics. Hindi: Participates actively in reading.', '2024-08-17'),
(7, 81, 88, 83, 1, 1, 0, 'Maths: Confident with numbers. English: Enjoys new words. Hindi: Vocabulary growing, pronunciation improving.', '2024-08-30'),

(8, 88, 82, 86, 1, 0, 1, 'Maths: Excellent grasp on basic addition. English: Reads fluently. Hindi: Engages with stories well.', '2024-08-11'),
(8, 85, 83, 84, 0, 1, 0, 'Maths: Strong in counting and shapes. English: Building vocabulary. Hindi: Loves story time.', '2024-08-16'),
(8, 89, 89, 80, 1, 1, 1, 'Maths: Confident with basic concepts. English: Excellent pronunciation. Hindi: Vocabulary improvement noticeable.', '2024-08-29'),

(9, 90, 85, 78, 1, 0, 0, 'Maths: Good with numbers. English: Enjoys reading. Hindi: Needs improvement in grammar.', '2024-08-18'),
(9, 82, 84, 79, 0, 1, 1, 'Maths: Counts confidently. English: Comprehension skills improving. Hindi: Beginning to write sentences.', '2024-08-23'),
(9, 84, 88, 83, 1, 1, 1, 'Maths: Problem-solving skills developing. English: Good reader. Hindi: Building confidence in vocabulary.', '2024-08-31'),

(10, 78, 80, 81, 1, 0, 1, 'Maths: Starting to understand shapes. English: Engaged in stories. Hindi: Slow improvement in vocabulary.', '2024-08-19'),
(10, 80, 84, 85, 0, 1, 0, 'Maths: Learning addition. English: Pronunciation needs improvement. Hindi: Reads simple words.', '2024-08-24'),
(10, 83, 86, 82, 1, 1, 1, 'Maths: Counting skills well-developed. English: Vocabulary expanding. Hindi: Loves reading.', '2024-08-27');
