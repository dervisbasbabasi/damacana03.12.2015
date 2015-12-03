using DamacanaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DamacanaWeb.Controllers
{
    public class HomeController : Controller
    {
        static int counterId = 3;
        public static List<Product> products = new List<Product>(){
            new Product()
            {
                Id = 1,
                Name = "Pinar",
                Price = (decimal)9.99,
            },
            new Product()
            {
                Id = 2,
                Name = "Erikli",
                Price = (decimal)3.33,
            },
            
        };

        static List<Cart> carts = new List<Cart>();

        Cart cart1 = new Cart()
        {
            Id = 1,
            UserId = 1,

        };

        static List<Purchase> purchases = new List<Purchase>();

        Purchase purchase1 = new Purchase()
        {
            Id = 1,
            UserId = 1,
            TotalPrice = 10,

        }; 
        Purchase purchase2 = new Purchase()
        {
            Id = 2,
            UserId = 1,
            TotalPrice = 15,

        };
        public ActionResult Index()
        {
            //Create an instance of product
            /* 
            Product product1 = new Product()
            {
                Id = 1,
                Name = "Potion of Invisibility",
                Price = (decimal) 4.90
            };

            Product product2 = new Product()
            {
                Id = 2,
                Name = "Potion of Increased Magicka",
                Price = (decimal)4.90
            };

            Product product3 = new Product()
            {
                Id = 3,
                Name = "Potion of Cure Disease",
                Price = (decimal)4.90
            };
            

            List<Product> products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);

            //Send product to view engine 
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);*/
            purchases.Add(purchase1);
            purchases.Add(purchase2);
            carts.Add(cart1);
            return View(products);
        }

        //[HttpPost]
        /*public ActionResult AddProduct()
        {
            Product product = new Product()
            {
                Name = "",
                Price = (decimal)0
            };

            return View(product);
        }*/

        public ActionResult ProductList()
        {
            return View(products);
        }
        public ActionResult AddProduct()
        {
            Product product = new Product();
            return View(product);

        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            ViewBag.Message = "SaveProduct worked sir...";
            product.Id = counterId;
            counterId++;
            products.Add(product);
            return View(product);
        }
        //--------------------------------------------

        [HttpGet]
        public ActionResult DeleteProduct(string name)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in products)
            {

                if (find.Name == name)
                {
                    products.Remove(find);
                    break;
                }

            }
            return View(products);
        }

        public ActionResult EditProduct(string name)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Product product = new Product();

            foreach (var find in products)
            {

                if (find.Name == name)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;


                    products.Remove(find);
                    break;
                }

            }
            return View(product);
        }
        public ActionResult CartList()
        {
            return View(carts);
        }
        public ActionResult AddCart()
        {
            //create an empty cart
            Cart cart = new Cart();

            return View(cart);

        }
        [HttpPost]
        public ActionResult SaveCart(Cart cart)
        {

            carts.Add(cart);
            return View(cart);
        }
        public ActionResult EditCart(int id)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Cart cart = new Cart();

            foreach (var find in carts)
            {

                if (find.Id == id)
                {


                    cart.UserId = find.UserId;

                    cart.Id = find.Id;


                    carts.Remove(find);
                    break;
                }

            }
            return View(cart);
        }
        [HttpGet]
        public ActionResult DeleteCart(int id)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in carts)
            {

                if (find.Id == id)
                {
                    carts.Remove(find);
                    break;
                }

            }
            return View(carts);
        }
        public ActionResult AddtoCart(string name)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Product product = new Product();

            foreach (var find in products)
            {

                if (find.Name == name)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;
                    product.CartId = 1;

                    products.Remove(find); products.Add(product);
                    break;
                }

            }
            return View(product);
        }


        [HttpGet]
        public ActionResult DeleteProductfromCart(string name)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in products)
            {

                if (find.Name == name)
                {
                    find.CartId = 0;
                    break;
                }

            }
            return View(products);
        }

        public ActionResult ProductListofEachCart(int id)
        {
            List<Product> productsofeachcart = new List<Product>();
            Product product = new Product();
            foreach (var find in products)
            {

                if (find.CartId == id)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;


                    productsofeachcart.Add(product);

                }

            }
            return View(productsofeachcart);
        }
        // -------------------------------------------

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Bag()
        {
            ViewBag.Message = "Your bag page.";

            return View();
        }
    }
}