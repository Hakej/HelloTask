﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Mappers;
using HelloTask.Infrastructure.Services;
using Moq;
using Xunit;

namespace HelloTask.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task RegisterUser_WithAlreadyRegisteredEmail_ThrowsException()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            const string mockEmail = "user@test.com";

            userRepositoryMock.Setup(s => s.GetByEmailAsync(mockEmail))
                .Returns(Task.FromResult(new User(Guid.NewGuid(), mockEmail, "test", "test", "test", "test")));
            
            var userService = new UserService(mapperMock.Object, userRepositoryMock.Object, encrypterMock.Object);

            await Assert.ThrowsAsync<Exception>(() =>
                userService.RegisterUserAsync(Guid.NewGuid(), mockEmail, "test", "test", "test"));
        }

        [Fact]
        public async Task RegisterUserAsync_InvokesAddAsyncOnRepositoryOnce()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(mapperMock.Object, userRepositoryMock.Object, encrypterMock.Object);

            await userService.RegisterUserAsync(Guid.NewGuid(), "", "", "", "");
            
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}