﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PRSPracticeLibrary.Models {
    public class RequestLine {

        public int Id { get; set; }
        public int RequestId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
       
       


        public RequestLine() { }

        public virtual Product Product { get; set;}
        public virtual Request Request { get; set; }
        
    }
}
