namespace Reflection.Tests;

public class Employee : IEmployee
{
    public Employee(int id, string name, int age, string role, int salaryPerAnnum, int salaryPerYear)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.Role = role;
        this.SalaryPerAnnum = salaryPerAnnum;
        this.SalaryPerYear = salaryPerYear;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Role { get; set; }

    public int SalaryPerAnnum { get; set; }

    public int SalaryPerYear { get; set; }

    public string GetOrganizationName()
    {
        string orgName = "EPAM";
        Console.WriteLine(orgName);
        return orgName;
    }

    public string GetDetails()
    {
        Console.WriteLine("Id: " + this.Id);
        Console.WriteLine("Name: " + this.Name);
        Console.WriteLine("Age: " + this.Age);
        Console.WriteLine("Role: " + this.Role);
        Console.WriteLine("Salary per Annum: " + this.SalaryPerAnnum);
        return this.Id + this.Name + this.Age + this.SalaryPerAnnum;
    }

    public int GetSalaryPerMonth()
    {
        Console.WriteLine("Salary per Month: " + (this.SalaryPerAnnum / 12));
        return this.SalaryPerAnnum / 12;
    }
}