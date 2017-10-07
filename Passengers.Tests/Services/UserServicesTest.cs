using AutoMapper;
using Moq;
using Passengers.Core.Domain;
using Passengers.Core.Repositories;
using Passengers.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passengers.Tests.Services
{
    //class with unit tests
    class UserServicesTest
    {
        [Fact]
public async Task register_async_should_invoke_add_onRegister()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypt>();
            var mapperMock = new Mock<IMapper>();

            var userSerivce = new UserService(userRepositoryMock.Object,encrypterMock.Object, mapperMock.Object);
            await userSerivce.Register(Guid.NewGuid(),"user@gmail.com", "user", "secret","user");

            //Verify what's happened, to know what is being checked
            userRepositoryMock.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task When_Calling_getAsync_UserExist()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypt>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, encrypterMock.Object, mapperMock.Object);
            await userService.Get("user@gmail.com");

            var user = new User(Guid.NewGuid(),"user@gmail.com", "user1", "secret", "user","salt");

            userRepositoryMock.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(user);

            //Verify what's happened, to know what is being checked
            userRepositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_calling_getAndUser_DesNoeExist()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypt>();
            var mapperMock=new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object,encrypterMock.Object, mapperMock.Object);
            await userService.Get("User@mail.com");

            userRepositoryMock.Setup(x => x.Get("User@gmail.com"))
                .ReturnsAsync(() => null);


            //Verify what's happened, to know what is being checked
            userRepositoryMock.Verify(x => x.Get(It.IsAny<string>()), Times.Once);
        }
    }
}
