using System.Security.Cryptography;
using System.Text;

namespace Travel.Utilities
{
    public class Function
    {
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));

            }
            return strBuilder.ToString();
        }

        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);

            for (int i = 0; i <= 5; i++)
                str = MD5Hash(str + "_" + str);
            return str;
        }

        public static int _UserID = 0;
        public static string _Username = String.Empty;

        public static string _Email = String.Empty;


        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;

        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Email) || (Function._UserID <= 0))
                return false;
            return true;



        }
    
}
}
