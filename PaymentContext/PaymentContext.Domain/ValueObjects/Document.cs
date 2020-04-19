using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Value_Objects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : Value_Object
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}