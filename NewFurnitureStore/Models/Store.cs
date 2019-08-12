using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public class Store
    {
        //id of Store
        public int Id { get; set; }

        //Name of the Store
        public string Name { get; set; }

        //Location Of The Store
        public string Location { get; set; }

        //city of the store
        public string City { get; set; }
    }
}