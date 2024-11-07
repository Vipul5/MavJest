namespace MavJest.Database.Entities;

/// <summary>
/// Academic History Entity
/// </summary>
public class AcademicHistory
{
    /// <summary>
    /// Academic History Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Student Identifier.
    /// </summary>
    /// <remarks>
    /// Foreign key reference to Student
    /// </remarks>
    public int StudentId { get; set; }

    /// <summary>
    /// Score in Maths
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public int? Maths { get; set; }

    /// <summary>
    /// Score in English
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public int? English { get; set; }

    /// <summary>
    /// Score in Hindi
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public int? Hindi { get; set; }

    /// <summary>
    /// Identify if Math assignment was done.
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public bool? MathsAssignment { get; set; }

    /// <summary>
    /// Identify if English assignment was done.
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public bool? EnglishAssignment { get; set; }

    /// <summary>
    /// Identify if Hindi assignment was done.
    /// </summary>
    /// <remarks>
    /// Nullable for recording class skipped.
    /// </remarks>
    public bool? HindiAssignment { get; set; }

    /// <summary>
    /// Date of record
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Feedback from teacher in each subject
    /// </summary>
    public string Feedback { get; set; }

    /// <summary>
    /// Foreign Key Navigation Property - Student
    /// </summary>
    public Student Student { get; set; }
}

