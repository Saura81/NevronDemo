using AutoMapper;
using NevronDemo.Application.Common.Mappings;
using NevronDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.Numbers.Queries.GetNumbersList
{
    public class NumberDTO : IMapFrom
    {
        public int Id { get; set; }
        public long Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Number, NumberDTO>();
        }
    }
}
