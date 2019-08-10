using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class Store
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string City { get; set; }
    }
}