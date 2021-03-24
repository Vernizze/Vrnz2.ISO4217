using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Vrnz2.ISO4217.Infrastructure.Extensions;
using Vrnz2.ISO4217.UseCases.GetIso4217InfoByCode;

namespace Vrnz2.ISO4217.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]Starting process...");

            var services = new ServiceCollection();

            services.AddISO4217(30 * 1000);

            var iso4217Number971Value = GetIso4217InfoByCode.Handler.Instance.GetIso4217DefinitionByNumber(971);

            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]ISO4217 Number 971 result: {JsonConvert.SerializeObject(iso4217Number971Value)}...");

            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]Finalizing process...");

            Console.ReadLine();
        }
    }
}
