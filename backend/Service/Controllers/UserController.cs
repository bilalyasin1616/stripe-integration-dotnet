using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Framework.Controllers;
using Framework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.UserRepo;
using System.Threading.Tasks;

namespace Service.Controllers
{
    public class UserController : AuthorizedController
    {
        private readonly UserBO userBO;
        private readonly IMapper mapper;

        public UserController(UserBO userBO, IMapper mapper)
        {
            this.userBO = userBO;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ResponseBase>> GetStripeClientSecretAsync()
        {
            return ResponseModel<string>.GetSuccess("Returning stripe client secret for current user", await userBO.StripeClientSecretAsync());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ResponseBase>> AddPaymentMethodAsync(string paymentMethodId)
        {
            await userBO.AddPaymentMethodAsync(paymentMethodId);
            return ResponseBase.GetSuccess("Added payment method.");
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult<ResponseBase>> ChargeUserAsync(long amount)
        {
            await userBO.ChargeUserAsync(amount);
            return ResponseBase.GetSuccess("User charged successfully");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ResponseBase>> RegisterAsync(UserDTO userDTO)
        {
            await userBO.SignupAsync(mapper.Map<User>(userDTO));
            return ResponseBase.GetSuccess("You have been registered.");
        }
    }
}
