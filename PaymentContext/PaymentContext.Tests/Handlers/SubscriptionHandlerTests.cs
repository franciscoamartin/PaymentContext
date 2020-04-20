using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Francisco";
            command.LastName = "Martin";
            command.Document = "12345678900";
            command.Email = "teste@email.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "1234567";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;   
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "FM";
            command.PayerDocument = "12345678900";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@email.com";
            command.Street = "rua";
            command.Number = "123";
            command.Neighborhood = "centro";
            command.City = "cidade";
            command.State = "estado";
            command.Country = "país";
            command.ZipCode = "1234567";

            handler.Handler(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
