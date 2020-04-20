using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
    IHandler<CreateBoletoSubscriptionCommand>,
    IHandler<CreatePayPalSubscriptionCommand>,
    IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handler(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if(command.Invalid)
            {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar o seu cadastro.");
            }

            if(_repository.DocumentExist(command.Document))
            AddNotification("Document", "Este CPF já está em uso.");

            if(_repository.DocumentExist(command.Email))
            AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City,command.State, command.Country, command.ZipCode);
            
            var student = new Student(name,document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
            );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if(Invalid)
            return new CommandResult(false, "Não foi possível realizar a sua assinatura.");

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.ToString(), "Bem vindo ao Site", "Sua Assinatura foi criada.");

         return new CommandResult(true, "Assinatura realizada com sucesso.");
        }

        public ICommandResult Handler(CreatePayPalSubscriptionCommand command)
        {
            if(_repository.DocumentExist(command.Document))
            AddNotification("Document", "Este CPF já está em uso.");

            if(_repository.DocumentExist(command.Email))
            AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City,command.State, command.Country, command.ZipCode);
            
            var student = new Student(name,document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PaypalPayment(
            command.TransactionCode,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
            );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if(Invalid)
            return new CommandResult(false, "Não foi possível realizar a sua assinatura.");

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.ToString(), "Bem vindo ao Site", "Sua Assinatura foi criada.");

         return new CommandResult(true, "Assinatura realizada com sucesso.");
        }

        public ICommandResult Handler(CreateCreditCardSubscriptionCommand command)
        {
            if(_repository.DocumentExist(command.Document))
            AddNotification("Document", "Este CPF já está em uso.");

            if(_repository.DocumentExist(command.Email))
            AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City,command.State, command.Country, command.ZipCode);
            
            var student = new Student(name,document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
            command.CardHolderName,
            command.CardNumber,
            command.LastTransactionNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
            );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if(Invalid)
            return new CommandResult(false, "Não foi possível realizar a sua assinatura.");
            
            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.ToString(), "Bem vindo ao Site", "Sua Assinatura foi criada.");

         return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}