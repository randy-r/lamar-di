namespace Formatters
{
    public class FancyFormatter : IFormatter
    {
        public string Format(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }
    }
}