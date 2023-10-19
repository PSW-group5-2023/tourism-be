using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class PersonService : BaseService<PersonDto, Person>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository, IMapper mapper) : base(mapper)
        {
            _personRepository = personRepository;
        }

        public Result<PersonDto> Get(int id)
        {
            return MapToDto(_personRepository.Get(id));
        }

        public Result<List<PersonDto>> GetAuthorsAndTourists()
        {
            return MapToDto(_personRepository.GetAuthorsAndTourists());
        }

        public Result<PersonDto> Update(PersonDto person)
        {
            return MapToDto(_personRepository.Update(MapToDomain(person)));
        }
    }
}
