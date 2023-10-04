using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Hash
    {
        public static string GetHash(string password)
        {

            var hash2 = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 8);

            return hash2;
        }

        public static bool ValidatePassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}
