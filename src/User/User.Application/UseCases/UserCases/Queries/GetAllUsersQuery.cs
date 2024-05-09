using MediatR;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserInfo>>
    {
    }
}
