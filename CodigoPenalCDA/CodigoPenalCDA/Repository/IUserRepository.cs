using System.Collections.Generic;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;

namespace CodigoPenalCDA.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);

        User ValidateCredentials(string username);
        
        User FindByUsername(string username);

        List<User> FindAll();

        bool RevokeToken(string username);

        User RefreshUserInfo(User user);
    }
}