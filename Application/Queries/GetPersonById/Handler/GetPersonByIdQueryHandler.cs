using Domain.Models;
using Infra.Context;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetAllPeople.Handler
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly PeopleRegistryDBContext _dBContext;

        public GetPersonByIdQueryHandler(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var getPersonById = await _dBContext.Person.FindAsync(request.Id);
            if (getPersonById == null)
                throw new Exception($"Pessoa para o id: {request.Id} não foi encontrado");
            return getPersonById;
        }
    }
}