using AutoMapper;

namespace Core.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DAL.Models.StaffAccount, DTO.PersonAccount>();
        }
    }
}
