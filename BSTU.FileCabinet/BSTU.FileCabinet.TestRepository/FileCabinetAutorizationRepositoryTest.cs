using System;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.DAL.Repositories.Common;
using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSTU.FileCabinet.DAL.Interfaces;

namespace BSTU.FileCabinet.TestRepository
{
    [TestClass]
    public class FileCabinetAutorizationRepositoryTest
    {
        private FileCabinetDbContextFactory factory;
        private IUnitOfWork uow;

        [TestInitialize]
        public void SetupContext()
        {
            this.factory = new FileCabinetDbContextFactory();
            this.uow = new UnitOfWork(factory);
        }

        [TestMethod, Priority(0)]
        public void TestAuthorizationsGetAllMethod()
        {
            
            foreach (var accout in uow.Authorizations.GetAll())
            {
                Console.Write($"{accout.Login} + {accout.Password} + {accout.Role} + ");
                if (accout.UserId.HasValue)
                {
                    Console.Write($"{accout.UserId} + {accout.Student.FirstName}");
                }
                Console.WriteLine();
            }
        }

        [TestMethod, Priority(0)]
        public void TestAuthorizationsGetMethod()
        {

            var accout = uow.Authorizations.Get("admin");
            Assert.IsNotNull(accout);
            Console.WriteLine($"{accout.Login} + {accout.Password} + {accout.Role} + ");
            if (accout.UserId.HasValue)
            {
                Console.Write($"{accout.UserId} + {accout.Student.FirstName}");
            }
            
        }

        [TestMethod, Priority(1)]
        public void TestAuthorizationsCreateMethod()
        {

            var accout = new Authorization();
            accout.Login = "Test";
            accout.Password = "Test";
            accout.Role = "user";
            accout.UserId = 1;

            var result = uow.Authorizations.Create(accout);
            Assert.AreEqual(result, true);
        }

        [TestMethod, Priority(2)]
        public void TestAuthorizationsUpdateMethod()
        {
            var entity = new Authorization();
            entity.UserId = 2;
            var result = uow.Authorizations.Update("Test", entity);
            Assert.AreEqual(result, true);
        }

        [TestMethod, Priority(3)]
        public void TestAuthorizationsDeleteMethod()
        {
            var result = uow.Authorizations.Delete("Test");
            Assert.AreEqual(result, true);
        }
    }
}
