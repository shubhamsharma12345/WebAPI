using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class PController : ApiController
    {

        static List<Products> _productList = null;
        void Initialize()
        {
            _productList = new List<Products>()
           {
               new Products() { ProductId=1, Name="xyz" , QtyInStock=100, Description="Luxury", Supplier="BMWG"},

               new Products() {ProductId=2, Name="SCLASS" , QtyInStock=200, Description="Luxury", Supplier="MECDG" },
           };

        }


        public PController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }
        // GET: api/Students
        public IHttpActionResult Get()
        {
            return Ok(_productList);
            

        }
        public IHttpActionResult Get(int id)
        {
            Products product = _productList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
            {
                return NotFound();
                
            }
            else
            {
                return Ok(product);
                
            }


        }

        public IHttpActionResult Post(Products product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Content(HttpStatusCode.Created, "Record Created");
            
        }
        public IHttpActionResult Put(int id, Products objProducts)
        {
            Products product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
                
            }
            else
            {
                if (product != null)
                {
                    foreach (Products temp in _productList)
                    {
                        if (temp.ProductId == id)
                        {
                            temp.Name = objProducts.Name;
                            temp.QtyInStock = objProducts.QtyInStock;
                            temp.Description = objProducts.Description;
                            temp.Supplier = objProducts.Supplier;
                        }
                    }

                }
                return Content(HttpStatusCode.OK, "Record Modified");
                
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            if (id != null)
            {
                Products product = _productList.FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return NotFound();
                    
                }

                else
                {

                    _productList.Remove(product);
                    return Content(HttpStatusCode.OK, "Record deleted");
                    
                }
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Please provide ID");
                 
            }
        }
    }
}




      

        
        
      