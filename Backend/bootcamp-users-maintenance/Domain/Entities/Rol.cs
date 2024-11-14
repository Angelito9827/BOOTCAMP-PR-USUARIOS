using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bootcamp_users_maintenance.Domain.Entities
{
    [Table("roles")]
    public class Rol
    {
        public long Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Timestamp] public byte[] RolTimestamp { get; set; }
    }
}
