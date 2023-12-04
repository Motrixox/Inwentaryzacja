using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Models;

namespace Inwentaryzacja.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Employee>().ForMember(dest => dest.Devices, opt => opt.Ignore());
        }
    }
}
