using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularDemoCrud.Models;
using AngularDemoCrud.DBOperation;

namespace AngularDemoCrud.Controllers
{
    public class ProductsController : ApiController
    {
        public List<Products> GetProducts(int pageIndex, int pageSize)
        {
            ProductInfo empInfo = new ProductInfo();
            List<Products> empList = empInfo.GetProducts(pageIndex, pageSize);
            return empList;
        }

        public Products getproduct(int id)
        {
            ProductInfo prd = new ProductInfo();
            return prd.getProduct(id);
        }

        [HttpPost]
        public String SaveProduct(Products product)
        {
            ProductInfo prdInfo = new ProductInfo();
            
            String result = prdInfo.SaveProduct(product);
            return result;
        }

        [HttpDelete]
        public string deleteProduct(int productid)
        {
            string result = "";
            ProductInfo prdinfo = new ProductInfo();
            try {
                prdinfo.deleteProduct(productid);
            }
            catch(Exception e)
            {
                result = "Error in deleteing"+e;
            }
            
            if(result=="")
            { result = "Success"; }

            return result;
            
        }

    }
}
