using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class MerchandiseController : ControllerBase
{
    private static readonly string[] Merchandise = new[]
    {
        "Apple", "Orange", "Peach", "Grapes", "Banana", "Mango", "Watermelon", "Pear", "Pineapple", "Cherry"
    };
    
    private readonly ILogger<MerchandiseController> _logger;

    public MerchandiseController(ILogger<MerchandiseController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetMerchandise")]
    public IEnumerable<Merchandise> Get()
    {
        return Enumerable.Range(0, Merchandise.Length).Select(index => new Merchandise
            {
                Name = Merchandise[index],
                Price = Random.Shared.NextDouble() * 100,
                Amount = Random.Shared.Next(0, 100)
            })
            .ToArray();
    }
}