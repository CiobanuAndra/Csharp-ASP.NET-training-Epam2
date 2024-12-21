namespace TableOfRecords.Tests.UserProfiles;

/// <summary>
/// Extended profile of an employee.
/// </summary>
public class ProfileExtended
{
    /// <summary>
    /// Gets or sets full name of the employee.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets age of the employee.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Gets or sets gender of the employee.
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Gets or sets mobile phone number of the employee.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets email address of the employee.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets income of the employee.
    /// </summary>
    public decimal Income { get; set; }
}