using System;
using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.BLL.Services;
using BSTU.FileCabinet.BLL.Services.Exceptions;
using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSTU.FileCabinet.TestRepository
{
    [TestClass]
    public class FileCabinetAuthorizationServiceTest
    {
        private IAuthorizationService service;
        private IUnitOfWork uow;

        [TestInitialize]
        public void SetupContext()
        {
            var factory = new FileCabinetDbContextFactory();
            uow = new UnitOfWork(factory);
            this.service = new AuthorizationService(uow);
        }

        [TestMethod]
        public void TestAuthorizationServiceGetAdminWindowType()
        {
            //Arrange
            var login = "admin";
            var password = "admin";
            var expectedResult = WindowType.Admin;
            //Act
            var result = service.GetWindowType(login, password, out var id);
            //Assert
            Assert.AreEqual(expectedResult, result);
            Assert.IsNull(id);
        }

        [TestMethod]
        public void TestAuthorizationServiceGetUserWindowType()
        {
            //Arrange
            var login = "user";
            var password = "user";
            var expectedResult = WindowType.User;
            //Act
            var result = service.GetWindowType(login, password, out var id);
            //Assert
            Assert.AreEqual(expectedResult, result);
            Assert.IsNotNull(id);
        }

        [TestMethod]
        public void TestAuthorizationServiceGetLoginException()
        {
            //Arrange
            var login = "Error";
            var password = "user";
            //Assert
            Assert.ThrowsException<WrongAuthorizationParameterException>(() =>
            {
                var result = service.GetWindowType(login, password, out var id);
            });
        }

        [TestMethod]
        public void TestAuthorizationServiceGetPasswordException()
        {
            //Arrange
            var login = "user";
            var password = "Error";
            //Assert
            Assert.ThrowsException<WrongAuthorizationParameterException>(() =>
            {
                var result = service.GetWindowType(login, password, out var id);
            });
        }

        [TestMethod]
        public void TestAuthorizationServiceGetWrongUserException()
        {
            //Arrange
            var login = "Error";
            var password = "Error";
            var wrongUser = new Authorization()
            {
                Login = login,
                Password = password,
                Role = "user",
                UserId = null,
            };
            //Act
            uow.Authorizations.Create(wrongUser);
            //Assert
            Assert.ThrowsException<WrongAuthorizationParameterException>(() =>
            {
                var result = service.GetWindowType(login, password, out var id);
            });
            uow.Authorizations.Delete(login);
        }
    }
}
