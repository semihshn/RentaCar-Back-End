using Microsoft.IdentityModel.Tokens;
//Şifreleme işleminin yapıldığı yer burası , fonksiyona şifrelenmesi gereken parolayı veriyoruz aprametre olarak ve hangi şifreleme algoritması kullanılacağını söylüyoruz
namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);//Hash işlemi yaparken anahtar oalrak parametre oalrak gelen securityKey kullan şifreleme algoritması olarak da HmacSha512 kullan.
        }
    }

}
