using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.DataTransferObjects
{
    public class DeviceTypeDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
