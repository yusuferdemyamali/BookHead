using System.ComponentModel.DataAnnotations;

namespace BookHead.Models;

public class AdminUser
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Kullanici { get; set; }
    public string Sifre { get; set; }
}