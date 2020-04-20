using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for(var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()), 
                    new Document("00012344670" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@email.com")
                ));
            }
        }

        [TestMethod]
        public void ShouldReturnNullDocumentNotExists()
        {
          var exp = StudentQueries.GetStudentInfo("12345678910");
          var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

          Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentwhenDocumentExists()
        {
          var exp = StudentQueries.GetStudentInfo("1111111111111");
          var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

          Assert.AreEqual(null, studn);
        }
    }
}
