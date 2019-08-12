using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using FurnitureStore.Models;

namespace FurnitureStore.Models
{
    public class Product
    {
  
        //id of the product
        public int Id { get; set; }

        //name of the product
        public string Name { get; set; }

        //showing woodtype from woodtype table
        public WoodType WoodType { get; set; }

        //woodtype id from woodtype table
        public int WoodTypeId { get; set; }

        //discription of product
        public string Discription { get; set; }

        //brand of the product
        public string Brand { get; set; }

        //color of the product
        public string Color { get; set; }

        //price of the product
        public double Price { get; set; }

        //showing product type from product type table
        public ProductType ProductType { get; set; }

        //producttype id 
        public int ProductTypeId { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //showing store from store table
        public Store Store { get; set; }

        //store id
        public int StoreId { get; set; }
        //stock number of product
        public int Stock { get; set; }
        //image path of product
        public string ImagePath { get; set; }
    }
}