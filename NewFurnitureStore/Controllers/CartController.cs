using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FurnitureStore.Models;
using Microsoft.AspNet.Identity;
using NewFurnitureStore.Models;
namespace NewFurnitureStore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Buy(int id)
        {
            var productDetails = db.Products.Where(i => i.Id == id).Single();
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem { Product = productDetails, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                List<CartItem> cart = (List<CartItem>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = productDetails, Quantity = 1 });
                }
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }


        private int isExist(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id.Equals(id))
                    return i;
            return -1;
        }

        public ActionResult CreateOrder()
        {
            var UserId = User.Identity.GetUserId();
            var UserDetails = db.Users.Where(i => i.Id == UserId).Single();
            Order orders = new Order();
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            var total = cart.Sum(item => item.Product.Price * item.Quantity);

            foreach (CartItem item in (List<CartItem>)Session["cart"])
            {
                Product @product = db.Products.Find(item.Product.Id);

                orders.OrderDate = DateTime.Today.ToString("D");
                orders.OrderTotal = total;
                orders.PId = item.Product.Id;
                orders.PName = item.Product.Name;
                orders.PPrice = item.Product.Price;
                orders.Quantity = item.Quantity;
                orders.CustomerName = UserDetails.CustomerName;
                orders.CustomerEmail = UserDetails.Email;
                orders.CustomerPhone = UserDetails.CustomerPhone;

                @product.Stock = @product.Stock - item.Quantity;

                    db.Orders.Add(orders);
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }

            return View(orders);
        }
    }
}