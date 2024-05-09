using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Application.Abstractions;
using User.Application.UseCases.UserCases.Queries;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Handlers.QueryHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserInfo>>
    {
        private readonly IUserDbContext _context;

        public GetAllUsersQueryHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserInfo>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
