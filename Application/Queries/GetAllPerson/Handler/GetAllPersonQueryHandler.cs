using Domain.Models;
using Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries.GetAllPerson.Handler
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<Person>>
    {
        private readonly PeopleRegistryDBContext _dBContext;

        public GetAllPersonQueryHandler(PeopleRegistryDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<Person>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            return await _dBContext.Person.ToListAsync();
        }
    }
}