using Microsoft.EntityFrameworkCore;
using PRSPracticeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPracticeLibrary.Controllers {
    public class RequestLineController {

        private readonly AppDbContext context = new AppDbContext(); //private won't be called outside this class

        private void RecalcRequestTotal(int requestId) {
           var request = context.Requests.Find(requestId);
            request.Requestlines.Sum(x => x.Quantity * x.Product.Price);
           //Alternate below
            //var total = context.RequestLines.Where(rl => rl.RequestId == requestId
                                                    //.Sum(rl => rl.Quantity * rl.Product.Price);
                                                    //request.Total = total;
            context.SaveChanges();
        }
        public IEnumerable<RequestLine> GetAll() {
            return context.RequestLines.ToList();
        }
        public RequestLine  GetRequest(int id) {
            if (id < 1) throw new Exception("Id must be greater than zero");
            return context.RequestLines.Find();
        }
        public RequestLine Insert(RequestLine requestLine) {
            if (requestLine == null) throw new Exception("Requesline can't be null");
            context.RequestLines.Add(requestLine);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception) {
                throw;

            } return requestLine;
        }
        public bool Update(int id, RequestLine requestLine) {
            if (id == null) new Exception("Id can't be null");
            if (requestLine == null) new Exception("RequestLine can't be null");
            if (requestLine.ProductId == null) new Exception("ProductId can't be null");
            if (requestLine.Quantity == null) new Exception("Quantity can't be null");
            
            var requestLineDb = context.RequestLines.Find(requestLine.Id);
            context.RequestLines.Add(requestLine);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Username must be unique", ex);
            } catch (Exception) {
                throw;
            }
            return true;

        }
        public bool Delete(int id) {
            if (id <= 0) throw new Exception("Id must be greater than zero");
            var requestLine = context.RequestLines.Find(id);
            if (id != requestLine.Id) throw new Exception("Id and requesLine.Id must match");
            // check the value and new exception

            return Delete(requestLine);
        }

        public bool Delete(RequestLine id) { //two delete functions
            if (id == null) throw new Exception("RequesLine Id can't be null");
            context.RequestLines.Remove(id);
            context.SaveChanges();
            return true;
        }

    }
}
