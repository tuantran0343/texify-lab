namespace TexifyLab
{
    public static class StringExtensions
    {
        public static string? Intersperse(this string? input, string separator)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(separator, nameof(separator));

            if(string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            return string.Join(separator.ToString(), input.ToCharArray());
        }

        public static string TruncateSmart(this string value, int maxChars, string ellipsis = "...")
        {
            if (string.IsNullOrEmpty(value) || value.Length <= maxChars)
                return value;

            int lastSpace = value.LastIndexOf(' ', maxChars);
            return (lastSpace > 0
                ? value[..lastSpace].TrimEnd()
                : value[..maxChars]) + ellipsis;
        }
    }
}
