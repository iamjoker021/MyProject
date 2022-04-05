using AutoMapper;
using MyProject.Models.Dtos;

namespace MyProject.Models.Mapper
{
    public class PensionMapper: Profile
    {
        public PensionMapper()
        {
            CreateMap<PensionerDetail, PensionerDetailDto>().ReverseMap();
        }
    }
}
