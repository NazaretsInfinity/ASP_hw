namespace ASPrazorpages.Services.Implementations
{
    public class StringService : IStringService
    {
        public string ToTitle(string text)
        {
            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
