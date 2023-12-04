using Inwentaryzacja.Models;
using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.DataTransferObjects
{
    public class DeviceDTO
    {
        public Guid? Id { get; set; }
        public string? Code { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public string? Description { get; set; }
        [Required]
        public Guid DeviceTypeId { get; set; }
        public Guid? EmployeeId { get; set; }
        [Required]
        public Status Status { get; set; }
        public string? Place { get; set; }
    }
}
