using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace BookHead.Models;

public class Kitap
{
    [Key]
    public int KitapID { get; set; }
    [Required]
    public string İsim { get; set; } = "";
    public string Yazar { get; set; } = "";
    public string YayinEvi { get; set; } = "";
    public string Resim1 { get; set; } = "";
    public string Resim2 { get; set; } = "";
    
    public string Kategori { get; set; } = "";

    public string ISBN { get; set; }
    public string Yorumlar { get; set; } = "";
    
    public string KitapOzet { get; set; } = "";
    public string Out_Text { get; set; } = "";
    public string Satici { get; set; } = "";
    public string Slug { get; set; } = "";
    public float Fiyat { get; set; }
    public string Url { get; set; } = "";
    public string FiyatKarşılaştırmaJson { get; set; } = "";

}

