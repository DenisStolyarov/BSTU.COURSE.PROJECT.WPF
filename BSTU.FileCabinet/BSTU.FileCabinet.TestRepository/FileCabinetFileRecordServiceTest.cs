using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BSTU.FileCabinet.BLL.Interfaces;
using BSTU.FileCabinet.BLL.Services;
using BSTU.FileCabinet.DAL.Infrastructures;
using BSTU.FileCabinet.DAL.Interfaces;
using BSTU.FileCabinet.DAL.Repositories;
using BSTU.FileCabinet.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSTU.FileCabinet.TestRepository
{
    [TestClass]
    public class FileCabinetFileRecordServiceTest
    {
        private IUnitOfWork uow;

        [TestInitialize]
        public void SetupContext()
        {
            var factory = new FileCabinetDbContextFactory();
            this.uow = new UnitOfWork(factory);
        }

        [TestMethod, Priority(10)]
        public void TestFileRecordServiceExport()
        {
            //Arrange
            var service = new CommonFileRecordService<Student>();
            var path = "AuthorizationRecordTest.json";
            var entities = uow.Students.GetAll();
            //Act
            service.ExportRecords(entities, path);
            //Assert
            var result = File.ReadAllText(path);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, string.Empty);
            Debug.WriteLine(result);
        }

        [TestMethod, Priority(1)]
        public void TestFileRecordServiceImport()
        {
            //Arrange
            var service = new CommonFileRecordService<Authorization>();
            var path = "AuthorizationRecordTest.json";
            var entities = new List<Authorization>(uow.Authorizations.GetAll());
            //Act
            var result = service.ImportRecords(path);
            //Assert
            Assert.IsNotNull(result);
            Debug.WriteLine(result);
        }
    }
}
