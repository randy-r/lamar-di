namespace LamarDI.Formatters
{
    public class FancyFormatter : IFormatterB
    {
        public string Format(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }
    }
}