using Microsoft.EntityFrameworkCore;
using PRSPracticeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPracticeLibrary.Controllers {
    public class VendorController {
        private AppDbContext context = new AppDbContext();

        public IEnumerable<Vendor> GetAll() {
            return context.Vendors.ToList();
        }
        public Vendor GetByPk(int id) {
            if (id < 1) throw new Exception("VendorId not found");
            return context.Vendors.Find(id);
        }
        public Vendor Insert(Vendor vendor) {
            if (vendor.Id == null) throw new Exception("VendorId can't be null");
            if (vendor.Code == null || vendor.Code.Length > 30) throw new Exception("Code is null or too long");
            if (vendor.Name == null || vendor.Name.Length > 30) throw new Exception("Name is null or too long");
            if (vendor.Address == null || vendor.Address.Length > 30) throw new Exception("Address is null or too long");
            if (vendor.City == null || vendor.City.Length > 30) throw new Exception("City is null or too long");
            if (vendor.State == null || vendor.State.Length > 2) throw new Exception("State is null or too long");
            if (vendor.Zip == null || vendor.Zip.Length > 5) throw new Exception("Zip is null or too long");
            if (vendor.Phone == null || vendor.Phone.Length > 12) throw new Exception("Phone is too long");
            if (vendor.Email == null || vendor.Email.Length > 255) throw new Exception("Email too long");
        
            var vendorDb = context.Vendors.Find(vendor.Id);
            context.Vendors.Add(vendor);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return vendor;
        }
        public bool Update(int Id, Vendor vendor) {
            if (vendor == null) throw new Exception("Vendor can't be null");
            if (Id != vendor.Id) throw new Exception("Vendor and VendorId don't match");
            if (vendor.Code == null || vendor.Code.Length > 30) throw new Exception("Code is null or too long");
            if (vendor.Name == null || vendor.Name.Length > 30) throw new Exception("Name is null or too long");
            if (vendor.Address == null || vendor.Address.Length > 30) throw new Exception("Address is null or too long");
            if (vendor.City == null || vendor.City.Length > 30) throw new Exception("City is null or too long");
            if (vendor.State == null || vendor.State.Length > 2) throw new Exception("State is null or too long");
            if (vendor.Zip == null || vendor.Zip.Length > 5) throw new Exception("Zip is null or too long");
            if (vendor.Phone == null || vendor.Phone.Length > 12) throw new Exception("Phone is too long");
            if (vendor.Email == null || vendor.Email.Length > 255) throw new Exception("Email too long");

            var vendorDb = context.Vendors.Find(vendor.Id);
            context.Vendors.Add(vendor);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception ex) {
                throw;
            }
            return true;
        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("VendorId must be greater than zero");
            var vendor = context.Vendors.Find(id);
            if (id != vendor.Id) throw new Exception("Id and VendorId must mathc");

            return Delete(vendor);

        } 
        public bool Delete(Vendor id) {
            if (id == null) throw new Exception("Id can't be null");
            context.Vendors.Remove(id);
            context.SaveChanges();
            return true;
        }


        public VendorController() {}
    }
}
