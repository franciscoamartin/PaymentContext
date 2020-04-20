using Flunt.Validations;
using PaymentContext.Shared.Value_Objects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : Value_Object
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
            .Requires()
            .IsEmail(Address, "Email.Address", "Email inválido.")
            );
        }
        public string Address { get; private set; }
    }
}