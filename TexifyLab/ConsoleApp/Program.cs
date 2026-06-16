// See https://aka.ms/new-console-template for more information
using ConsoleApp;
using System.Text.Json;

Console.WriteLine("Hello world, this is sample text from 01234!");

await Task.Delay(5000);

var httpClient = new HttpClient();

// Cấu hình base address của WireMock
httpClient.BaseAddress = new Uri("http://wiremock:8080");

var totalTime = 0;

while (true)
{
    if (totalTime == 3)
    {
        break;
    }

    await Task.Delay(2000);

    Console.WriteLine("Starting to fetch users from WireMock every 3 seconds...");

    try
    {
        HttpResponseMessage response = await httpClient.GetAsync("/api/v1/users");

        if (response.IsSuccessStatusCode)
        {
            // Đọc response dưới dạng string
            string jsonString = await response.Content.ReadAsStringAsync();

            // Deserialize JSON thành List<User>
            var users = JsonSerializer.Deserialize<List<User>?>(jsonString) ?? new List<User>();

            // In thông tin users ra console
            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] Received {users.Count} users:");
            foreach (var user in users)
            {
                Console.WriteLine($"  - {user.FirstName} {user.LastName} ({user.UserName})");
            }
        }
        else
        {
            Console.WriteLine($"API call failed with status: {response.StatusCode}");
        }


        await Task.Delay(3000); // 3000ms = 3 seconds
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        await Task.Delay(3000);
    }
    finally
    {
        totalTime++;        
    }
}

Console.WriteLine("Ending program");

//Console.ReadKey();