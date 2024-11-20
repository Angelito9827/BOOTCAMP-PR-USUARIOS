using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bootcamp_caso_practico_backend.Domain.Entities
{
    [Table("users")]
    public class User
    {
        public long Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public required string LastName { get; set; }
        [MaxLength(50)]
        [MinLength(5)]
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
        [Required]
        public long RoleId { get; set; }
        [Required]
        public Role Role { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
