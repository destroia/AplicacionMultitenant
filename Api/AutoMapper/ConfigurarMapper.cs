using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.AutoMapper
{
    public static class ConfigurarMapper
    {
        public static IMapper ConfiguraMapper()
        {
            var mapperConfug = new MapperConfiguration(x => {
                x.AddProfile(new MappingProfile());
            });
            return mapperConfug.CreateMapper();
            
        }
    }
}
