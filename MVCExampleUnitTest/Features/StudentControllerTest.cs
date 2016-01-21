using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCExample.Controllers;
using MVCExample.Models;
using MVCExampleUnitTest.App_Data;
using MVCExampleUnitTest.FakeDB;

namespace MVCExampleUnitTest.Features
{
    [TestClass]
    public class StudentControllerTest
    {
        private readonly FakeSchoolContext _fakeSchoolContext = new FakeSchoolContext();

        [TestInitialize]
        public void Init()
        {
            _fakeSchoolContext.AddSet(TestData.Students);
        }

        [TestMethod]
        public void Index()
        {
            var controller = new StudentsController(_fakeSchoolContext);
            _fakeSchoolContext.Add(new Student());
            var viewResult = controller.Index() as ViewResult;
            Assert.IsNotNull(viewResult.Model);
        }
    }
}