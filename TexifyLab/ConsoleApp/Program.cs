using System;

// Nhận tham số từ dòng lệnh
var argsSample = Environment.GetCommandLineArgs();

if (argsSample.Length >= 3)
{
    // Lấy 2 tham số đầu tiên sau tên chương trình
    if (double.TryParse(argsSample[1], out double a) && double.TryParse(argsSample[2], out double b))
    {
        double result = a * b;

        // In kết quả để sử dụng trong GitHub Actions
        Console.WriteLine($"result={result}");

        // Ghi vào GitHub output (dùng cho GitHub Actions)
        // Cách 1: Ghi trực tiếp vào file GITHUB_OUTPUT
        string githubOutput = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
        if (!string.IsNullOrEmpty(githubOutput))
        {
            File.AppendAllText(githubOutput, $"multiplication_result={result}{Environment.NewLine}");
        }

        // Cách 2: In dạng đặc biệt GitHub Actions có thể đọc được
        Console.WriteLine($"::set-output name=multiplication_result::{result}");
    }
    else
    {
        Console.WriteLine("Should input valid info for a & b");
        Environment.ExitCode = 1;
    }
}
else
{
    Console.WriteLine("Please, provider a & b data");
    Console.WriteLine("Use: dotnet run -- <a> <b>");
    Console.WriteLine("dotnet ConsoleApp.dll 9 3");
    Environment.ExitCode = 1;
}