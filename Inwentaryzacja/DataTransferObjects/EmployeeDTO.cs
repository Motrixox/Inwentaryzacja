using System.ComponentModel.DataAnnotations;

namespace Inwentaryzacja.DataTransferObjects
{
    public class EmployeeDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
