namespace RandomBlog.Application.Features.Blogs.Commands.Queries.GetAllBlogs
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Threading;
    using System.Threading.Tasks;


    internal class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsRequest, Result<List<GetAllBlogsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllBlogsDto>>> Handle(GetAllBlogsRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _unitOfWork.Repository<Blog>().Entities
                .ProjectTo<GetAllBlogsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllBlogsDto>>.SuccessAsync(blogs);
        }
    }
}
