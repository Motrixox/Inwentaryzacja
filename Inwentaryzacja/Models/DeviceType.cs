using Inwentaryzacja.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.Models
{
    //Model of a device type stored in database
    public class DeviceType : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Device>? Devices { get; set; }
    }
}
