using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Vrnz2.ISO4217.Infrastructure.Extensions;
using Vrnz2.ISO4217.Shared.Models;
using Vrnz2.ISO4217.UseCases.GetIso4217InfoByCode;
using Vrnz2.ISO4217.UseCases.GetIso4217InfoByNumber;

namespace Vrnz2.ISO4217.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]Starting process...");

            var services = new ServiceCollection();

            services.AddISO4217(30 * 1000);

            Iso4217Definition iso4217Number971ValueByNumber = GetIso4217InfoByNumber.Handler.Instance.GetDefinition(971);
            string iso4217Number971CodeByNumber = GetIso4217InfoByNumber.Handler.Instance.GetCode(iso4217Number971ValueByNumber.Number);

            Iso4217Definition iso4217Number971ValueByCode = GetIso4217InfoByCode.Handler.Instance.GetDefinition(iso4217Number971ValueByNumber.Code);
            Nullable<int> iso4217Number971NumberByCode = GetIso4217InfoByCode.Handler.Instance.GetNumber(iso4217Number971ValueByNumber.Code);

            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]ISO4217 Number 971 result (By Number): {JsonConvert.SerializeObject(iso4217Number971ValueByNumber)}...");
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]ISO4217 Number 971 result (Code By Number): {iso4217Number971CodeByNumber}...");

            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]ISO4217 Number 971 result (By Code): {JsonConvert.SerializeObject(iso4217Number971ValueByCode)}...");
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]ISO4217 Number 971 result (Number By Code): {iso4217Number971NumberByCode}...");

            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")}]Finalizing process...");

            Console.ReadLine();
        }
    }
}
