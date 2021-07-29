using AutoMapper;
using Domain;
using Domain.Models;
using Framework.Interfaces;
using Framework.Models;
using Framework.Services;
using Microsoft.Extensions.Configuration;
using Stripe;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.UserRepo
{
    public class UserBO: IBusinessObject
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly StripeDbContext context;

        public UserBO(StripeDbContext context, IConfiguration configuration, IMapper mapper)
        {
            this.context = context;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<string> StripeClientSecretAsync()
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            var stripeCustomerId = context.User.Where(q => q.Id == 1).Select(s => s.StripeCustomerId).FirstOrDefault();
            var options = new SetupIntentCreateOptions
            {
                Customer = stripeCustomerId,
            };
            var service = new SetupIntentService();
            var intent = await service.CreateAsync(options);
            return intent.ClientSecret;
        }

        public async Task AddPaymentMethodAsync(string paymentMethodId)
        {
            var user = context.User.Where(q => q.Id == 1).Select(s => new User
            {
                Id = s.Id,
            }).FirstOrDefault();
            context.Attach(user);
            user.StripePaymentMethodId = paymentMethodId;
            await context.SaveChangesAsync();
        }

        public async Task ChargeUserAsync(long amount)
        {
            var user = context.User.Where(q => q.Id == 1).Select(s => new User
            {
                Id = s.Id,
                StripeCustomerId = s.StripeCustomerId,
                StripePaymentMethodId = s.StripePaymentMethodId
            }).FirstOrDefault();
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            var service = new PaymentIntentService();
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount*100,
                Currency = "usd",
                Customer = user.StripeCustomerId,
                PaymentMethod = user.StripePaymentMethodId,
                Confirm = true,
                OffSession = true,
            };
            var paymentResponse = await service.CreateAsync(options);
        }


        public async Task SignupAsync(User user)
        {
            user.PasswordResetToken = PasswordResetToken.Generate(configuration["Password:EncryptionKey"]);
            user.StripeCustomerId = await CreateStripeCustomerAsync(user.Name, user.Email);
            user.Password = HashingService.CreateHash(user.Password);
            user.HasValidatedEmail = false;
            user.HasValidPayment = false;
            context.User.Add(user);
            await context.SaveChangesAsync();
        }

        private async Task<string> CreateStripeCustomerAsync(string name, string email)
        {
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            var customerCreateOptions = new CustomerCreateOptions
            { Name = name, Email = email };
            var customer = await new CustomerService().CreateAsync(customerCreateOptions);
            return customer.Id;
        }
    }
}
