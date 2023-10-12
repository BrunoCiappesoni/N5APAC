namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    [TestInitialize]
    public void InitTest()
    {

    }
        private Exception expectedException;
        [TestMethod]
        public void PostStudentOk()
        {
            Student studentToInsert = new Student()
            {
                Name = "student"
            };

            Mock<IStudentLogic> logic = new Mock<IStudentLogic>(MockBehavior.Strict);
            logic.Setup(logic => logic.InsertStudents(studentToInsert));
            var studentController = new StudentController(logic.Object);
            var expectedObjectResult = new CreatedAtActionResult("CreateStudent", "CreateStudent", new { id = 2 }, studentToInsert);


            var result = studentController.CreateStudent(studentToInsert);

            logic.VerifyAll();
            CreatedAtActionResult resultObject = result as CreatedAtActionResult;
            Assert.AreEqual(resultObject.StatusCode, expectedObjectResult.StatusCode);
            Assert.AreEqual(resultObject.Value, studentToInsert);
        }


        [TestMethod]
        public void PostStudentFail()
        {
            Student studentToInsert = new Student()
            {
                Name = "exception"
            };

            Mock<IStudentLogic> logic = new Mock<IStudentLogic>(MockBehavior.Strict);
            var studentController = new StudentController(logic.Object);
            var expectedObjectResult = new CreatedAtActionResult("CreateStudent", "CreateStudent", new { id = 2 }, studentToInsert);

            try
            {
                var result = studentController.CreateStudent(studentToInsert);
            }
            catch (Exception ex)
            {
                expectedException = ex;
            }
            logic.VerifyAll();
            Assert.IsNotNull(expectedException);
            Assert.AreEqual(expectedException.Message, "excepcion");
        }
 }



