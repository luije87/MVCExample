using System;
using System.Web.Mvc;
using Moq;
using MVCExample.Controllers;
using MVCExample.DAL;
using MVCExample.Models;
using MVCExampleUnitTest.App_Data;
using MVCExampleUnitTest.FakeDB;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MVCExampleUnitTest.Features
{
    [TestFixture]
    public class StudentControllerTest
    {
        private FakeSchoolContext _fakeSchoolContext;
        private StudentsController _studentsController;

        [SetUp]
        public void Init()
        {
            _studentsController = new StudentsController();
            _fakeSchoolContext = new FakeSchoolContext();
            _fakeSchoolContext.AddSet(TestData.Students);
            _studentsController.Db = _fakeSchoolContext;
        }

        [Test]
        public void Index()
        {
            var viewResult = _studentsController.Index() as ViewResult;
            Assert.IsNotNull(viewResult.Model);            
        }

        [Test]
        public void Details_With_Not_Null_Value()
        {
            var soMock = new Mock<ISchoolContext>();
            soMock.Setup(context => context.Find<Student>(It.IsNotNull<int>())).Returns(new Student());
            _studentsController.Db = soMock.Object;
            var actionResult = _studentsController.Details(1) as ViewResult;
            Assert.IsNotNull(actionResult.Model);
        }

        [Test]
        public void Details_With_Null_Value()
        {
            var soMock = new Mock<ISchoolContext>();
            soMock.Setup(context => context.Find<Student>(It.IsAny<int>())).Returns(() => null);
            _studentsController.Db = soMock.Object;
            var actionResult = _studentsController.Details(1);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof (HttpNotFoundResult), actionResult );
        }

        [Test]
        public void Details_With_Null_Id_Value()
        {
            var soMock = new Mock<ISchoolContext>();
            soMock.Setup(context => context.Find<Student>(It.IsAny<int>()));
            _studentsController.Db = soMock.Object;
            var actionResult = _studentsController.Details(null);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf(typeof (HttpStatusCodeResult), actionResult);
        }

        [Test]
        public void Create_WithOut_Arguments()
        {
            NUnit.Framework.Assert.Throws(typeof (DivideByZeroException), () => _studentsController.Create());
        }
    }
}