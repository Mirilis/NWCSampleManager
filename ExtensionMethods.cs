using System.Text;

namespace NWCSampleManager
{
    public static class ExtensionMethods
    {
        #region Public Methods

        public static string RemoveSpecialCharacters(this string input)
        {
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    if ((input[i] >= '0' && input[i] <= '9')
                        || (input[i] >= 'A' && input[i] <= 'z'
                            || (input[i] == '.' || input[i] == '_')))
                    {
                        sb.Append(input[i]);
                    }
                }

                return sb.ToString();
            }
        }

        public static string SplitCamelCase(this string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
        }

        #endregion Public Methods
    }
}