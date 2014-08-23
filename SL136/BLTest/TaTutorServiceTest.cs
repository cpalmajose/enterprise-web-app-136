namespace ServiceTest
{
    using System;
    using System.Collections.Generic;

    using IRepository;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using POCO;
    using Service;

    [TestClass]
    public class TaTutorServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);

            //// Act
            tatutorService.InsertTaTutor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaTutorErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = string.Empty };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTaTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();

            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);

            //// Act
            tatutorService.DeleteTaTutor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTaTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);

            //// Act
            tatutorService.UpdateTaTutor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTaTutorErrorTest2()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = string.Empty };

            //// Act
            tatutorService.UpdateTaTutor(tatutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
    }
}