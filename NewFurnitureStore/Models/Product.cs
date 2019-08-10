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
  
        public int Id { get; set; }

        public string Name { get; set; }

        public WoodType WoodType { get; set; }

        public int WoodTypeId { get; set; }

        public string Discription { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public double Price { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public Store Store { get; set; }

        public int StoreId { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }
    }
}