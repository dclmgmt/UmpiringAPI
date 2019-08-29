using AutoMapper;
using UmpiringApi.Dtos;
using UmpiringApi.Models;

namespace UmpiringApi.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            DisableConstructorMapping();
            CreateMap<TblBook, BookListDto>();
            CreateMap<LoginDto, TblUser>();
            CreateMap<RegisterDto, TblUser>();
        }
    }
}