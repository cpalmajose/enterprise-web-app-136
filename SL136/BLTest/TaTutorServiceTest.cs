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
            var taTutorService = new TaTutorService(mockRepository.Object);

            //// Act
            taTutorService.InsertTaTutor(null, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = string.Empty };

            //// Act
			taTutorService.InsertTaTutor(taTutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void InsertTaTutorSuccess()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            taTutorService.InsertTaTutor(taTutor, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = "A012_3456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            taTutorService.InsertTaTutor(taTutor, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = "A0123456", FirstName = "J4ne", LastName = "Doe" };

            //// Act
            taTutorService.InsertTaTutor(taTutor, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "D0e" };

            //// Act
            taTutorService.InsertTaTutor(taTutor, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);

            //// Act
            taTutorService.DeleteTaTutor(null, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteTaTutorSuccess()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = "A0123456", FirstName = "Jane", LastName = "Doe" };

            //// Act
            taTutorService.InsertTaTutor(taTutor, ref errors);

            //// Assert
            Assert.AreEqual(0, errors.Count);
        }
		
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateTaTutorErrorTest()
        {
            //// Arrange
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var taTutorService = new TaTutorService(mockRepository.Object);

            //// Act
            taTutorService.UpdateTaTutor(null, ref errors);

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
            var taTutorService = new TaTutorService(mockRepository.Object);
            var taTutor = new TaTutor { TaTutorId = string.Empty };

            //// Act
			taTutorService.UpdateTaTutor(taTutor, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }
		
        /*[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetTutorbyCourseScheduleErrorTest()
        {
            //// Arranage
            var errors = new List<string>();
            var mockRepository = new Mock<ITaTutorRepository>();
            var taTutorService = new TaTutorService(mockRepository.Object);
            mockRepository.Setup(x => x.GetCourseList(ref errors)).Returns(new List<Course>());
            var taTutor = new TaTutor { TaTutorId = string.Empty };

            //// Act
			taTutorService.GetTutorListByCourseSchedule(test_course_schedule_id, ref errors);

            //// Assert
            Assert.AreEqual(1, errors.Count);
        }*/
	}
}

