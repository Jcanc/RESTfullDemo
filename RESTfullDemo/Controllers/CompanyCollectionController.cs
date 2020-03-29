using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTfullDemo.Entities;
using RESTfullDemo.Helpers;
using RESTfullDemo.Models;
using RESTfullDemo.Services;

namespace RESTfullDemo.Controllers
{
    [ApiController]
    [Route("api/companycollection")]
    public class CompanyCollectionController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyCollectionController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})", Name =nameof(GetCompanyCollection))]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanyCollection([FromRoute]
            [ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }

            var entities = await _companyRepository.GetCompaniesAsync(ids);

            if (ids.Count() != entities.Count())
            {
                return NotFound();
            }

            var dtosToReturn = _mapper.Map<IEnumerable<CompanyDto>>(entities);

            return Ok(dtosToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> CreateCompanyCollection(IEnumerable<CompanyAddDto> companycollection)
        {
            var entityCollection = _mapper.Map<IEnumerable<Company>>(companycollection);
            foreach(var entity in entityCollection)
            {
                _companyRepository.AddCompany(entity);
            }
            await _companyRepository.SaveAsync();
            var dtosToReturn = _mapper.Map<IEnumerable<CompanyDto>>(entityCollection);
            var ids = string.Join(",", dtosToReturn.Select(d => d.Id));
            return CreatedAtRoute(nameof(GetCompanyCollection), new { ids = ids }, dtosToReturn);
        }

    }
}
