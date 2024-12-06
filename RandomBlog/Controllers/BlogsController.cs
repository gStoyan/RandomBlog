namespace RandomBlog.WebAPI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using RandomBlog.Application.Features.Blogs.Commands.CreateBlog;
    using RandomBlog.Application.Features.Blogs.Commands.DeleteBlog;
    using RandomBlog.Application.Features.Blogs.Commands.Queries.GetAllBlogs;
    using RandomBlog.Shared;

    public class BlogsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllBlogsDto>>>> GetAll([FromQuery] GetAllBlogsRequest command) => await _mediator.Send(command);

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreateBlogRequest command) => await _mediator.Send(command);


        [HttpDelete]
        public async Task<ActionResult<Result<int>>> Delete(DeleteBlogRequest command) => await _mediator.Send(command);
    }
}
