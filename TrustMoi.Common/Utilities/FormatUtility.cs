using System;
using System.Text;

namespace TrustMoi.Common.Utilities
{
    public static class FormatUtility
    {
        public static string GetExceptionMessage(Exception exception)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"Message: {exception.Message}");
            stringBuilder.Append(Environment.NewLine);

            if (exception.InnerException != null)
            {
                stringBuilder.Append($"Inner exception: {exception.InnerException.Message}");
                stringBuilder.Append(Environment.NewLine);
            }

            stringBuilder.Append(exception.StackTrace);

            return stringBuilder.ToString();
        }

        private const string DateFormat = @"MMMM dd, yyyy";

        public static string GetFormattedDate(DateTime? date) => date?.ToString(format: DateFormat) ?? string.Empty;
    }
}