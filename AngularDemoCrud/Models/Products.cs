using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemoCrud.Models
{
    public class Products
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productCode { get; set; }
        public string releaseDate { get; set; }
        public float price { get; set; }  
        public string description { get; set; }  
        public float starRating { get; set; }  
        public string imageUrl { get; set; }  
    }
}
    