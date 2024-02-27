using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Controllers {
    public class DashBoardController : Controller {
        private static List<Product> _products = new List<Product>();
        private static List<Company> _companies = new List<Company>();
        private static List<Blog> _blogs = new List<Blog>();

        private readonly ApplicationDbContext _db;

        public DashBoardController ( ApplicationDbContext db ) {
            _companies.Add( new Company { Id = 1 , Name = "Niki"} );
            _companies.Add( new Company { Id = 2 , Name = "Adidas" } );
            _db = db;
        }

        public IActionResult Index () {
            return View();
        }
        public IActionResult AddProduct () {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct (Product product) {
            _db.products.Add( product );
            _db.SaveChanges();
            if ( !ModelState.IsValid ) {
                return View(product);
            }
            return RedirectToAction( "index" );
        }
        #region GetAll
        public IActionResult GetAllData () {
            var products = _db.products.Include(p => p.company).ToList();
            return View( products );
        }
        #endregion
        # region DeleteProduct
        public IActionResult DeleteProduct ( int id) {
            Product? product = _db.products.FirstOrDefault ( x => x.Id == id);
            _products.Remove(product);
            _db.products.Remove( product );
            _db.SaveChanges();
            return RedirectToAction( "GetAllData" );
        }
        #endregion
        #region EditProduct
        public IActionResult EditProduct (int id) {
            Product? product = _db.products.FirstOrDefault( x => x.Id == id );
            _db.SaveChanges();
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct ( Product product) {
            Product? pd = _db.products.SingleOrDefault(c=>c.Id == product.Id);
            pd.Name = product.Name;
            pd.Price = product.Price;
            pd.Quantity = product.Quantity;
            pd.EnableSize = product.EnableSize;
            pd.Description = product.Description;
            pd.companyId = product.companyId;
            _db.products.Update(pd);
            _db.SaveChanges();

            return RedirectToAction( "index" );
        }
        #endregion
        public IActionResult AddBlog () {
            return View();
        }
        public IActionResult AddBlog ( Blog blog ) {
            return RedirectToAction( "index" );
        }
    }
}
