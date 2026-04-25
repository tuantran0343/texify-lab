using System.Text.Json.Serialization;

namespace ConsoleApp;

public class User
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("userName")]
    public string UserName { get; set; }
}
