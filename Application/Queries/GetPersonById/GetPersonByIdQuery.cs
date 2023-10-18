using Domain.Models;
using MediatR;

namespace Application.Queries.GetAllPeople
{
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }
    }
}