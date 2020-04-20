using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Name _name;
         private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Subscription _subscription;

        public StudentTests()
        {
             _name = new Name("Francisco", "Martin");
            _document = new Document("12345678900", EDocumentType.CPF);
            _email = new Email("franciscoaugustomartin@gmail.com");
            _student = new Student(_name,_document, _email);
            _address = new Address("Rua", "123", "Centro", "Cidade","Estado","Pais", "0012345");
            _subscription = new Subscription(null);
           
        }
        [TestMethod]
        public void ShouldReturnErrorWhenActiveSubscription()
        {
            var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "FM", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PaypalPayment("123456", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "FM", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }
    }
}
