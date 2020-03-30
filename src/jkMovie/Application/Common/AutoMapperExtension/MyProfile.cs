using AutoMapper;
using jkMovie.Application.Common.Dtos;
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
                object INSTANCE = null;
                MethodInfo METHODINFO = null;

                if (item.IsGenericType)
                {
                    var t = item.MakeGenericType(typeof(MovieDto));
                    INSTANCE = Activator.CreateInstance(t);
                    METHODINFO = t.GetMethod("Mapping", BindingFlags.NonPublic | BindingFlags.Instance);
                    METHODINFO?.Invoke(INSTANCE, new object[] { this });
                }
                else
                {
                    INSTANCE = Activator.CreateInstance(item);
                    METHODINFO = item.GetMethod("Mapping", BindingFlags.NonPublic | BindingFlags.Instance);
                    METHODINFO?.Invoke(INSTANCE, new object[] { this });
                }
            }
        }
    }
}