using PaymentContext.Shared.Value_Objects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : Value_Object
    {
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; private set; }
    }
}