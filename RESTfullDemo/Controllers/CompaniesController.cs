using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RESTfullDemo.Entities;
using RESTfullDemo.Models;
using RESTfullDemo.Services;

namespace RESTfullDemo.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [ResponseCache(CacheProfileName = "120sCacheProfile")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name =nameof(GetCompanies))]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies([FromQuery]DtoParameters dtoParameter)
        {
            var companies = await _companyRepository.GetCompaniesAsync(dtoParameter);

            var previousLink = companies.HasPrevious ? CreateCompaniesResourceUri(dtoParameter, ResourceUriType.PreviousPage) : null;

            var nextLink = companies.HasNext ? CreateCompaniesResourceUri(dtoParameter, ResourceUriType.NextPage) : null;

            var paginationMetadata = new
            {
                totalCount = companies.TotalCount,
                pageSize = companies.PageSize,
                currentPage = companies.CurrentPage,
                totalPages = companies.TotalPages,
                previousLink,
                nextLink
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata,
                new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                }));

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            if (companiesDto == null)
            {
                return NoContent();
            }

            return Ok(companiesDto);
        }

        [HttpGet("{companyId}", Name = nameof(GetCompany))]
        [ResponseCache(Duration = 60)]
        public async Task<ActionResult<CompanyDto>> GetCompany(Guid companyId)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId);
            if (company == null)
            {
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyDto>(company);

            return Ok(companyDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany(CompanyAddDto company)
        {
            var entity = _mapper.Map<Company>(company);
            _companyRepository.AddCompany(entity);
            await _companyRepository.SaveAsync();
            var dtoToReturn = _mapper.Map<CompanyDto>(entity);
            return CreatedAtRoute(nameof(GetCompany), new { companyId = dtoToReturn.Id }, dtoToReturn);
        }

        [HttpPut("{companyId}")]
        public async Task<ActionResult> UpdateCompany(Guid companyId, CompanyEditDto company)
        {
            var entity = await _companyRepository.GetCompanyAsync(companyId);
            if (entity != null)
            {
                _mapper.Map(company, entity);
                _companyRepository.UpdateCompany(entity);
                await _companyRepository.SaveAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        /// <remarks>
        /// 可更新的字段：
        ///     {IsEnable, IsDelete}
        /// 请求参数说明：
        /// [
        ///     {
        ///	        "value": {}, //此值可为字符串、数字等类型
        ///         "path": "", //更新的字段
        ///	        "op": "", //操作[replace(替换),remove(删除),add(替换),move(移动),copy(复制),test(测试)]
        ///	        "from": "" //目标字段，操作移动及复制时需要
        ///     }
        /// ]
        /// 请求示例：
        ///     添加：{"op": "add", "path": "xxx", "value": "xxx"}，如果该属性不存，那么就添加该属性，如果属性存在，就改变属性的值。这个对静态类型不适用。
        ///     删除：{"op": "remove", "path": "xxx"}，删除某个属性，或把它设为默认值（例如空值）。
        ///     替换：{"op": "replace", "path": "/xxx", "value": "xxx"}，改变属性的值，也可以理解为先执行了删除，然后进行添加。
        ///     复制：{"op": "copy", "from": "xxx", "path": "yyy"}，把某个属性的值赋给目标属性。
        ///     移动：{"op": "move", "from": "xxx", "path": "yyy"}，把源属性的值赋值给目标属性，并把源属性删除或设成默认值。
        ///     测试：{"op": "test", "path": "xxx", "value": "xxx"}，测试目标属性的值和指定的值是一样的。
        /// </remarks>
        [HttpPatch("{companyId}")]
        public async Task<IActionResult> PartUpdateCompany(Guid companyId, JsonPatchDocument<CompanyEditDto> patchDocument)
        {
            var entity = await _companyRepository.GetCompanyAsync(companyId);
            if (entity != null)
            {
                var dtoToPatch = _mapper.Map<CompanyEditDto>(entity);

                // 需要处理验证错误
                patchDocument.ApplyTo(dtoToPatch, ModelState);
                if (!TryValidateModel(dtoToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(dtoToPatch, entity);
                _companyRepository.UpdateCompany(entity);
                await _companyRepository.SaveAsync();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            var entity = await _companyRepository.GetCompanyAsync(companyId);
            if (entity != null)
            {
                await _companyRepository.GetEmployeesAsync(companyId, null);
                _companyRepository.DeleteCompany(entity);
                await _companyRepository.SaveAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,OPTIONS");
            return Ok();
        }

        private string CreateCompaniesResourceUri(DtoParameters parameters,
            ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(nameof(GetCompanies), new
                    {
                        pageInex = parameters.pageInex - 1,
                        pageSize = parameters.pageSize,
                        search = parameters.search
                    });

                case ResourceUriType.NextPage:
                    return Url.Link(nameof(GetCompanies), new
                    {
                        pageInex = parameters.pageInex + 1,
                        pageSize = parameters.pageSize,
                        search = parameters.search
                    });

                case ResourceUriType.CurrentPage:
                default:
                    return Url.Link(nameof(GetCompanies), new
                    {
                        pageInex = parameters.pageInex,
                        pageSize = parameters.pageSize,
                        search = parameters.search
                    });
            }
        }
    }
}
