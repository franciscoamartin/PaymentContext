using Flunt.Validations;
using PaymentContext.Shared.Value_Objects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : Value_Object
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres.")
            .HasMinLen(Number, 2, "Address.Number", "O número deve conter pelo menos 2 caracteres.")
            .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter pelo menos 3 caracteres.")
            .HasMinLen(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres.")
            .HasMinLen(State, 3, "Address.State", "O estado deve conter pelo menos 3 caracteres.")
            .HasMinLen(Country, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres.")
            .HasMinLen(zipCode, 5, "Address.zipCode", "O código postal deve conter pelo menos 5 caracteres.")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}