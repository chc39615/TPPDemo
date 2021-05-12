using System;
using System.Security.Cryptography;

namespace Utility
{
    public class RandomMethod
    {
        /// <summary>
        /// 產生一組長度為 4 的倍數的亂碼
        /// </summary>
        /// <param name="length">4的倍數</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length)
        {

            if (length < 4)
                throw new Exception("長度不可小於4");

            if (length % 4 != 0)
                throw new Exception("長度應為4的倍數");


            int bytes = ((length / 4) - 1) * 3 + 2;

            var randomNumber = new byte[bytes];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
