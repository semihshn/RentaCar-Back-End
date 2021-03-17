using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Hashing
{
    public class HashingHelper
    {
        //Verdiğimiz passwordun hash'ini oluşturmaya yarıyor

        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        //VerifyPasswordHash=Sonradan sisteme girmek isteyen kişinin , verdiği password ile bizim veri tabanımızda bulunan hash'in Saltımıza göre eşleşip eşleşmediğinin kontrolünü yapan yerdir yani kullanıcının parolası doğru mu yanlış mı kontrol eder
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
