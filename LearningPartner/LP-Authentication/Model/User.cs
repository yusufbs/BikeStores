using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LP_Authentication.Model;

[Table("users")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    public required string EmailId { get; set; }

    [Required]
    public required string Password { get; set; }

    public DateTime CreatedDate { get; set; }

    [Required]
    public required string FullName { get; set; }

    [Required]
    public required string MobileNo { get; set; }
}
