using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Products> _productList = null;
        void Initialize()
        {
            _productList = new List<Products>()
           {
               new Products() { ProductId=1, Name="BMW" , QtyInStock=100, Description="Luxury", Supplier="BMWG"},

               new Products() {ProductId=2, Name="SCLASS" , QtyInStock=200, Description="Luxury", Supplier="MECDG" },
           };

        }
        public ProductsController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }

        //public IEnumerable<Products> Get()
        //{
        //    return _productList;
        //}
        //public Products Get(int id)
        //{
        //    Products product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
        //    return product;
        //}


        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productList);
        }

        // GET: api/Productss/5
        public HttpResponseMessage Get(int id)
        {
            Products product = _productList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, product);
        }



        public HttpResponseMessage Post(Products Products)
        {
            if (Products != null)
            {
                _productList.Add(Products);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Productss/5
        public HttpResponseMessage Put(int id, Products objProducts)
        {
            Products Products = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (Products == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products Not found");

            }
            else
            {
                if (Products != null)
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
                return Request.CreateResponse(HttpStatusCode.OK, "Modified");

            }
        }

        // DELETE: api/Productss/5
        public HttpResponseMessage Delete(int id)
        {
            Products Product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (Product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products Not found");

            }
            else
            {
                if (Product != null)
                {
                    _productList.Remove(Product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleteed");
            }

        }
    }
}




//public void Post(Products product)
//        {
//            if (product != null)
//            {
//                _productList.Add(product);
//            }

//        }

//        public void Delete(int id)
//        {
//            Products product = _productList.Where(x => x.ProductId == id).FirstOrDefault();

//            if (product != null)
//            {
//                _productList.Remove(product);
//            }
//        }

        //public IHttpActionResult Get()
        //{
        //    return Ok(1);
        //}
   // }
//}
