using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.DataTransferObjects
{
    public class IssuedDeviceDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid DeviceId { get; set; }
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public string? Notes { get; set; }
        public string? Place { get; set; }
    }
}
