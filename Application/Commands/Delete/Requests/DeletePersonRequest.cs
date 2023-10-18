using Application.Commands.Delete.Responses;
using MediatR;

namespace Application.Commands.Delete.Requests
{
    public class DeletePersonRequest : IRequest<DeletePersonResponse>
    {
        public int Id { get; set; }
    }
}