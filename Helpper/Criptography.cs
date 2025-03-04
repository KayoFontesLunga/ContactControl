using System.Security.Cryptography;
using System.Text;

namespace ContactControl.Helpper;

public static class Criptography
{
    public static string Encrypt(this string value)
    {
        var hash = SHA1.Create();
        var encoding = new ASCIIEncoding();
        var array = encoding.GetBytes(value);

        array = hash.ComputeHash(array);
        var stringBuilder = new StringBuilder();

        foreach (var item in array)
        {
            stringBuilder.Append(item.ToString("x2"));
        }
        return stringBuilder.ToString();
    }
}
