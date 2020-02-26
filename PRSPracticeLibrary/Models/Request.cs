using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PRSPracticeLibrary.Models {
    public class Request {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Justification { get; set; }
        public string Rejection { get; set; }
        public string DeliveryMode { get; set; }
        public string Status { get; set; }
        public Decimal Total { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<RequestLine> Requestlines { get; set; }

        //public  virtual User Users { get; set; } //Virtual used to set up the foreign key

        //* `RejectionReason` must be provided when the request is rejected
        //* The `UserId` is automatically set to the Id of the logged in user.
        //* Neither `Status` nor `Total` may be set by the user.These are set by the application only.
        //* The `Total` is auto calculated by adding up all the lines currently on the request
        //* There should be a virtual `User` instance in the Request to hold the FK
        //  instance when reading a Request
        //* There should be a virtual collection of `RequestLine` instances in the Request to
        //hold the collection of lines related to this Request.

        //Methods
        //* Review(requestId) - Sets the status of the request for the id provided to "REVIEW"
        //* Approve(requestId) - Sets the status of the request for the id provided to "APPROVED"
        //* Reject(requestId) - Sets the status of the request for the id provided to "REJECTED"
        //* GetReviews(userId) - Gets requests in review status and now owned by userId


        public Request() { }

        
    }
}
