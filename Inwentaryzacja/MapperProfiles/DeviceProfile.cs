using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Models;

namespace Inwentaryzacja.MapperProfiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DeviceDTO, Device>().ForMember(dest => dest.DeviceType, opt => opt.Ignore())
                                          .ForMember(dest => dest.Employee, opt => opt.Ignore());
        }
    }
}
