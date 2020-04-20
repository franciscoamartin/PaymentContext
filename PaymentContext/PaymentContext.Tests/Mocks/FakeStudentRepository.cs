using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExist(string document)
        {
            if(document == "12345678900")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if(email == "teste@email.com")
                return true;

            return false;
        }
    }
}