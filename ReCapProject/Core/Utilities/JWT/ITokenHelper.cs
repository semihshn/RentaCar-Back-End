using Core.Entities.Concrete;
using System.Collections.Generic;
using System;
using System.Text;

namespace Core.Utilities.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);//İlgili kullanıcının claimlerini içeren bir token üretiyor
    }
}
