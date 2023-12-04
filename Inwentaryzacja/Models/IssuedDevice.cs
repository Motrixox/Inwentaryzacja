using Inwentaryzacja.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inwentaryzacja.Models
{
    public class IssuedDevice : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Device")]
        public Guid DeviceId { get; set; }
        public virtual Device? Device { get; set; }

        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime? DateOfReturn { get; set; }
        public string? Notes { get; set; }
    }
}
