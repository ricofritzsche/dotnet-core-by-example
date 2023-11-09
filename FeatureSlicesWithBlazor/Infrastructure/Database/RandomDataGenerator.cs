namespace FeatureSlicesWithBlazor.Infrastructure.Database;

public static class RandomDataGenerator
{
    private static readonly Random Random = new();

    private static readonly string[] PossibleCountries = 
    {
        "Germany", "England", "France", "Spain", "Italy", 
        "Netherlands", "Portugal", "Denmark", "Sweden", "Finland"
    };

    private static readonly string[] FirstName = 
    {
        "James", "Olivia", "Ethan", "Sophia", "Michael", "Isabella", "Alexander", 
        "Emma", "William", "Ava", "Matthew", "Charlotte", "Daniel", "Mia", 
        "Henry", "Amelia", "Joseph", "Harper", "David", "Evelyn"
    };

    private static readonly string[] LastName = 
    {
        "Smith", "Johnson", "Williams", "Brown", "Jones", 
        "Garcia", "Miller", "Davis", "Rodriguez", "Martinez", 
        "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", 
        "Thomas", "Taylor", "Moore", "Jackson", "Martin"
    };

    public static User[] GenerateUsers()
    {
        var users = new List<User>();

        for (var i = 0; i < 100; i++)
        {
            var displayName = $"{FirstName[Random.Next(FirstName.Length)]} {LastName[Random.Next(LastName.Length)]}";
            var userName = displayName.ToLower().Replace(" ", ".");
            var years = Random.Next(-50, -18);
            var days = Random.Next(10, 100);
            var user = new User 
            {
                UserId = Guid.NewGuid(),
                DisplayName = displayName,
                Username = userName,
                Email = $"{userName}@example.com",
                DateOfBirth = DateTime.Now.AddYears(years).AddDays(days) 
            };

            users.Add(user);
        }

        return users.ToArray();
    }
}