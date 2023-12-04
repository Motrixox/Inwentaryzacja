using Inwentaryzacja.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.Models
{
    //Model of an employee stored in database
    public class Employee : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public virtual ICollection<Device>? Devices { get; set; }
    }
}
