using Inwentaryzacja.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inwentaryzacja.Models
{
    //Model of a device stored in database
    public class Device : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string SerialNumber { get; set; }
        public string? Description { get; set; }

        [ForeignKey("DeviceType")]
        public Guid DeviceTypeId { get; set; }
        public virtual DeviceType? DeviceType { get; set; }

        [ForeignKey("Employee")]
        public Guid? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<IssuedDevice>? Issues { get; set; }
        
        public bool IsConfirmed { get; set; }
        public Status Status { get; set; } = (Status) 1;
        public string? Place { get; set; }
    }

    public enum Status
    {
        Niewydany = 1,
        Wydany = 2,
        Wyłączony = 3
    }
}
