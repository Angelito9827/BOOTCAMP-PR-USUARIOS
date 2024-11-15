using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bootcamp_users_maintenance.Domain.Entities
{
    [Table("users")]
    public class User
    {
        public long Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public long RoleId { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
