using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T1807E_HelloMVC.Models;

namespace T1807E_HelloMVC.Controllers
{
    public class ProductsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Index(string keyword)
        {
            List<Product> list = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    ProductName = "Quần Áo Dài",
                    Price = 100000,
                    Description = "Thời trang thu đông",
                    Image = "data:image/jpeg;base64,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",
                    CategoryId = 2

                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Áo Thu Đông",
                    Price = 50000,
                    Description = "Áo Thu Đông cho bé",
                    Image = "https://file.yes24.vn/Upload/ProductImage/iStyle24_KIDS/1997593_L.jpg",
                    CategoryId = 1
                },

                new Product()
                {
                    Id = 1,
                    ProductName = "Mũ, Nón",
                    Price = 50000,
                    Description = "Mũ Nón Cho Bé",
                    Image = "https://kidsplaza-1.cdn.vccloud.vn/media/catalog/product/cache/1/image/430x/9df78eab33525d08d6e5fb8d27136e95/i/m/img_8238.jpg",
                    CategoryId = 1
                },
            };
            return View(list.Where(Product => Product.ProductName == keyword)
                .ToList());
        }

        // GET: Products
        //    public ActionResult Index()
        //{
        //    var products = db.Products.Include(p => p.Category);
        //    return View(products.ToList());
        //}

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProductName,Price,Description,Image,CategoryId,Created_At,Updated_At")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProductName,Price,Description,Image,CategoryId,Created_At,Updated_At")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
