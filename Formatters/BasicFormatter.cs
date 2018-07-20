namespace Formatters
{
    public class BasicFormatter : IFormatter
    {
        public string Format(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}