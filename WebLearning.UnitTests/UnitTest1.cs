using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebLearning.web.Models.Tasks;

namespace WebLearning.UnitTests
{
    [TestClass]
    public class SubjectsTest
    {
        [TestMethod]
        public void Subject_SubjectCreate_ReturnsSubject()
        {
            //Arrange
            //var test = new Subject();

            //Act
            var result = Subject.NewSubject("test", new List<string>() { "test" });

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Subject_SubjectCreate_ReturnsNull()
        {
            //Arrange
            //var test = new Subject();

            //Act
            var result = Subject.NewSubject("test", new List<string>() { "test" });

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
