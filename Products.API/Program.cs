using Products.API.ViewModels;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products", () => new List<Product>
{
    new Product("Urun1","100"),
    new Product("Urun2","1030"),
    new Product("Urun3","1050"),
    new Product("Urun4","1400"),
    new Product("Urun5","300"),
    new Product("Urun6","200"),
});

app.Run();