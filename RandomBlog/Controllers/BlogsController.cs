namespace RandomBlog.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using RandomBlog.Application.Features.Blogs.Commands.CreateBlog;
    using RandomBlog.Shared;

    public class BlogsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateBlogCommand command) => await _mediator.Send(command);
    }
}
