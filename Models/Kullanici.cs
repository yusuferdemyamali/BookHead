using System.ComponentModel.DataAnnotations;

namespace BookHead.Models;

public class Kullanici
{
    [Key]
    public int KullaniciId { get; set; }
    [Required]
    public string Email { get; set; } = "";
    public string Sifre { get; set; } = "";
    public string İsim { get; set; } = "";
    public DateTime AcilisTarih { get; set; } = DateTime.Now;
}