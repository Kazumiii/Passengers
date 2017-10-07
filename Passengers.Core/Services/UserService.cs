using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passengers.Core.DTO;
using AutoMapper;
using System.Threading.Tasks;
using Passengers.Core.Exceptions;

namespace Passengers.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;

        private readonly IEncrypt _encrypter;

        private readonly IUserRepository repo;
        // I'm sending IUserRepository to get abstraction by data type
        public UserService(IUserRepository Userrepo, IEncrypt encrypt, IMapper mapka)
        {

            _encrypter = encrypt;
            repo = Userrepo;
            mapper = mapka;

        }

        public async Task<IEnumerable<UserDTO>> BrowseAsync()
        {
            var user = await repo.GetAll();
            return mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(user);
        }

        public async Task< UserDTO >Get(string email)
        {
            var user = await repo.Get(email);
            //here i'm mapping user on userDTO (user paeameter is necessary to know who i want mapping)
            return mapper.Map<User, UserDTO>(user);
        }

        public async Task LoginAsync(string email, string paasword)
        {

            var user = await repo.Get(email);
            if (user != null)
            {
                throw new ServiceException(ErrorCode.InvalidCredential,"Invalid credentials");
            }

            //encyptiong informations
            var salt = _encrypter.GetSalt(paasword);
            var hash = _encrypter.GetHash(paasword,user.Salt);


            if(user.Password==hash)
            {
                return;
            }
            else
            {

                throw new ServiceException(ErrorCode.InvalidCredential,"Invalid credentials");
            }
        }

        public async Task Register(Guid id,string email,string userName, string password,string role)
        {
            //check if user already exist

            var user =await repo.Get(email);
            if(user!=null)
            {
                throw new ServiceException(ErrorCode.EmailInUse,"User with this email already exist");
            }
            else
            {
                //hash is encrpyten in one-way
                var Salt = _encrypter.GetSalt(password);
                var hash = _encrypter.GetHash(password, Salt);
                user =  new User(id,email,userName,hash,role,Salt);
            await    repo.Add(user);
                
            }

        }
    }
}
