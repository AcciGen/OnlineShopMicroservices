using MediatR;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Commands
{
    public class DeleteUserCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
    }
}
