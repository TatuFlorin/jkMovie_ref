using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace jkMovie.Application.Common.AutoMapperExtension
{
    public class IMapFrom<T>
        where T : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}