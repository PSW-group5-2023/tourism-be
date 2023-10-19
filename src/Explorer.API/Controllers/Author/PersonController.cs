using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/person")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> GetAuthorsAndTourists()
        {
            var result = _personService.GetAuthorsAndTourists();
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PersonDto> Get(int id)
        {
            var result = _personService.Get(id);
            return CreateResponse(result);
        }

        [HttpPut]
        public ActionResult<PersonDto> Update([FromBody] PersonDto person)
        {
            var result = _personService.Update(person);
            return CreateResponse(result);
        }
    }
}
