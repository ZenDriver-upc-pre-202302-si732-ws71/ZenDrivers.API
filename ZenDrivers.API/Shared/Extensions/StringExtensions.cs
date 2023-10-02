using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;

namespace ZenDrivers.API.Shared.Extensions;
public static partial class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            
            yield return char.ToLower(e.Current);

            while(e.MoveNext())
            {
                if(char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
    }

    public static bool HasOnlyNumbers(this string text) => text.All(char.IsDigit);
    public static bool IsName(this string text) => !text.IsNullOrEmpty() && NameRegex().IsMatch(text.Trim());
    public static bool IsBlank(this string text) => text.Trim().IsNullOrEmpty();
    
    [GeneratedRegex("[A-Za-z ]*")]
    private static partial Regex NameRegex();
}
