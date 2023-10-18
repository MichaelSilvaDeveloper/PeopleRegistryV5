using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.Queries.GetAllPerson
{
    public class GetAllPersonQuery : IRequest<List<Person>>
    {
    }
}