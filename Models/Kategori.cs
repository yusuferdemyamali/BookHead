using System.ComponentModel.DataAnnotations;

namespace BookHead.Models;

public class Kategori
{
    [Key]
    public int KategoriId { get; set; }
    [Required]
    public string KategoriAd { get; set; }
}