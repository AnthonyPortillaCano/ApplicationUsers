using System.Security.Cryptography;
using System.Text;

namespace CleanArchitecture.MinimalApi.Util
{
    public class Encrypt
    {
        public static  string EncodeToBase64(string decodeString)
        {
            string encodedStr = Convert.ToBase64String(Encoding.UTF8.GetBytes(decodeString));
            return encodedStr;
        }

        public static string DecodeToBase64(string encodeString)
        {
            string inputStr = Encoding.UTF8.GetString(Convert.FromBase64String(encodeString));
            return inputStr;
        }
    }
}
