using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class MD5Util
    {
        public static string GetMD5(string str)
        {
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}