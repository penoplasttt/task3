using System.Security.Cryptography;

namespace game
{
    class HMAC
    {
        public static byte[] ComputeHmacsha3(byte[] data, byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }
    }
}
