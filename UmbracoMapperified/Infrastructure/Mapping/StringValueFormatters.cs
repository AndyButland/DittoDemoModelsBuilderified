namespace TxtStarter.Infrastructure.Mapping
{
    using Umbraco.Core;

    /// <summary>
    /// Provides pre-defined string value formatter functions used when transforming string data when mapping to view models
    /// </summary>
    public static class StringValueFormatters
    {
        /// <summary>
        /// Removed HTML and truncates page body text to required number of characters
        /// </summary>
        /// <param name="input">Input text to truncate</param>
        /// <returns>Truncated text</returns>
        public static string TruncatePageText(string input)
        {
            return Truncate(input, 100);
        }

        /// <summary>
        /// Removed HTML and truncates news item page body text to required number of characters
        /// </summary>
        /// <param name="input">Input text to truncate</param>
        /// <returns>Truncated text</returns>
        public static string TruncateNewsPageText(string input)
        {
            return Truncate(input, 200);
        }

        /// <summary>
        /// Helper to remove HTML and truncate page body text to required number of characters
        /// </summary>
        /// <param name="input">Input text to truncate</param>
        /// <param name="truncateToCharacters">Number of characters to truncate to</param>
        /// <returns>Truncated text</returns>
        private static string Truncate(string input, int truncateToCharacters)
        {
            return input.StripHtml().Truncate(truncateToCharacters);
        }
    }
}