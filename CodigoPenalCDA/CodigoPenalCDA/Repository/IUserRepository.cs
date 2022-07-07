using System.Collections.Generic;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;

namespace CodigoPenalCDA.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}