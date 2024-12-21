namespace TableOfRecords.Tests.UserProfiles;

/// <summary>
/// Base profile of an employee.
/// </summary>
public class ProfileBasic
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
    /// Gets or sets mobile phone number of the employee.
    /// </summary>
    public string? Phone { get; set; }
}