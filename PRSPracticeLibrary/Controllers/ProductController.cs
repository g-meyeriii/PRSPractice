using Microsoft.EntityFrameworkCore;
using PRSPracticeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPracticeLibrary.Controllers {
    class ProductController {
        private AppDbContext context = new AppDbContext();

       public IEnumerable<Product> GetAll() {
            return context.Products.ToList();
        }
        public Product GetByPk(int id) {
            if (id < 1 || id == null) throw new Exception("Id is null or less than zero");
            return context.Products.Find(id);
        }
        public Product Insert(Product product) {
            if (product == null) throw new Exception("Product can't be null");
            if (product.PartNbr == null || product.PartNbr.Length > 30) throw new Exception("PartNbr null or too long");
            if (product.Name == null || product.Name.Length > 30) throw new Exception("Name null or too long");
            if (product.Price == null) throw new Exception("Price can't be null");
            if (product.Unit == null || product.Unit.Length > 30) throw new Exception("Unit is null or too long");
            if (product.PhotoPath.Length > 255) throw new Exception("Photopath is too long");
            if (product.VendorId == null || product.VendorId <= 0) throw new Exception("VendorId is null or less than 1");
            var productDb = context.Products.Find(product.Id);
            context.Products.Add(product);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return product;
        }
        public bool Update(int id, Product product) {
            if (product == null || id != product.Id) throw new Exception("Id is null or doesn't match the product");
            if (product.PartNbr == null || product.PartNbr.Length > 30) throw new Exception("ParNbr null or too long");
            if (product.Name == null || product.Name.Length > 30) throw new Exception("Name is null or too long");
            if (product.Price == null) throw new Exception("Price can't be null");
            if (product.Unit == null || product.Unit.Length > 30) throw new Exception("Unit is null or too long");
            if (product.PhotoPath.Length > 255) throw new Exception("PhotoPath is too long");
            if (product.VendorId == null || product.VendorId <= 0) throw new Exception("VendorId is null or less than 1");
            var productDb = context.Products.Find(id);
            context.Products.Add(product);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("PartNbr must be unique", ex);
            } catch (Exception ex) {

            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var product = context.Products.Find(id);
            if (id != product.Id) throw new Exception("Id and Product.Id must match");
            return Delete(product);
        }
        public bool Delete(Product id) {
            if (id == null) throw new Exception("ProductId can't be null");
            context.Products.Remove(id);
            context.SaveChanges();
            return true;
        }
        
        public ProductController() { }
    }
}
