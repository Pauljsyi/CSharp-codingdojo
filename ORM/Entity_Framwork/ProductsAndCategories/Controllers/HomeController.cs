using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("")]
    public IActionResult NewProductForm()
    {

        ViewBag.AllProducts = _context.Products.ToList();
        return View("ProductForm");
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProd)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProd);
            _context.SaveChanges();
            return RedirectToAction("NewProductForm", newProd);
        }
        ViewBag.AllProducts = _context.Products.ToList();
        return View("ProductForm");
    }
    [HttpGet("categories")]
    public IActionResult NewCategoryForm()
    {
        ViewBag.AllCategories = _context.Categories.ToList();

        return View("CategoryForm");
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("NewCategoryForm");
        }
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("CategoryForm");
    }

    [HttpGet("categories/{categoryId}")]
    public IActionResult ShowCategory(int categoryId)
    {
        Category? SingleCategory = _context.Categories
            .Include(item=> item.ByCategory)
            .ThenInclude(item => item.Product)
            .FirstOrDefault(p => p.CategoryId == categoryId);
            
        List<Product> nonProducts = _context.Products
            .Include(item => item.ByProducts)
            .Where(a => a.ByProducts.All(a => a.CategoryId != categoryId))
            .ToList();
        ViewBag.nonProducts = nonProducts;

        return View("ShowCategory", SingleCategory);
    }

    [HttpGet("products/{productId}")]
    public IActionResult ShowProduct(int productId)
    {
        // System.Console.WriteLine($"product id in show category: {productId}");
        
        Product? SingleProduct = _context.Products
            .Include(item => item.ByProducts)
            .ThenInclude(item => item.Category)
            .FirstOrDefault(p => p.ProductId == productId);

        List<Category> nonCategories = _context.Categories
            .Include(item => item.ByCategory)
            .Where(a => a.ByCategory.All(a => a.ProductId != productId))
            .ToList();
        ViewBag.nonCategories = nonCategories;
        return View("ShowProduct", SingleProduct);
    }

    [HttpPost("association/create")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("ShowProduct", new {productId = newAssociation.ProductId});
        }
        
        return ShowProduct(newAssociation.ProductId);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
