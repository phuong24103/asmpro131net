using asmpro131_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.ViewModels
{
    public class ProductView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string ImageUrl { get; set; }
        public string Manufacturer { get; set; }
        public int Status { get; set; }
        public int Likes { get; set; }
        public string Description { get; set; }
        public Guid ColorID { get; set; }
        public Guid SizeID { get; set; }
       public Color? Color { get; set; }
        public Size? Size { get; set; }
    }
}
