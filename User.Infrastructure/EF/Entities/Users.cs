using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Infrastructure.EF.Entities
{
    [Table("Users", Schema = "auth")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("old")]
        public int Id { get; set; }

        [Required]
        [Column("uEmail")]
        [MaxLength(300)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Column("uPassword")]
        [MaxLength(400)]
        public string? Password { get; set; }

        [Required]
        [Column("uRegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Required]
        [Column("uState")]
        public int State { get; set; }
    }

}
