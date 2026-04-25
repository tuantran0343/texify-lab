using System;

// Nhận tham số từ dòng lệnh
var argsSample = Environment.GetCommandLineArgs();

if (argsSample.Length >= 3)
{
    // Lấy 2 tham số đầu tiên sau tên chương trình
    if (double.TryParse(argsSample[1], out double a) && double.TryParse(argsSample[2], out double b))
    {
        double result = a * b;

        Console.WriteLine($"result={result}");
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