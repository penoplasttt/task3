using System.Security.Cryptography;

namespace game
{
    class Key
    {
        public static byte[] GenKey()
        {
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] tokenData = new byte[32];
            rng.GetBytes(tokenData);
            return (tokenData);
        }
    }
}
