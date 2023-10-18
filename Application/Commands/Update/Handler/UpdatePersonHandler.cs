using Application.Commands.Update.Requests;
using Application.Commands.Update.Responses;
using Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Update.Handler
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
    {
        private readonly PeopleRegistryDBContext _dBContext;

        public UpdatePersonHandler(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dBContext.Person.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (getPersonById == null)
                throw new Exception($"Pessoa para o id: {request.Id} não foi encontrado");
            getPersonById.Name = request.Name;
            getPersonById.Email = request.Email;
            _dBContext.Update(getPersonById);
            await _dBContext.SaveChangesAsync(cancellationToken);
            return null;
        }
    }
}