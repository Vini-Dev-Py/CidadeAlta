using CodigoPenalCDA.Data.Converter.Contract;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodigoPenalCDA.Data.Converter.Implementations
{
    public class UserConverter : IParser<UserVO, User>, IParser<User, UserVO>
    {
        public User Parse(UserVO origin)
        {
            if (origin == null) return null;
            return new User
            {
                Id = origin.Id,
                UserName = origin.UserName,
                Password = origin.Password
            };
        }

        public List<User> Parse(List<UserVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public UserVO Parse(User origin)
        {
            if (origin == null) return null;
            return new UserVO
            {
                Id = origin.Id,
                UserName = origin.UserName,
                Password = origin.Password
            };
        }

        public List<UserVO> Parse(List<User> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}