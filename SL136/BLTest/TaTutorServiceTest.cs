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
        public void InsertTaTutorSuccess()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaTutorBadId()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A012_3456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaTutorBadFirstName()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A0123456", FirstName = "J4ne", LastName = "Doe" };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertTaTutorBadLastName()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "D0e" };

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
        public void DeleteTaTutorSuccess()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);
            tatutorService.DeleteTaTutor(tatutor.TaTutorId, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTaTutorBadId()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            tatutorService.InsertTaTutor(tatutor, ref errors);
            tatutorService.DeleteTaTutor("A01234_56", ref errors);

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

        [TestMethod]
        public void GetTaTutorListTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var tatutorService = new TaTutorService(mockRepository.Object);
            var tatutorList = new List<TaTutor>();
            tatutorList.Add(new TaTutor { TaTutorId = "A0123456", FirstName = "Tony", LastName = "Stark" });
            tatutorList.Add(new TaTutor { TaTutorId = "A0987655", FirstName = "John", LastName = "Smith" });
            mockRepository.Setup(x => x.GetTutorList(ref errors)).Returns(tatutorList);

            //// Act
            var otherList = tatutorService.GetTutorList(ref errors);

            //// Assert
            Assert.AreEqual(tatutorList, otherList);
        }
    }
}