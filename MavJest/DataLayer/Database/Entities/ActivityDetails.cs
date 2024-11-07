namespace MavJest.Database.Entities;

/// <summary>
/// Activity Details Entity
/// </summary>
public class ActivityDetails
{
    /// <summary>
    /// Activity Details Identifier
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Activity Name
    /// </summary>
    public string ActivityName { get; set; }

    /// <summary>
    /// Activity Description
    /// </summary>
    public string Description { get; set; }
}