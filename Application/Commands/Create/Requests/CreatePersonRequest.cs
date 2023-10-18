using Application.Commands.Create.Responses;
using MediatR;

namespace Application.Commands.Create.Requests
{
    public class CreatePersonRequest : IRequest<CreatePersonResponse>
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}