using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Infrastructure.EF.Entities
{
    [Table("Connections", Schema = "auth")]
    public class Connection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("old")]
        public int Id { get; set; }

        [Required]
        [Column("cServiceName")]
        [MaxLength(200)]
        public string? ServiceName { get; set; }

        [Required]
        [Column("cConnectionString")]
        [MaxLength(1000)]
        public string? ConnectionString { get; set; }

        [Required]
        [Column("cRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("cState")]
        public int State { get; set; }
    }

}
