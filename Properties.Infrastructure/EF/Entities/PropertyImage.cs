
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("PropertyImages", Schema = "properties")]
    public class PropertyImage
    {
        [Key]
        [Column("piId")]
        public int Id { get; set; }

        [Required]
        [Column("piPropertyId")]
        public int PropertyId { get; set; }

        [Required]
        [Column("piFile")]
        [MaxLength(1000)]
        public string File { get; set; } = string.Empty;    

        [Required]
        [Column("piEnabled")]
        public bool Enabled { get; set; }

        [Required]
        [Column("piRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("piState")]
        public int State { get; set; }
        
    }
}
