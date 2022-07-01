using CodigoPenalCDA.Data.VO;

namespace CodigoPenalCDA.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);

        TokenVO ValidateCredentials(TokenVO token);

        bool RevokeToken(string userName);

        UserVO Create(UserVO user);
    }
}