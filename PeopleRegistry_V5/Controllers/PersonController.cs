using Application.Commands.Create.Requests;
using Application.Commands.Create.Responses;
using Application.Commands.Delete.Requests;
using Application.Commands.Delete.Responses;
using Application.Commands.Update.Requests;
using Application.Commands.Update.Responses;
using Application.Queries.GetAllPeople;
using Application.Queries.GetAllPerson;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleRegistry_V5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {   
        [HttpGet]
        public async Task<List<Person>> GetAllPerson([FromServices] IMediator mediator)
        {
            return await mediator.Send(new GetAllPersonQuery());
            //return Ok(await mediator.Send(new GetAllPersonQuery()));
        }

        [HttpGet("{id}")]
        public async Task<Person> GetPersonById([FromServices] IMediator mediator, [FromRoute] int id)
        {
            return await mediator.Send(new GetPersonByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<CreatePersonResponse> Create([FromServices] IMediator mediator, [FromBody] CreatePersonRequest command)
        {
            return await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete([FromServices] IMediator mediator, [FromRoute] int id)
        {
            return await mediator.Send(new DeletePersonRequest { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<UpdatePersonResponse> Update([FromServices] IMediator mediator, UpdatePersonRequest command)
        {
            return await mediator.Send(command);
        }
    }
}