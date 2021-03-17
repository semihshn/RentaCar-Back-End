using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//API içindeki appsettings.json'u okuyabilmemizi sağlıyor
        private TokenOptions _tokenOptions;//appsettings içindeki değerleri atadığımız , yerleştirdiğimiz ve buradan çağırdığımız model diyebiliriz
        private DateTime _accessTokenExpiration;//Token ne zaman geçersizleşecek onu belirliyor
        public JwtHelper(IConfiguration configuration)//appsettings içindeki token ile ilgili bilgiyi configuration parametresi ile okuyabileceğiz
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//appsettings içindeki TokenOptions section(bölüm/kısım)'ını TokenOptions içindeki sabitlerle eşitle , yani modelle , maple de diyebiliriz

        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)//Kullanıcı için token ürettiğimiz kısım , parametre oalrak gelen user ve claim bilgisinbe göre token oluşturuluyor
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);//Token geçerlilik süresi belirleniyor
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Token oluşturuluyor
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);//SigningCredentialsHelper ile parola şifreleniyor , hashleniyor ,saltlanıyor
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//Bu bizim için bir json web token üretecektir
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();//Token bilgisini değişkene atıyoruz
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//token bilgisinin olduğu değişkeni yazdırıyoruz

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            //Claims=Kullanıcıyla tanımlanacak haklar , görebileceği sayfalar , ekleme ,silme yetkisi falan 
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());//Bu fonksiyonları Core/Extensions/ClaimExtensions içinden aldık , Yeni yetki ekleememizi sağlar
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
