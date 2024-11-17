using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bootcamp_caso_practico_backend.Domain.Entities
{
    [Table("roles")]
    public class Role
    {
        public long Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public required string Name { get; set; }
    }
}
