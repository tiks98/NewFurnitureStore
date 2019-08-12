using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFurnitureStore.Models
{
    public class Order
    {
        //order details
        public int Id { get; set; }

        public string OrderDate { get; set; }

        public double OrderTotal { get; set; }


        //product details
        public int PId { get; set; }

        public string PName { get; set; }

        public double PPrice { get; set; }

        public int Quantity { get; set; }

        //customer info
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }
    }
}