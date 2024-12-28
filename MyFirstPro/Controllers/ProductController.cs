using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyFirstPro.Models;

namespace MyFirstPro.Controllers
{
    public class ProductController : Controller
    {
        // Simulated in-memory data store
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Quantity = 10 },
            new Product { Id = 2, Name = "Mouse", Quantity = 0 }
        };

        // GET: Product
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Automatically assign the next available ID
                product.Id = products.Max(p => p.Id) + 1;
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Edit/1
        public ActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Edit/1
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                existingProduct.Quantity = product.Quantity;
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Product/Delete/1
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // POST: Product/Delete/1
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}
