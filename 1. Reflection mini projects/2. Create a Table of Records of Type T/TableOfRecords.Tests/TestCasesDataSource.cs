using Bogus;
using TableOfRecords.Tests.UserProfiles;

namespace TableOfRecords.Tests;

internal static class TestCasesDataSource
{
    public static readonly string ProfileShortTable =
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| FullName            | Age | Gender |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Kale Parker         |  66 | M      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Edgar Bradtke       |  58 | M      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Hugh Halvorson      |  21 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Katelin Beatty      |  84 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Imelda Kunze        |  37 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Agustina Hayes      |  50 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Adolphus Ratke      |  71 | M      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Llewellyn Considine |  56 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Etha Conroy         |  59 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}" +
        $"| Rosalinda Koelpin   |  83 | F      |{Environment.NewLine}" +
        $"+---------------------+-----+--------+{Environment.NewLine}";

    public static readonly string ProfileBasicTable =
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| FullName         | Age | Phone                 |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Ali Gulgowski    |  40 | (841) 459-7870        |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Burley Bahringer |  29 | (559) 781-2980 x7732  |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Aiden Mraz       |  35 | 563-316-2789 x49326   |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Silas Sipes      |  54 | 1-661-924-1834        |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Magdalen Jast    |  50 | 688-656-6408          |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Selena Funk      |  28 | (406) 275-6389        |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Connor Quitzon   |  24 | (204) 322-3071 x367   |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Clara Collins    |  39 | 759.567.3237 x39320   |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Rodrigo Reynolds |  63 | 260-740-6379 x17191   |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}" +
        $"| Josefa Welch     |  27 | 1-483-711-3344 x95528 |{Environment.NewLine}" +
        $"+------------------+-----+-----------------------+{Environment.NewLine}";

    public static readonly string ProfileExtendedTable =
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| FullName          | Age | Gender | Phone                | Email                                | Income              |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Fae Jones         |  19 | Female | (358) 701-0903       | FaeJones15@hotmail.com               | 671.683631630446900 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Letha Willms      |  29 | Female | (434) 639-2183       | LethaWillms10@gmail.com              | 405.045312547728700 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Felipe Walter     |  35 | Male   | 1-548-595-6242 x631  | FelipeWalter36@yahoo.com             | 393.901474400251300 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Irving Schmeler   |  24 | Male   | 834.993.7326 x354    | IrvingSchmeler11@hotmail.com         | 333.976505197701700 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Terrance Walter   |  54 | Male   | 804-633-6444 x01386  | TerranceWalter_Dietrich@yahoo.com    | 295.041072801922300 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Bryana Altenwerth |  39 | Male   | 507-995-5520         | BryanaAltenwerth.Stroman99@yahoo.com | 286.172295081424300 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Royce Cartwright  |  50 | Male   | 382-486-4785         | RoyceCartwright.Green@hotmail.com    | 648.800554144292200 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Libbie Rau        |  40 | Female | 1-908-707-4874 x914  | LibbieRau42@hotmail.com              | 398.764087394059900 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}" +
        $"| Rebeca Wolf       |  46 | Female | 1-579-313-3869 x2992 | RebecaWolf23@yahoo.com               | 188.542113971194900 |{Environment.NewLine}" +
        $"+-------------------+-----+--------+----------------------+--------------------------------------+---------------------+{Environment.NewLine}";

    public static readonly ICollection<ProfileShort> ProfileShort = new Faker<ProfileShort>("en")
        .RuleFor(x => x.FullName, f => f.Name.FullName())
        .RuleFor(x => x.Age, f => f.Random.Byte(18, 65))
        .RuleFor(x => x.Gender, f => f.PickRandom<Gender>().ToString()[0])
        .Generate(1000);

    public static readonly ICollection<ProfileBasic> ProfileBasic = new Faker<ProfileBasic>("en")
        .RuleFor(x => x.FullName, f => f.Name.FullName())
        .RuleFor(x => x.Age, f => f.Random.Byte(18, 65))
        .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
        .Generate(1000);

    public static readonly ICollection<ProfileExtended> ProfileExtended = new Faker<ProfileExtended>("en")
        .RuleFor(x => x.FullName, f => f.Name.FullName())
        .RuleFor(x => x.Age, f => f.Random.Byte(18, 65))
        .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber())
        .RuleFor(x => x.Email, (f, x) => f.Internet.Email(x.FullName))
        .RuleFor(x => x.Gender, f => f.PickRandom<Gender>().ToString())
        .RuleFor(x => x.Income, f => f.Vehicle.Random.Decimal(100, 1000))
        .Generate(1000);

    public static ICollection<ProfileShort> ProfileShortCollection => new List<ProfileShort>()
    {
        new ProfileShort() { FullName = "Kale Parker", Age = 66, Gender = 'M' },
        new ProfileShort() { FullName = "Edgar Bradtke", Age = 58, Gender = 'M' },
        new ProfileShort() { FullName = "Hugh Halvorson", Age = 21, Gender = 'F' },
        new ProfileShort() { FullName = "Katelin Beatty", Age = 84, Gender = 'F' },
        new ProfileShort() { FullName = "Imelda Kunze", Age = 37, Gender = 'F' },
        new ProfileShort() { FullName = "Agustina Hayes", Age = 50, Gender = 'F' },
        new ProfileShort() { FullName = "Adolphus Ratke", Age = 71, Gender = 'M' },
        new ProfileShort() { FullName = "Llewellyn Considine", Age = 56, Gender = 'F' },
        new ProfileShort() { FullName = "Etha Conroy", Age = 59, Gender = 'F' },
        new ProfileShort() { FullName = "Rosalinda Koelpin", Age = 83, Gender = 'F' },
    };

    public static ICollection<ProfileBasic> ProfileBasicCollection => new List<ProfileBasic>()
    {
        new ProfileBasic() { FullName = "Ali Gulgowski", Age = 40, Phone = "(841) 459-7870" },
        new ProfileBasic() { FullName = "Burley Bahringer", Age = 29, Phone = "(559) 781-2980 x7732" },
        new ProfileBasic() { FullName = "Aiden Mraz", Age = 35, Phone = "563-316-2789 x49326" },
        new ProfileBasic() { FullName = "Silas Sipes", Age = 54, Phone = "1-661-924-1834" },
        new ProfileBasic() { FullName = "Magdalen Jast", Age = 50, Phone = "688-656-6408" },
        new ProfileBasic() { FullName = "Selena Funk", Age = 28, Phone = "(406) 275-6389" },
        new ProfileBasic() { FullName = "Connor Quitzon", Age = 24, Phone = "(204) 322-3071 x367" },
        new ProfileBasic() { FullName = "Clara Collins", Age = 39, Phone = "759.567.3237 x39320" },
        new ProfileBasic() { FullName = "Rodrigo Reynolds", Age = 63, Phone = "260-740-6379 x17191" },
        new ProfileBasic() { FullName = "Josefa Welch", Age = 27, Phone = "1-483-711-3344 x95528" },
    };

    public static ICollection<ProfileExtended> ProfileExtendedCollection => new List<ProfileExtended>()
    {
        new ProfileExtended()
        {
            FullName = "Fae Jones",
            Age = 19,
            Gender = "Female",
            Phone = "(358) 701-0903",
            Email = "FaeJones15@hotmail.com",
            Income = 671.683631630446900m,
        },
        new ProfileExtended()
        {
            FullName = "Letha Willms",
            Age = 29,
            Gender = "Female",
            Phone = "(434) 639-2183",
            Email = "LethaWillms10@gmail.com",
            Income = 405.045312547728700m,
        },
        new ProfileExtended()
        {
            FullName = "Felipe Walter",
            Age = 35,
            Gender = "Male",
            Phone = "1-548-595-6242 x631",
            Email = "FelipeWalter36@yahoo.com",
            Income = 393.901474400251300m,
        },
        new ProfileExtended()
        {
            FullName = "Irving Schmeler",
            Age = 24,
            Gender = "Male",
            Phone = "834.993.7326 x354",
            Email = "IrvingSchmeler11@hotmail.com",
            Income = 333.976505197701700m,
        },
        new ProfileExtended()
        {
            FullName = "Terrance Walter",
            Age = 54,
            Gender = "Male",
            Phone = "804-633-6444 x01386",
            Email = "TerranceWalter_Dietrich@yahoo.com",
            Income = 295.041072801922300m,
        },
        new ProfileExtended()
        {
            FullName = "Bryana Altenwerth",
            Age = 39,
            Gender = "Male",
            Phone = "507-995-5520",
            Email = "BryanaAltenwerth.Stroman99@yahoo.com",
            Income = 286.172295081424300m,
        },
        new ProfileExtended()
        {
            FullName = "Royce Cartwright",
            Age = 50,
            Gender = "Male",
            Phone = "382-486-4785",
            Email = "RoyceCartwright.Green@hotmail.com",
            Income = 648.800554144292200m,
        },
        new ProfileExtended()
        {
            FullName = "Libbie Rau",
            Age = 40,
            Gender = "Female",
            Phone = "1-908-707-4874 x914",
            Email = "LibbieRau42@hotmail.com",
            Income = 398.764087394059900m,
        },
        new ProfileExtended()
        {
            FullName = "Rebeca Wolf",
            Age = 46,
            Gender = "Female",
            Phone = "1-579-313-3869 x2992",
            Email = "RebecaWolf23@yahoo.com",
            Income = 188.542113971194900m,
        },
    };
}
