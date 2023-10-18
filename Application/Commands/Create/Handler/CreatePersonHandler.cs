using Application.Commands.Create.Requests;
using Application.Commands.Create.Responses;
using Domain.Models;
using Infra.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Create.Handler
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResponse>
    {
        private readonly PeopleRegistryDBContext _dBContext;

        public CreatePersonHandler(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<CreatePersonResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var newPerson = new Person(request.Name, request.Email);
            await _dBContext.AddAsync(newPerson, cancellationToken);
            await _dBContext.SaveChangesAsync(cancellationToken);
            return null;
        }
    }
}