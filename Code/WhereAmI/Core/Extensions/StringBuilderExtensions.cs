using System.Text;

namespace WhereAmI.Core.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void AppendDelimiter(this StringBuilder sb, string delimiter)
        {
            if (sb.Length != 0)
            {
                sb.AppendLine(delimiter);
            }
        }
    }
}
