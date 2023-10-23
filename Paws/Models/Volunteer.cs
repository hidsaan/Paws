using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paws.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Occupation is required.")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [NotMapped] 
        public string HashedPassword { get; set; }
    }
}
