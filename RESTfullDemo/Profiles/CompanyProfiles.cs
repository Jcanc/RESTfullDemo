using AutoMapper;
using RESTfullDemo.Entities;
using RESTfullDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullDemo.Profiles
{
    public class CompanyProfiles : Profile
    {
        public CompanyProfiles()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyAddDto, Company>();
            CreateMap<CompanyEditDto, Company>();
            CreateMap<Company, CompanyEditDto>();
        }
    }
}
