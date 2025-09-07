
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Properties.Infrastructure.EF.Entities
{
    [Table("PropertyTraces", Schema = "properties")]
    public class PropertyTrace
    {
        [Key]
        [Column("phtId")]
        public int Id { get; set; }

        [Required]
        [Column("phtDateSale")]
        public DateTime DateSale { get; set; }

        [Required]
        [Column("phtName")]
        [MaxLength(400)]
        public string Name { get; set; } = string.Empty;    

        [Required]
        [Column("phtValue")]
        [Precision(18, 2)]
        public decimal Value { get; set; }

        [Required]
        [Column("ptrTax")]
        [Precision(18, 2)]
        public decimal Tax { get; set; }

        [Required]
        [Column("ptrPropertyId")]
        public int PropertyId { get; set; }

        [Required]
        [Column("ptrRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("ptrState")]
        public int State { get; set; }               
    }
}
