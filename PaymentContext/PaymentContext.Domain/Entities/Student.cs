using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities{
    public class Student
    {
        private IList<Subscription> _subscriptions;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToArray();} }

        public void AddSubscription(Subscription subscription)
        {
            foreach(var sub in Subscriptions)
                sub.Inactivate();
            _subscriptions.Add(subscription);
        }
    }
}