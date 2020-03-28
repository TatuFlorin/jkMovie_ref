using AutoMapper;
using jkMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace jkMovie.Application.Common.AutoMapperExtension
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            ApplyMappingForAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingForAssembly(Assembly assembly)
        {

            var types = assembly.GetTypes()
                .Where(x => 
                { var ss = x.BaseType; 
                    return !x.IsAbstract && !x.IsInterface && ss != null 
                    && ss.IsGenericType && ss.GetGenericTypeDefinition() == typeof(IMapFrom<>); 
                }).ToList();

            foreach (var item in types)
            {
                var INSTANCE = Activator.CreateInstance(item);
                var METHODINFO = item.GetMethod("Mapping");
                METHODINFO?.Invoke(INSTANCE, new object[] { this });
            }
        }
    }
}