using BookHead.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace BookHead.Controllers;

public class BookController : Controller
{
    private readonly denemeDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<BookController> _logger;

    public BookController(
        denemeDbContext context, 
        IConfiguration configuration,
        ILogger<BookController> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public IActionResult Index(string Slug)
    {
        // Kitabı bul
        var kitap = _context.Kitaplar.FirstOrDefault(b => b.Slug == Slug);

        if (kitap == null)
        {
            return NotFound();
        }

        try 
        {
            // Fiyat karşılaştırma API çağrısı
            var priceComparison = GetBookPriceComparison(kitap.ISBN);

            // Fiyat karşılaştırma sonuçlarını JSON olarak kaydet
            if (priceComparison != null && priceComparison.Any())
            {
                kitap.FiyatKarşılaştırmaJson = JsonConvert.SerializeObject(priceComparison);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            // Hata loglaması
            _logger.LogError(ex, $"Fiyat karşılaştırması alınırken hata oluştu. ISBN: {kitap.ISBN}");
        }

        return View(kitap);
    }

    private List<BookPriceResult> GetBookPriceComparison(string isbn)
    {
        // API ayarları
        var apiKey = _configuration["ExternalApis:BookPriceComparison:ApiKey"];
        var apiUrl = "https://api.collectapi.com/book/bookPriceComparison";

        try 
        {
            // RestSharp ile API çağrısı
            var client = new RestClient(new RestClientOptions(apiUrl));
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddParameter("isbn", isbn);
            request.AddHeader("authorization", $"apikey {apiKey}");
            request.AddHeader("content-type", "application/json");

            // API yanıtını al
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // JSON yanıtını parse et
                var bookData = JsonConvert.DeserializeObject<BookPriceComparisonResponse>(response.Content);

                // Başarılı ise sonuçları döndür
                return bookData?.Success == true 
                    ? bookData.Result 
                    : new List<BookPriceResult>();
            }

            return new List<BookPriceResult>();
        }
        catch (Exception ex)
        {
            // Hata loglaması
            _logger.LogError(ex, $"API çağrısı sırasında hata oluştu. ISBN: {isbn}");
            return new List<BookPriceResult>();
        }
    }

    // API yanıt modelleri
    public class BookPriceComparisonResponse
    {
        public bool Success { get; set; }
        public List<BookPriceResult> Result { get; set; }
    }

    public class BookPriceResult
    {
        public string StoreName { get; set; }
        public decimal Price { get; set; }
        public string StoreUrl { get; set; }
    }
}