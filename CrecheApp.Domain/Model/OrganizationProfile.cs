using AutoMapper;
using CrecheApp.Domain.Dto;
using CrecheApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrecheApp.Domain.Model
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Account, AccountDTO>();
        }
    }
}
