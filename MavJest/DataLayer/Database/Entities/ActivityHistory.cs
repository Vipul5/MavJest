namespace MavJest.Database.Entities;

/// <summary>
/// Activity History Entity
/// </summary>
public class ActivityHistory
{
    /// <summary>
    /// Activity History Identifier
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
    /// Activity Details Identifier.
    /// </summary>
    /// <remarks>
    /// Foreign key reference to Activity Details
    /// </remarks>
    public int ActivityDetailsId { get; set; }

    /// <summary>
    /// Task completion state
    /// </summary>
    /// <remarks>
    /// Values like Fully Complete, Incomplete, etc. 
    /// Subjective entry from teacher.
    /// </remarks>
    public string TaskCompletion { get; set; }  

    /// <summary>
    /// Efforts by student
    /// </summary>
    /// <remarks>
    /// Values like High, Average, etc.
    /// Subjective entry from teacher.
    /// </remarks>
    public string Efforts { get; set; }

    /// <summary>
    /// Enthusiasm of student
    /// </summary>
    /// <remarks>
    /// Values like Enthusiastic, Neutral, etc.
    /// Subjective entry from teacher.
    /// </remarks>
    public string Enthusiasm { get; set; }

    /// <summary>
    /// Participation level of student
    /// </summary>
    /// <remarks>
    /// Values like Fully Engaged, Somewhat Engaged, etc.
    /// Subjective entry from teacher.
    /// </remarks>
    public string ParticipationLevel { get; set; }

    /// <summary>
    /// Mood of student
    /// </summary>
    /// <remarks>
    /// Values like Fully Happy, Anxious, etc.
    /// Subjective entry from teacher.
    /// </remarks>
    public string Mood { get; set; }


    /// <summary>
    /// Mood of student
    /// </summary>
    /// <remarks>
    /// Values like Fully Happy, Anxious, etc.
    /// Subjective entry from teacher.
    /// </remarks>
    public string Feedback { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }

    // Navigation properties for relationships
    public Student Student { get; set; }
    public ActivityDetails ActivityDetails { get; set; }
}