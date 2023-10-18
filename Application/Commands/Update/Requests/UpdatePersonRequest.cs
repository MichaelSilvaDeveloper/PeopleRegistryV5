using Application.Commands.Update.Responses;
using MediatR;

namespace Application.Commands.Update.Requests
{
    public class UpdatePersonRequest : IRequest<UpdatePersonResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
