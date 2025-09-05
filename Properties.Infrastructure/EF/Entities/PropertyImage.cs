
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("PropertyImages", Schema = "properties")]
    public class PropertyImage
    {
        [Key]
        [Column("pild")]
        public int Id { get; set; }

        [Required]
        [Column("pPropertyId")]
        public int PropertyId { get; set; }

        [Required]
        [Column("pFile")]
        [MaxLength(1000)]
        public string File { get; set; }

        [Required]
        [Column("pEnabled")]
        public bool Enabled { get; set; }

        [Required]
        [Column("pRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("pState")]
        public int State { get; set; }

        // Navigation property
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
    }

}
