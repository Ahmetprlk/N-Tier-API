using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitofWorks;
using Service.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public UserService(IGenericRepository<User> repository, IUnitOfWorks unitOfWorks, IUserRepository userRepository, ITokenHandler tokenHandler) : base(repository, unitOfWorks)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }

        public User GetByEmail(string email)
        {
            User user = _userRepository.Where(x=>x.Email ==email).FirstOrDefault();
            return user ?? user;
        }

        public async Task<Token> Login(UserLoginDto userloginDto)
        {
            Token token = new Token();
            var user = GetByEmail(userloginDto.Email);
            if (user == null) 
            {
                return null;
            }
            var result = false;
            result = HashingHelper.verifyPassword(userloginDto.Password, user.PasswordHash, user.PasswordSalt);

            List<Role>  roles = new List<Role>();

            if (result) 
            {
                token = _tokenHandler.CreateToken(user, roles);
                return token;
            }
            return null;
        }
    }
}
