using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Infrastructure.EF.Entities
{
    [Table("KeyVaults", Schema = "auth")]
    public class KeyVault
    {
        [Key]
        [Column("kvId")]
        public int Id { get; set; }

        [Required]
        [Column("kvName")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("kvValue")]
        public string Value { get; set; } = string.Empty;

        [Required]
        [Column("kvModule")]
        [MaxLength(100)]
        public string Module { get; set; } = string.Empty;

        [Column("kvRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("kvState")]
        public int State { get; set; }
    }
}
