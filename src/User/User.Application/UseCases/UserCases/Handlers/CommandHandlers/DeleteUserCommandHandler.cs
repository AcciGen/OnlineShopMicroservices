using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Application.Abstractions;
using User.Application.UseCases.UserCases.Commands;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseModel>
    {
        private readonly IUserDbContext _context;

        public DeleteUserCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{user.Username} => User Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "User not found",
                StatusCode = 400
            };
        }
    }
}
