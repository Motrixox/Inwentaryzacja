using AutoMapper;
using Inwentaryzacja.DataTransferObjects;
using Inwentaryzacja.Models;

namespace Inwentaryzacja.MapperProfiles
{
    public class IssuedDeviceProfile : Profile
    {
        public IssuedDeviceProfile()
        {
            CreateMap<IssuedDeviceDTO, IssuedDevice>().ForMember(dest => dest.Device, opt => opt.Ignore())
                                                      .ForMember(dest => dest.Employee, opt => opt.Ignore());
        }
    }
}
