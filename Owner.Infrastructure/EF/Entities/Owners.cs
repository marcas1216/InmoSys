using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Owner.Infrastructure.EF.Entities
{
    [Table("Owners", Schema = "owners")]
    public class Owners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("oId")]
        public int OId { get; set; }

        [Required]
        [StringLength(100)]
        [Column("oFirstName")]
        public string? OFirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Column("oLastName")]
        public string? OLastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("oDocumentType")]
        public string? ODocumentType { get; set; }

        [Required]
        [StringLength(50)]
        [Column("oDocument")]
        public string? ODocument { get; set; }

        [Required]
        [StringLength(150)]
        [Column("oEmail")]
        [EmailAddress]
        public string? OEmail { get; set; }

        [StringLength(200)]
        [Column("oAddress")]
        public string? OAddress { get; set; }

        [StringLength(100)]
        [Column("oCity")]
        public string? OCity { get; set; }

        [StringLength(100)]
        [Column("oState")]
        public string? OState { get; set; }

        [Required]
        [StringLength(100)]
        [Column("oCountry")]
        public string? OCountry { get; set; }

        [Column("oPhoto", TypeName = "nvarchar(MAX)")]
        public string? OPhoto { get; set; }

        [Column("oBirthDate", TypeName = "date")]
        public DateTime? OBirthDate { get; set; }

        [StringLength(20)]
        [Column("oPhone")]
        public string? OPhone { get; set; }

        [Required]
        [Column("oRegisterDate")]
        public DateTime ORegisterDate { get; set; }

        [Required]
        [Column("oStateRegister")]
        public int OStateRegister { get; set; }
    }
}
