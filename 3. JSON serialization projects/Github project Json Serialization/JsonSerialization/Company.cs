using System.Text.Json.Serialization;

namespace JsonSerialization;

public class Company
{
    [JsonPropertyName("company_name")]
    [JsonPropertyOrder(1)]
    public string? Name { get; set; }

    [JsonPropertyName("company_established_year")]
    [JsonPropertyOrder(2)]
    public int EstablishedYear { get; set; }

    [JsonPropertyName("company_employee_count")]
    [JsonPropertyOrder(3)]
    public int EmployeeCount { get; set; }

    [JsonPropertyName("company_domains")]
    [JsonPropertyOrder(4)]
    public Dictionary<string, int>? Domains { get; set; }

    [JsonPropertyName("company_company_type")]
    [JsonPropertyOrder(5)]
    public CompanyType CompanyType { get; set; }

    [JsonIgnore]// This property will be ignored in JSON serialization
    public string? IgnoreProperty { get; set; }
}
