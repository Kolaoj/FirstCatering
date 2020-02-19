using AutoMapper;

namespace FirstCatering.API.Contexts.Profiles
{
    public class EmployeeDataProfile: Profile
    {
        public EmployeeDataProfile()
        {
            CreateMap<Entities.EmployeeData, Models.EmployeeDataDto>();
            CreateMap<Models.EmployeeDataForBalanceChangeDto, Entities.EmployeeData>().ReverseMap();
        }
    }
}
