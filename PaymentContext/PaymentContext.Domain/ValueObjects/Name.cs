using PaymentContext.Shared.Value_Objects;
namespace PaymentContext.Domain.ValueObjects
{
    public class Name : Value_Object
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}