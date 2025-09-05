
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("PropertyStates", Schema = "properties")]
    public class PropertyState
    {
        [Key]
        [Column("pstId")]
        public int Id { get; set; }

        [Required]
        [Column("pstName")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [Column("pstRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("pstState")]
        public int State { get; set; }
        
    }
}
