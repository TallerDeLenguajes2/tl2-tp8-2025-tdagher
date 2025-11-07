using Microsoft.AspNetCore.Mvc;

public class ProductosController : Controller
{
    private ProductoRepository productoRepository;
    public ProductosController()
    {
        productoRepository = new ProductoRepository();
    }

    [HttpGet]
    public IActionResult Create()
    {
        var producto = new Producto();
        return View(producto);
    }
}
