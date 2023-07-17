using asmpro131_Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asmpro131_Shared.ViewModels
{
    public class FavoriteProductsView
    {
        public FavoriteProducts FavoriteProducts { get; set; }
        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}
