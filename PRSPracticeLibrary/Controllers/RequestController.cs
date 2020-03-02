using Microsoft.EntityFrameworkCore;
using PRSPracticeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PRSPracticeLibrary.Controllers {
    public class RequestController {

        public const string StatusNew =         "NEW";
        public const string StatusEdit =        "EDIT";
        public const string StatusReview =      "REVIEW";
        public const string StatusApproved =    "APPROVED";
        public const string StatusRejected =    "REJECTED";

        private AppDbContext context = new AppDbContext();

        public IEnumerable<Request> GetRequestsToReviewNotOwn(int userId) {// *****is reviewer they don't own *****
            return context.Requests.Where(x => x.UserId != userId && x.Status == StatusReview).ToList();
        }
        public bool SetToReview(Request request) { //********This is the set to review or approve based on 50$ amount******
            if (request.Total <= 50)
                request.Status = StatusApproved;
            else {
                request.Status = StatusReview;
            }
            return Update(request.Id, request);
         }
        public bool SetToApproved(Request request) {
            request.Status = StatusApproved;
            return Update(request.Id, request);
        }
        public bool SetToRejected(Request request) {
            request.Status = StatusRejected;
            return Update(request.Id, request);
        }
        public IEnumerable<Request> GetAll() {
            return context.Requests.ToList();
        }
        public Request GetByPk(int id) {
            if (id >= 1) throw new Exception("Id must be greater than zero");
            return context.Requests.Find(id);
        }
        public Request Insert(Request request) {
            if (request == null) throw new Exception("User can't be null");
            if (request.Description == null || request.Description.Length > 80) throw new Exception("Descriptin is null or too long");
            if (request.Justification == null || request.Justification.Length > 80) throw new Exception("Justification is null or too long");
            if (request.Rejection == null || request.Rejection.Length > 80) throw new Exception("RejectionReason is null or too long");
            if (request.DeliveryMode == null || request.DeliveryMode.Length > 20) throw new Exception("DeliveryMode null or too long");
            if (request.Status == null || request.Status.Length > 10) throw new Exception("Status is null or too long");
            if (request.Total == null) throw new Exception("Total is null or too long");
            if (request.UserId == null) throw new Exception("UserId is null");
            
            var requestDb = context.Requests.Find(request.Id);
            context.Requests.Add(request);
            try {
                context.SaveChanges();
            } catch (DbUpdateException ex) {
                throw new Exception("Check all data for accuracy", ex);
            } catch (Exception ex) {
                throw;
            }
            return request;
        }
        private bool Update(int id, Request request) {
            if (request == null) throw new Exception("Request can't be null");
            if (id != request.Id) throw new Exception("Id and Request.Id must match");
            if (request.Description == null || request.Description.Length > 80) throw new Exception("Description is null or too long");
            if (request.Justification == null || request.Justification.Length > 80) throw new Exception("Justificaton is null or too long");
            if (request.Rejection == null || request.Rejection.Length > 80) throw new Exception("Rejection is null or too long");
            if (request.DeliveryMode == null || request.DeliveryMode.Length > 20) throw new Exception("DeliveryMode is null or too long");
            if (request.Status == null || request.Status.Length > 10) throw new Exception("Status is null or too long");
            if (request.Total == null) throw new Exception("Total is null or too long");
            if (request.UserId == null) throw new Exception("UserId can't be null");
            var requesDb = context.Requests.Find(request.Id);
            context.Requests.Add(request);
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
            if (id > 0) throw new Exception("Id must be greater than zero");
            var request = context.Requests.Find(id);
            if (id != request.Id) throw new Exception("Id and Request.Id must match");
            // check the value and new exception

            return Delete(request);
        }

        public bool Delete(Request id) { //two delete functions
            if (id == null) throw new Exception("RequestId can't be null");
            context.Requests.Remove(id);
            context.SaveChanges();
            return true;
        }
        public RequestController() {

        }
    }
}
