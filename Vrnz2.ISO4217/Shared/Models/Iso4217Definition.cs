namespace Vrnz2.ISO4217.Shared.Models
{
    public class Iso4217Definition
    {
        public Iso4217Definition(string code, int number, int exponent)
        {
            this.Code = code;
            this.Number = number;
            this.Exponent = exponent;
        }

        public string Code { get; }

        public int Number { get; }

        public int Exponent { get; }
    }
}
