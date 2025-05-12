namespace RandomBlog.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RandomBlog.Application.Features.Users.Commands.CreateUser;
    using RandomBlog.Shared;
    using RandomBlog.WebAPI.Models;

    public class UsersController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        public UsersController(IMediator mediator, SignInManager<AppIdentityUser> signInManager, UserManager<AppIdentityUser> userManager)
        {
            _mediator = mediator;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Register(CreateUserRequest request)
        {
            var identityUser = new AppIdentityUser
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                ProfilePicture = request.ProfilePicture,
            };
            await _userManager.CreateAsync(identityUser, request.Password);

            return await _mediator.Send(request);
        }

        //[HttpPost]
        //public async Task<ActionResult<Result<int>>> Login(LoginUserRequest request)
        //{

        //    return null;
        //}
    }
}
