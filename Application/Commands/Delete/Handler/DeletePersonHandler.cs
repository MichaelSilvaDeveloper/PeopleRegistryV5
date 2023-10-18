using Application.Commands.Delete.Requests;
using Application.Commands.Delete.Responses;
using Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Delete.Handler
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
    {
        private readonly PeopleRegistryDBContext _dBContext;

        public DeletePersonHandler(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dBContext.Person.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (getPersonById == null)
                throw new Exception($"Pessoa para o id: {request.Id} não foi encontrado");
            _dBContext.Remove(getPersonById);
            await _dBContext.SaveChangesAsync(cancellationToken);

            return null;
        }
    }
}