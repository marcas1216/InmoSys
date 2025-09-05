
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("PropertyTypes", Schema = "properties")]
    public class PropertyType
    {
        [Key]
        [Column("ptyId")]
        public int Id { get; set; }

        [Required]
        [Column("ptyName")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Column("ptyDescription")]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column("ptyRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("ptyState")]
        public int State { get; set; }
       
    }
}

