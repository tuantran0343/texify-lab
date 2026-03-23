namespace TexifyLab
{
    public static class StringExtensions
    {
        public static string Intersperse(this string? input, string separator)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(separator, nameof(separator));

            if(string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return string.Join(separator.ToString(), input.ToCharArray());
        }
    }
}
