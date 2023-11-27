using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        string cultureIdentifier = "en-us";
        CultureInfo cultureInfo = new CultureInfo(cultureIdentifier);

        // Instead, consider using the InvariantCulture
        // CultureInfo cultureInfo = CultureInfo.InvariantCulture;

        // Use the cultureInfo object as needed in your code

        // For example, formatting a date
        DateTime now = DateTime.Now;
        string formattedDate = now.ToString("yyyy-MM-dd", cultureInfo);
        Console.WriteLine(formattedDate);
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>(); 
            });
}
