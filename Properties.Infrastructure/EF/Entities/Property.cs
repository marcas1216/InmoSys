
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("Properties", Schema = "properties")]
    public class Property
    {
        [Key]
        [Column("pId")]
        public int Id { get; set; }

        [Required]
        [Column("pName")]
        [MaxLength(400)]
        public string Name { get; set; }

        [Required]
        [Column("pAddress")]
        [MaxLength(600)]
        public string Address { get; set; }

        [Required]
        [Column("pPrice")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Column("pCodeInternal")]
        [MaxLength(160)]
        public string CodeInternal { get; set; }

        [Column("pYear")]
        public int? Year { get; set; }

        [Required]
        [Column("pOwnerId")]
        public int OwnerId { get; set; }

        [Required]
        [Column("pPropertyTypeId")]
        public int PropertyTypeId { get; set; }

        [Required]
        [Column("pPropertyStateId")]
        public int PropertyStateId { get; set; }

        [Column("pRegisterDate")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? RegisterDate { get; set; }

        [Required]
        [Column("pState")]
        public int State { get; set; }               
    }
}
