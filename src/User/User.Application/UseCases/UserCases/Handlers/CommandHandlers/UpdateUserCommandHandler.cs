using MediatR;
using Microsoft.EntityFrameworkCore;
using User.Application.Abstractions;
using User.Application.UseCases.UserCases.Commands;
using User.Domain.Entities;

namespace User.Application.UseCases.UserCases.Handlers.CommandHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseModel>
    {
        private readonly IUserDbContext _context;

        public UpdateUserCommandHandler(IUserDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user != null)
            {
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Username = request.Username;
                user.Email = request.Email;
                user.Password = request.Password;
                user.PhoneNumber = request.PhoneNumber;

                _context.Users.Update(user);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{user.Username} => User Updated",
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
