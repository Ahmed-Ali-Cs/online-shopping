using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using online_shopping.Models;
using online_shopping.Models.Data;
using online_shopping.Models.UnitOfWork;

namespace online_shopping.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;


        public ProductsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        // GET: Products
        public IActionResult Index()
        {
            var product = unitOfWork.Product.GetAll();
            return View(product);
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = unitOfWork.Product.Get(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {

                unitOfWork.Product.Add(product);
                unitOfWork.Save();
                TempData["Success"] = "The Product has been Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = unitOfWork.Product.Get(p => p.Id == id);
            unitOfWork.Save();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {

            if (ModelState.IsValid)
            {

                unitOfWork.Product.Update(product);
                unitOfWork.Save();
                TempData["Success"] = "The Product has been Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
           

            var product = unitOfWork.Product.Get(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {

            if (ModelState.IsValid)
            {

                unitOfWork.Product.Delete(product);
                unitOfWork.Save();

                TempData["Success"] = "The Product has been Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _context.Products.Remove(product);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return unitOfWork.Product.Any(e => e.Id == id);
        //}
    }
}
