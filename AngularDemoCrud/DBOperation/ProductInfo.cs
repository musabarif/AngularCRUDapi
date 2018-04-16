using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularDemoCrud.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Data.Entity.Core.Objects;

namespace AngularDemoCrud.DBOperation
{
    public class ProductInfo
    {
        public List<Products> GetProducts(int pageIndex, int pageSize)
        {
            ProductList ProductList = new ProductList();
            List<Products> listPrd = new List<Products>();           
            ObjectResult<GetProducts_Result> queryResults = null;
            using (var context=new ProductDbEntities())
            {                
                try
                {
                    queryResults =context.GetProducts(pageIndex, pageSize);

                    foreach(var product in queryResults)
                    {
                        listPrd.Add(new Products
                        { description = product.description,productId=product.productId,productCode=product.productCode,price=(float)product.price,productName=product.productName,starRating=(float)product.starRating,imageUrl=product.imageUrl,releaseDate=product.releaseDate });
                    }
                    
                    //dr.NextResult();

                    //while (dr.Read())
                    //{
                    //    ProductList.totalCount = dr["totalCount"].ToString();
                    //}
                    //ProductList.products = listPrd;
                }
                catch (Exception ex)
                {

                    throw;
                }
                return listPrd;
            }
        }

        public Products getProduct(int ID)
        {
            using (var context = new ProductDbEntities())
            {
                ObjectResult<GetProduct_Result> prd = context.GetProduct(ID);
                Products result= new Products();
                foreach(var product in prd)
                {
                    result = new Products { description = product.description, productId = product.productId, productCode = product.productCode, price = (float)product.price, productName = product.productName, starRating = (float)product.starRating, imageUrl = product.imageUrl, releaseDate = product.releaseDate };
                }
                return result;
            }
        }
        public string SaveProduct(Products product)
        {
            using (var context = new ProductDbEntities())
            {
                var result = context.Products.Add(
                    new Product { productName = product.productName,                                  
                                  productCode=product.productCode,
                                  releaseDate=product.releaseDate,
                                  description=product.description,
                                  starRating=product.starRating,
                                  imageUrl=product.imageUrl,
                                  price=product.price
                });
                context.SaveChanges();

            if(result.productId!=0)
                {
                    return "Success";
                }
                return "Error";
            }

        }

        public void deleteProduct(int productid)
        {
            using (var context = new ProductDbEntities())
            {
                var prd = new Product { productId = productid };
                context.Products.Attach(prd);
                context.Products.Remove(prd);
                context.SaveChanges();
            }
        }
    }
}