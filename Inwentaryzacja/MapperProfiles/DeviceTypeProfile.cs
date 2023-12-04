using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Models;

namespace Inwentaryzacja.MapperProfiles
{
    public class DeviceTypeProfile : Profile
    {
        public DeviceTypeProfile() 
        {
            CreateMap<DeviceTypeDTO, DeviceType>().ForMember(dest => dest.Devices, opt => opt.Ignore());
        }
    }
}
