using System.ComponentModel.DataAnnotations;

namespace BookHead.Models;

public class Kitap
{
    [Key]
    public int KitapID { get; set; }
    [Required]
    public string İsim { get; set; } = "";
    public string Yazar { get; set; } = "";
    public string YayinEvi { get; set; } = "";
    public string Kategori { get; set; } = "";
    public string Resim1 { get; set; } = "";
    public string Resim2 { get; set; } = "";
    public int ISBN { get; set; }
    public string Yorumlar { get; set; } = "";
    public string İlgincBilgiler { get; set; } = "";
}