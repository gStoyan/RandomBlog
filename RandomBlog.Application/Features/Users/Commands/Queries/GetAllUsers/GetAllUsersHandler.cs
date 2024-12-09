namespace RandomBlog.Application.Features.Users.Commands.Queries.GetAllUsers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Entities;
    using RandomBlog.Shared;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, Result<List<GetAllUsersDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllUsersDto>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Repository<User>().Entities
                .ProjectTo<GetAllUsersDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllUsersDto>>.SuccessAsync(users, "Users Returned");
        }
    }
}
