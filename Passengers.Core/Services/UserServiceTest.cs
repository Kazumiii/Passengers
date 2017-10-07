using AutoMapper;
using Moq;
using Passengers.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Core.Services
{
    class UserServiceTest
    {
        [Fact]
        public async Task Register_should_Invoke_Add_OnRepository()
        {
            var UserRepository = new Mock<InMemoryUserRepository>();
            var MockMapper = new Mock<IMapper>();

         //   var userSerivce = new UserService(UserRepository.Object,MockMapper.Object);
      // await     userSerivce.Register("user1@gmail.com","User1","secrert");

            UserRepository.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }
    }
}
