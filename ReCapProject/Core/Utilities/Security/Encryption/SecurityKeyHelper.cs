using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
//Saltlama yani tuzlama işlemi yaparken bir string ifade veriyoruz ancak bunu parolaya tuzlarken byte array haline getirmek gerekiyor işte bu işi SEcurityKeyHelper yapıyor tuzlama işlemi için rastgele verilen string ifadeyi byte arraye çeviriyor
namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }

}
