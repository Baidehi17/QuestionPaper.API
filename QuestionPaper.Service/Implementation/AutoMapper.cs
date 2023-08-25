using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool.BLL.Implementation
{
    public static class AutoMapper<TSource, TDestination>
    {
        public static Mapper mapper = new Mapper(new MapperConfiguration(
            options => options.CreateMap<TSource, TDestination>()
            ));

        //private static IMapper mapper;
        //static AutoMapper()
        //{
        //    var configuration = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<TSource, TDestination>();
        //    });
        //    mapper = configuration.CreateMapper();
        //}
        public static TDestination Map(TSource source)
        {
            return mapper.Map<TDestination>(source);
        }
        public static IEnumerable<TDestination> Map(IEnumerable<TSource> source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }



    }
}
