using System.ComponentModel.DataAnnotations;



public class Ayar
{
    
    [Key]
    public int AyarID { get; set; }
    [Required]
    public string LogoResim { get; set; }
    public string AnaSayfaResim { get; set; }
    public string HakkindaResim { get; set; }
    public string GirisSayfaResim { get; set; }
    public string HakkindaH2 { get; set; }
    public string HakkindaP { get; set; }
}