using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Infrastructure.EF.Entities
{
    [Table("Logs", Schema = "tracking")]
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("lid")]
        public int Id { get; set; }

        [Required]
        [Column("lUserId")]
        public int UserId { get; set; }

        [Required]
        [Column("lMethod")]
        [MaxLength(200)]
        public string? Method { get; set; }

        [Column("lRequest")]
        public string? Request { get; set; }

        [Column("lResponse")]
        public string? Response { get; set; }

        [Required]
        [Column("lRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("lState")]
        public int State { get; set; }
    }
}
