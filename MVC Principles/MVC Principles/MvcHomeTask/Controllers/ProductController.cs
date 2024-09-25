using Microsoft.AspNetCore.Mvc;
using MvcHomeTaskLibrary;
using MvcHomeTaskLibrary.Models;

namespace MvcHomeTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public ProductController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Catalog()
        {
            var products = _unitOfWork.ProductRepository.GetProductsWithCategoryNameAndSupplierName();

            return View(products);
        }
        [HttpGet]
        public IActionResult Select()
        {
            var products = _unitOfWork.ProductRepository.GetProductsWithCategoryNameAndSupplierName();

            return View(products);
        }

        [HttpPost]
        public IActionResult Select(int selectedProductId)
        {
            return RedirectToAction("Update", "Product", new { selectedProductId });
        }

        [HttpGet]
        public IActionResult Update(int selectedProductId)
        {
            var product = _unitOfWork.ProductRepository.GetProductForUpdate(selectedProductId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Update(ProductForUpdate updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Error! Data was not saved.";
                return RedirectToAction("Index", "Home");
            }
          
            var product = ProductModelConverter.ConvertProductForUpdateIntoProduct(updatedProduct);
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Save();

            return RedirectToAction("Display", "Product", new { product.ProductId });
        }

        public IActionResult Display(int productId)
        {
            var product = _unitOfWork.ProductRepository.GetProductForUpdate(productId);

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new ProductForUpdate
            {
                Suppliers = _unitOfWork.SupplierRepository.Read(),
                Categories = _unitOfWork.CategoryRepository.Read()
            };

            return View(product);
        }

        [HttpPost]
        public IActionResult Create(ProductForUpdate updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Error! Data was not saved.";
                return RedirectToAction("Index", "Home");
            }

            var product = ProductModelConverter.ConvertProductForUpdateIntoProduct(updatedProduct);
            _unitOfWork.ProductRepository.Create(product);
            _unitOfWork.Save();

            return RedirectToAction("Display", "Product", new { product.ProductId });
        }
    }
}
